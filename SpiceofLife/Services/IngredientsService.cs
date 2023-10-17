



using System.ComponentModel;

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

    internal Ingredient Get(int ingredientId)
    {
        Ingredient foundIngredient = _repo.Get(ingredientId);
        if (foundIngredient == null) throw new Exception($"Ingredient with ID {ingredientId} is not listed here");
        return foundIngredient;
    }

    internal string RemoveIngredient(int ingredientId, string userId)
    {
        Ingredient ingredient = this.Get(ingredientId);
        if (ingredient.CreatorId != userId) throw new Exception("Unauthorized");
        _repo.RemoveIngredient(ingredientId);
        return $"Ingredient with ID: {ingredientId} has been removed.";
    }
}