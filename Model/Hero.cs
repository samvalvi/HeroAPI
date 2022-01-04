using System;
using System.ComponentModel.DataAnnotations;

namespace HeroAPI.Model
{
    public class Hero
    {
        [Key]
        public int HeroId { get; set; }
        [Required]
        [MaxLength(200)]
        public string HeroName { get; set; } = string.Empty;
        [Required]
        [MaxLength(200)]
        public string City { get; set; } = string.Empty;
        [Required]
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
    }
}
