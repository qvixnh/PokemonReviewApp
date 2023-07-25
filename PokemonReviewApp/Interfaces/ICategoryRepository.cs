using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface ICategoryRepository
    {
        //Just the same as building pokemon conller
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Pokemon> GetPokemonByCategory(int categoryId);
        bool CategoryExists(int id);//make validation alot easier
        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool Save();
    }
}
