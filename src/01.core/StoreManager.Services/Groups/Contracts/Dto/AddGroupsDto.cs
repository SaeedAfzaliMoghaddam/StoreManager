using System.ComponentModel.DataAnnotations;

namespace StoreManager.Services.Groups.Contracts.Dto
{
    public class AddGroupsDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}