
namespace SpiceofLife.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Category { get; set; }
    public string Title { get; set; }
    public string Instructions { get; set; }
    public string Img { get; set; }
    public bool Archived { get; set; }
    public string CreatorId { get; set; }
    public Account Creator { get; set; }
}

public class RecipeFavouriteViewModel : Recipe
{
    public string AccountId { get; set; }
}