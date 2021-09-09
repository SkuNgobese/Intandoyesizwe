using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Intandoyesizwe.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<AdmissionApplication> AdmissionApplications { get; set; }

        public DbSet<Parent> Parents { get; set; }

        public DbSet<Personal> Personals { get; set; }

        public DbSet<PrevSchool> PrevSchools { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<PhysicalAddress> PhysicalAddresses { get; set; }

        public DbSet<Correspondence> Correspondences { get; set; }

        public DbSet<Rejected> Rejecteds { get; set; }
        public DbSet<ApplicationsDate> ApplicationsDates { get; set; }
    }
}