using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System_Aanlysis_EF.Services
{
    public class Person
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
