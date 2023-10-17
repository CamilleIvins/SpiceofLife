
namespace SpiceofLife.Controllers;

[ApiController]
[Route("api/ingredients")]
public class IngredientsController : ControllerBase
{
    private readonly IngredientsService _ingredientsService;
    private readonly Auth0Provider _auth0;
    private readonly RecipesService _recipesService;
    public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth0, RecipesService recipesService)
    {
        _ingredientsService = ingredientsService;
        _auth0 = auth0;
        _recipesService = recipesService;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Ingredient>> CreateIngredient([FromBody] Ingredient ingredientData)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            ingredientData.CreatorId = userInfo.Id;
            Ingredient newIngredient = _ingredientsService.AddIngredient(ingredientData);
            return newIngredient;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpDelete("{ingredientId}")]
    public async Task<ActionResult<string>> RemoveIngredient(int ingredientId)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            string message = _ingredientsService.RemoveIngredient(ingredientId, userInfo.Id);
            return Ok(message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
