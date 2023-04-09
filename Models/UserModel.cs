using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.Json.Serialization;

namespace accolite_bank_application.Models
{
    public class UserModel
    {
        
        public int userID { get; set; }
        public string userName { get; set; }
        
        public DateTime DateCreated { get; set; }
        
        public string message { get; set; }

    }
}
