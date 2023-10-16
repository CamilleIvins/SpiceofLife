
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
        (name, quantity, recipeId)
        VALUES
        (@name, @quantity, @recipeId);
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
}
