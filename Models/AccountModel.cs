using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.Json.Serialization;

namespace accolite_bank_application.Models
{
    public class AccountModel
    {
        public int accountId { get; set; }
        public string accountType { get; set; }
        public decimal balance { get; set; }

        [JsonIgnore]
        public int userId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public string message { get; set; }

        public ErrorModel Error { get; set; }


    }
}
