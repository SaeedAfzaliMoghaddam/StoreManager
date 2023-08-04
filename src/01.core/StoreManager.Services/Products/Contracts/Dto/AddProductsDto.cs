using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace StoreManager.Services.Products.Contracts.Dto
{
    public class AddProductsDto
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [Range(1, 1000)]
        public int GroupId { get; set; }

        [Required]
        [Range(1, 1000)]
        public int MinimumInventory { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public ProductStatus Status { get; set; }
        public int Inventory { get; set; }
    }
}