using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Repository.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; } = default!;
        [Required]
        public string Gender { get; set; } = default!;
        [Required]
        public string Email { get; set; } = default!;

        [Required]
        [Display (Name="Pin Code")]
        public int Pincode { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool IsActive { get; set; }

    }
}
