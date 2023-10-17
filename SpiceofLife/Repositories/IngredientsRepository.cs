


namespace SpiceofLife.Repositories;

public class IngredientsRepository
{
    private readonly IDbConnection _db;
    public IngredientsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Ingredient AddIngredient(Ingredient ingredientData)
    {
        string sql = @"
        INSERT INTO ingredients
        (name, quantity, creatorId, recipeId)
        VALUES
        (@name, @quantity, @creatorId, @recipeId);
        SELECT
        ingr.*
        FROM ingredients ingr
        WHERE ingr.id = LAST_INSERT_ID() 
        ;";
        Ingredient ingredient = _db.Query<Ingredient>(sql, ingredientData).FirstOrDefault();
        return ingredient;
        // Ingredient newIngredient = _db.Query<Ingredient, Account, Ingredient>(sql, (ingredient, account) =>
        // {
        //     ingredient.Creator = account;
        //     return ingredient;
        // }, ingredientData).FirstOrDefault();
        // return newIngredient;
    }

    internal Ingredient Get(int ingredientId)
    {
        string sql = @"
        SELECT
        ingr.*,
        acct.*
        FROM ingredients ingr
        JOIN accounts acct ON ingr.creatorId = acct.id
        WHERE ingr.id = @ingredientId
        ;";
        Ingredient foundIngredient = _db.Query<Ingredient, Account, Ingredient>(sql, (ingredient, account) =>
        {
            ingredient.Creator = account;
            return ingredient;
        }, new { ingredientId }).FirstOrDefault();
        return foundIngredient;
    }

    internal List<Ingredient> GetIngredientsByRecipe(int recipeId)
    {
        string sql = @"
        SELECT
        *
        FROM ingredients ingr
        WHERE recipeId = @recipeId
        ;";
        List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new { recipeId }).ToList();
        return ingredients;
    }

    internal void RemoveIngredient(int ingredientId)
    {
        string sql = @"
        DELETE FROM ingredients
        WHERE id = @ingredientId
        LIMIT 1
        ;";
        _db.Execute(sql, new { ingredientId });
    }
}
