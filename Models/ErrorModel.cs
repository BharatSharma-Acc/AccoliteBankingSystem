using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.Json.Serialization;

namespace accolite_bank_application.Models
{
    public class ErrorModel
    {
        public ErrorModel()
        {
        }

        public ErrorModel(int code, string message, string description)
        {
            Code = code;
            Message = message;
            Description = description;
        }

        public int Code { get; set; }

        public string Message { get; set; }

        public string Description { get; set; }

    }
}
