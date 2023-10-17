




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
        (@accountId, @recipeId);
        SELECT
        LAST_INSERT_ID()
        ;";
        int lastInsertId = _db.ExecuteScalar<int>(sql, favoriteData);
        favoriteData.Id = lastInsertId;
        return favoriteData;
    }

    internal List<RecipeFavouriteViewModel> GetFavoritesByAccount(string accountId)
    {
        string sql = @"
        SELECT
        fav.*,
        rec.*
        FROM favorites fav
        JOIN recipes rec ON rec.id = fav.recipeId
        WHERE fav.accountId = @accountId
        ;";
        List<RecipeFavouriteViewModel> myRecipes = _db.Query<Favorite, RecipeFavouriteViewModel, RecipeFavouriteViewModel>(sql, (favorite, recipe) =>
        {
            recipe.FavoriteId = favorite.Id;
            recipe.AccountId = favorite.AccountId;
            return recipe;
        }, new { accountId }).ToList();
        return myRecipes;
    }

    internal Favorite GetFavoriteById(int favoriteId)
    {
        string sql = @"
        SELECT *
        FROM favorites
        WHERE id = @favoriteId
        ;";
        Favorite favorite = _db.Query<Favorite>(sql, new { favoriteId }).FirstOrDefault();
        return favorite;
    }

    // internal void RemoveFavorite(int favoriteId)
    // {
    //     string sql = @"
    //     DELETE FROM favorites
    //     WHERE id = @favoriteId
    //     LIMIT 1
    //     ;";
    //     _db.Execute(sql, new { favoriteId });
    // }
    internal int RemoveFavorite(int favoriteId)
    {
        string sql = @"
        DELETE FROM favorites
        WHERE id = @favoriteId
        LIMIT 1
        ;";
        int rows = _db.Execute(sql, new { favoriteId });
        return rows;
    }
}