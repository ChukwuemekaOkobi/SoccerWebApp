using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerWebApp.Models
{
    public class Bank
    {   

        public Guid Id { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }

        public string AccountName { get; set; }
        public Decimal Balance { get; set; }

    }
}
