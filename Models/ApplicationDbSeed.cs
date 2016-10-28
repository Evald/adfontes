using System;
using System.Linq;

namespace Adfontes.Models {

    public class ApplicationDbSeed{

        private ApplicationDbContext _context;
        public ApplicationDbSeed(ApplicationDbContext context){

            this._context = context;
            this._signingkey = signingkey;
        }
        public async void InitialSeed()
        {
            if (_context.AllMigrationsApplied())
            {
                string[] roles = new string[] { "Owner", "Subscriber" };
                var roleStore = new RoleStore<IdentityRole>(_context);

                foreach (string role in roles)
                {
                    if (!_context.Roles.Any(r => r.Name == role))
                    {
                        await roleStore.CreateAsync(new IdentityRole(role));
                    }
                }

                string[] notetypes = new string[] { "Page", "Code", "Text" };

                foreach (var type in notetypes)
                {
                    if (!_context.NoteTypes.Any(t => t.Title == type))
                    {
                        _context.NoteTypes.Add(new NoteType { Title = type })
                    }
                }
            

                
                var user = new ApplicationUser
                {
                    FirstName = "Jens Evald",
                    LastName = "Vandel",
                    Email = "jorvica@gmail.com",
                    UserName = "jorvica@gmail.com",
                    PhoneNumber = "+4792161392",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };
                
                if (!_context.Users.Any(u => u.UserName == user.UserName))
                {
                    var password = new PasswordHasher<ApplicationUser>();
                    var hashed = password.HashPassword(user,"iNRK+vj?4<x4jKhA}RY]9STc69a!}S2wv }N>.lTzdvX=$%EK-Kja/T^Us?!{tkM" );
                    user.PasswordHash = hashed;
                    var userStore = new UserStore<ApplicationUser>(_context);
                    await userStore.CreateAsync(user);
                    await userStore.AddToRoleAsync(user, "Owner");
                }

                if (!_context.Notebooks.Any())
                {
                    var page = _context.NoteTypes.Single(t => t.Title == "Page");
                    var text = _context.NoteTypes.Single(t => t.Title == "Text");

                    var notebook1 = _context.Notebooks.Add( new Notebook{ Title = "Asp.Net Core", Author = user }).Entity;
                    var notebook2 = _context.Notebooks.Add( new Notebook{ Title = "Angular2", Author = user }).Entity;
                    
                    var rootNote2 = _context.Add(new Note { Title = "An overview of Startup.cs", NoteType = page, Notebook = notebook1, Author = user }).Entity;
                    var rootNote2 = _context.Add(new Note { Title = "Components in Angular2", NoteType = page, Notebook = notebook2, Author = user }).Entity;

                    _context.Products.AddRange(
                        new note { Title = "Components in Angular2", NoteType = page, Notebook = notebook2, Author = user }
                }

                await _context.SaveChangesAsync();
                

            }
        }
    }
}