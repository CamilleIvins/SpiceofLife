



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
    }

    internal void RemoveFavorite(int favoriteId)
    {
        Favorite favorite = _repo.GetFavoriteById(favoriteId);
        if (favorite == null) throw new Exception("This is not one of your favouties");
        return favorite;
    }
}
