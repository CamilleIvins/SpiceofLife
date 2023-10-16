
namespace SpiceofLife.Repositories;

public class RecipesRepository
{
    private readonly IDbConnection _db;
    public RecipesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Recipe Create(Recipe recipeData)
    {
        string sql = @"
        INSERT INTO recipes (title, category, instructions, img, archived, creatorId)
        VALUES (@title, @category, @instructions, @img, @archived, @creatorId);

        SELECT
        acct.*,
        rec.*
        FROM recipes rec
        JOIN accounts acct ON acct.id = rec.creatorId
        WHERE rec.id = LAST_INSERT_ID()
        ;";
        Recipe newRecipe = _db.Query<Account, Recipe, Recipe>(sql, (account, recipe) =>
        {
            recipe.Creator = account;
            return recipe;
        }, recipeData).FirstOrDefault();
        return newRecipe;
    }

    internal List<Recipe> GetAllRecipes()
    {
        string sql = @"
        SELECT
        rec.*,
        acct.*
        FROM recipes rec
        JOIN accounts acct ON acct.id = rec.creatorId
        ;";
        List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        }).ToList();
        return recipes;
    }

    internal Recipe Get(int recipeId)
    {
        string sql = @"
        SELECT
        rec.*,
        acct.*
        FROM recipes rec
        JOIN accounts acct ON rec.creatorId = acct.id
        WHERE rec.id = @recipeId
        ;";
        Recipe foundRecipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        }, new { recipeId }).FirstOrDefault();
        return foundRecipe;
    }

    internal Recipe UpdateRecipe(Recipe recipeData)
    {
        string sql = @"
        UPDATE recipes
        SET
        category = @category,
        title = @title,
        img = @img,
        instructions = @instructions
        WHERE id = @id;
        SELECT * FROM recipes WHERE id = @id
        ;";
        Recipe recipe = _db.Query<Recipe>(sql, recipeData).FirstOrDefault();
        return recipe;
    }

    internal void Edit(Recipe recipe)
    {
        string sql = @"
        UPDATE recipes
        SET
        category = @category,
        title = @title,
        img = @img,
        instructions = @instructions
        WHERE id = @id;
        ;";
        _db.Execute(sql, recipe);
    }
}
