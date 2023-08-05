using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Services.ProductEntrances.Contracts.Dto
{
    public class AddProductEntranceDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int ProductId { get; set; }

        [Required]
        public string DateTime { get; set; }

        [Required]
        [Range (1, int.MaxValue)]
        public int Count { get; set; }

        [Required]
        public string FactorNumber { get; set; }

        [Required]
        [MaxLength (50)]
        public string ProductCompanyName { get; set; }
    }
}
