




namespace SpiceofLife.Services;

public class FavoritesService
{
    private readonly FavoritesRepository _repo;
    public FavoritesService(FavoritesRepository repo)
    {
        _repo = repo;
    }

    internal Favorite AddFavorite(Favorite favoriteData, Account userInfo)
    {
        favoriteData.AccountId = userInfo.Id;
        Favorite favorite = _repo.AddFavorite(favoriteData);
        return favorite;
    }

    internal Favorite GetFavoriteById(int favoriteId)
    {
        Favorite favorite = _repo.GetFavoriteById(favoriteId);
        return favorite;
    }

    internal List<RecipeFavouriteViewModel> GetFavoritesByAccount(string userId)
    {
        List<RecipeFavouriteViewModel> myRecipes = _repo.GetFavoritesByAccount(userId);
        return myRecipes;
    }

    // internal int RemoveFavorite(int favoriteId, string userId)
    // {
    //     Favorite foundFavorite = _repo.GetFavoriteById(favoriteId);
    //     if (foundFavorite == null) throw new Exception("This is not one of your favourites");
    //     if (foundFavorite.AccountId != userId) throw new Exception("Unauthorized");
    //     _repo.RemoveFavorite(favoriteId);
    // }
    internal void RemoveFavorite(int favoriteId, string userId)
    {
        Favorite foundFavorite = _repo.GetFavoriteById(favoriteId);
        if (foundFavorite == null) throw new Exception("This is not one of your favourites");
        if (foundFavorite.AccountId != userId) throw new Exception("Unauthorized");
        int rows = _repo.RemoveFavorite(favoriteId);
        if (rows > 1) throw new Exception("Alas, something went wrong");
        if (rows < 1) throw new Exception("Forsooth, something went way wrong!");
    }
}
