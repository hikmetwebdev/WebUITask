using System.ComponentModel.DataAnnotations;
using WebUITask.Models.BaseEntity;

namespace WebUITask.Models
{
    public class User:Base
    {

        public required string Email { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
