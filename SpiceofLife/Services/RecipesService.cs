


namespace SpiceofLife.Services;

public class RecipesService
{
    private readonly RecipesRepository _repo;
    public RecipesService(RecipesRepository repo)
    {
        _repo = repo;
    }

    internal Recipe Create(Recipe recipeData)
    {
        Recipe newRecipe = _repo.Create(recipeData);
        return newRecipe;
    }

    internal List<Recipe> GetAllRecipes()
    {
        List<Recipe> recipes = _repo.GetAllRecipes();
        return recipes;
    }

    internal Recipe Get(int recipeId)
    {
        Recipe foundRecipe = _repo.Get(recipeId);
        if (foundRecipe == null) throw new Exception($"Unable to find recipe with ID: {recipeId}");
        return foundRecipe;
    }

    internal Recipe UpdateRecipe(Recipe updateData)
    {
        Recipe original = this.Get(updateData.Id);
        original.Title = updateData.Title != null ? updateData.Title : original.Title;
        original.Category = updateData.Category != null ? updateData.Category : original.Category;
        original.Instructions = updateData.Instructions != null ? updateData.Instructions : original.Instructions;
        original.Img = updateData.Img ?? original.Img;
        Recipe recipe = _repo.UpdateRecipe(original);
        return recipe;
    }

    internal Recipe ArchiveRecipe(int recipeId, string userId)
    {
        Recipe recipe = this.Get(recipeId);
        if (recipe.CreatorId != userId) throw new Exception("Unauthorized");
        recipe.Archived = !recipe.Archived;
        _repo.Edit(recipe);
        return recipe;
    }
}
