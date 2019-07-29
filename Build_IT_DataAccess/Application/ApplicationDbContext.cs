using Build_IT_Data.Entities.Application;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Build_IT_DataAccess.Application
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
    }
}
