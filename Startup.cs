using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using mvcproject.Models;
using System.Collections.ObjectModel;
using System.Data.Entity;
[assembly: OwinStartupAttribute(typeof(mvcproject.Startup))]
namespace mvcproject
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRoles();
            createuser();
        }
        public void createuser()
        {

            var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new ApplicationUser();
            user.Email = "admin@gmail";
            user.UserName = "admin";
            var cherk = usermanager.Create(user, "123");
            if (cherk.Succeeded)
            {
                usermanager.AddToRole(user.Id, "Admins");
            }
        }
        public void createRoles()
        {
            var rolemanger = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole role;
            if (!rolemanger.RoleExists("Admins"))
            {
                role = new IdentityRole();
                role.Name = "Admins";
                rolemanger.Create(role);
            }
            if (!rolemanger.RoleExists("emplyees"))
            {
                role = new IdentityRole();
                role.Name = "emplyees";
                rolemanger.Create(role);
            }
            if (!rolemanger.RoleExists("visitors"))
            {
                role = new IdentityRole();
                role.Name = "visitors";
                rolemanger.Create(role);
            }
        }
    }
}
