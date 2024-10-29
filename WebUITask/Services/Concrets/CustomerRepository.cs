using Microsoft.EntityFrameworkCore;
using WebUITask.Models;
using WebUITask.Services.Abstracts;

namespace WebUITask.Services.Concrets
{
    public class CustomerRepository(DbContext context) : Repository<Customer>(context), ICustomerInterface
    {

    }
}
