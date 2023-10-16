



namespace SpiceofLife.Services;

public class IngredientsService
{
    private readonly IngredientsRepository _repo;
    public IngredientsService(IngredientsRepository repo)
    {
        _repo = repo;
    }

    internal Ingredient AddIngredient(Ingredient ingredientData)
    {
        Ingredient newIngredient = _repo.AddIngredient(ingredientData);
        return newIngredient;
    }

    internal List<Ingredient> GetIngredientsByRecipe(int recipeId)
    {
        List<Ingredient> ingredients = _repo.GetIngredientsByRecipe(recipeId);
        return ingredients;
    }

    internal void RemoveIngredient(int ingredientId, string userId)
    {
        Ingredient ingredient = Get;
    }
}