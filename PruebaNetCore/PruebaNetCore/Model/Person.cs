using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNetCore.Model
{
    public class Person
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
    }
}
