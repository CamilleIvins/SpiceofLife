
namespace SpiceofLife.Controllers;
[ApiController]
[Route("api/favorites")]
public class FavoritesController : ControllerBase
{
    private readonly FavoritesService _favoritesService;
    private readonly Auth0Provider _auth0;
    public FavoritesController(FavoritesService favoritesService, Auth0Provider auth0)
    {
        _favoritesService = favoritesService;
        _auth0 = auth0;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Favorite>> AddFavorite([FromBody] Favorite favoriteData)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            Favorite favorite = _favoritesService.AddFavorite(favoriteData, userInfo);
            return favorite;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{favoriteId}")]
    public ActionResult<Favorite> GetFavoriteById(int favoriteId)
    {
        try
        {
            Favorite favorite = _favoritesService.GetFavoriteById(favoriteId);
            return Ok(favorite);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpDelete("{favoriteId}")]
    public async Task<ActionResult<string>> RemoveFavorite(int favoriteId)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            _favoritesService.RemoveFavorite(favoriteId);
            string message = "Removed from Favourites";
            return message;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
