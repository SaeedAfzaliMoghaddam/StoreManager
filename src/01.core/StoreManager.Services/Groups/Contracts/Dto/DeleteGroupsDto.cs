using System.ComponentModel.DataAnnotations;

namespace StoreManager.Services.Groups.Contracts.Dto
{
    public class DeleteGroupsDto
    {
        [Required]
        public int Id { get; set; }
    }
}