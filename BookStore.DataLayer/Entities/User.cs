using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BookStore.DataLayer.Entities
{
    public class User : IdentityUser
    {
        [MaxLength(70)]
        public string? City { get; set; }

        [MaxLength(200)]
        [Required]
        public required string FullName { get; set; }
        //ToDo add other properties 
    }
}
