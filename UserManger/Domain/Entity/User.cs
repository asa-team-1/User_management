using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "LastName is Required!")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Mobile is Required!")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is Required!")]

        public string? Password { get; set; }

        public bool IsActive { get; set; }

        public string? Email { get; set; } 

        public bool IsEmailConfirmed { get; set; }

        public int? AddressId { get; set; }

        public int? Level { get; set; }

        public bool IsDeleted { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
