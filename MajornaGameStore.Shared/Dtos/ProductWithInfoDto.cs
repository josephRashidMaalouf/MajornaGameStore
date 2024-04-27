using MajornaGameStore.DataAccess.Entities;

namespace MajornaGameStore.Shared.Dtos;

public class ProductWithInfoDto
{
    
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int ProductTypeId { get; set; }
        public int DiscountId { get; set; } = 1;
        public string Description { get; set; }
        public string Languages { get; set; }
        public string ImageLink { get; set; }
        public string PcRequirements { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<DeveloperDto> Developers { get; set; }
        public ICollection<PublisherDto> Publishers { get; set; }
        public ICollection<Screenshot> Screenshots { get; set; }
        public ICollection<TagDto> Tags { get; set; }
        public ICollection<Review> Review { get; set; }

        public int AgeRating { get; set; }
    
}