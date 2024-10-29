using WebUITask.Models.BaseEntity;

namespace WebUITask.Models
{
    public class Customer:Base
    {
        public required string PhoneNumber { get; set; }
        public string CompanyName { get; set; } =string.Empty;

    }
}
