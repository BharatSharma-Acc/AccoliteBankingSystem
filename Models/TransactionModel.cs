using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.Json.Serialization;

namespace accolite_bank_application.Models
{
    public class TransactionModel
    {
        public int accountId { get; set; }

        public string transType { get; set; }

        public decimal transAmount { get; set; }
        public decimal preBalance { get; set; }

        public decimal postBalance { get; set; }

        public DateTime transDate { get; set; }

        public string message { get; set; }

        public ErrorModel Error { get; set; }


    }
}
