using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Address
    {
        public int Id { get; set; }
        public string? Province { get; set; }
        public string? City { get; set; }
        public string? DetailedAddress { get; set; }
        public int? PostalCode { get; set; }
        public int User_Fk_Id { get; set; }

        public bool IsDeleted { get; set; }

    }
}
