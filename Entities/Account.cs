using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace accolite_bank_application.Entities
{
    public class Account
    {
        [Key]
        public int accountId { get; set; }
        public string accountType { get; set; }
        public decimal balance { get; set; }
        public int userId { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }


    }
}
