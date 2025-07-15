using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System_Aanlysis_EF.Services
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public Customer customer { get; set; }

        [ForeignKey("customer")]
        public int customerId { get; set; } 
    }
}
