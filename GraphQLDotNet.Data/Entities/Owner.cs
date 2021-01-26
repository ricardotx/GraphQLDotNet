using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphQLDotNet.Data.Entities
{
    public class Owner
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string Address { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
