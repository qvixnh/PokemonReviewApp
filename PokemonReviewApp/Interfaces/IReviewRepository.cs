using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int reviewid);
        ICollection<Review> GetReviewsOfAPokemon(int pokeId);
        bool ReviewExists(int reviewid);
        ICollection<Review> GetReviewForAPokemon(int pokeId);
        bool CreateReview(Review review);
        bool UpdateReview(Review review);
        bool Save();
    }
}
