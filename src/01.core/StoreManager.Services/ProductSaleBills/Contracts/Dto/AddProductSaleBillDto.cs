using System.ComponentModel.DataAnnotations;

namespace StoreManager.Services.ProductSaleBills.Contracts.Dto
{
    public class AddProductSaleBillDto
    {
        [Required]
        [MaxLength(50)]
        public string ProductName { get; set; }

        [Required]
        public int UnitPrice { get; set; }

        [Required]
        [MaxLength(50)]
        public string CustomerName { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public string BillNumber { get; set; }




    }
}