using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace accolite_bank_application.Entities
{
    public class User
    {
        
        public int Id { get; set; }
        public int userID { get; set; }
        public string userName { get; set; }
        public DateTime DateCreated { get; set; }



    }
}
