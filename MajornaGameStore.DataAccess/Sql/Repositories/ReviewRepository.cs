using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;

namespace MajornaGameStore.DataAccess.Sql.Repositories;

public class ReviewRepository(MajornaDbContext context) : RepositoryBase<Review, int>(context), IReviewRepository
{
    public override async Task<bool> UpdateAsync(Review entity)
    {
        var review = await _context.Reviews.FindAsync(entity.Id);

        if (review is null)
            return false;

        review.Comment = entity.Comment;
        review.ProductId = entity.ProductId;
        review.UserId = entity.UserId;
        review.Rating = entity.Rating;

        await _context.SaveChangesAsync();
        return true;
    }
}