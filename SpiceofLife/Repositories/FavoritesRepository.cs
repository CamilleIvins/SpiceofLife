


namespace SpiceofLife.Repositories;

public class FavoritesRepository
{
    private readonly IDbConnection _db;
    public FavoritesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Favorite AddFavorite(Favorite favoriteData)
    {
        string sql = @"
        INSERT INTO favorites
        (accountId, recipeId)
        VALUES
        (@accountId, @recipeId)
        SELECT LAST_INSERT_ID
        ;";
        int lastInsertId = _db.ExecuteScalar<int>(sql, favoriteData);
        favoriteData.Id = lastInsertId;
        return favoriteData;
    }

    internal Favorite GetFavoriteById(int favoriteId)
    {
        throw new NotImplementedException();
    }
}