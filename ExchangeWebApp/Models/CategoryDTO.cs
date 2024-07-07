namespace ExchangeWebApp.Models
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Note { get; set; }
        public string? Description { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool? IsActive { get; set; } = true;

        public int? DisplayOrder { get; set; }

        public string? MetaKeywords { get; set; }

        public string? MetaDescription { get; set; }

        public string? ThumbnailImage { get; set; }
    }
}
