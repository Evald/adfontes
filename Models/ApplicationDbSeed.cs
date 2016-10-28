using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Adfontes.Models
{

    public class ApplicationDbSeed
    {

        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationDbSeed(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {

            this._context = context;
            this._userManager = userManager;

        }
        public async void InitialSeed()
        {

            _context.Database.EnsureCreated();

            //skip seed if db is already seeded.
            if (_context.Notebooks.Any())
            {
                return;
            }

            if (!_context.Roles.Any())
            {
                string[] roles = { "Owner", "Subscriber" };

                foreach (string role in roles)
                {
                    if (!_context.Roles.Any(r => r.Name == role))
                    {
                        _context.Roles.Add(new IdentityRole
                        {
                            Name = role,
                            NormalizedName = role.ToUpper()
                        });
                    }

                }
                _context.SaveChanges();
            }


            if (!_context.ComponentTypes.Any())
            {
                string[] componentTypes = new string[] { "Code", "Text", "image" };

                foreach (var type in componentTypes)
                {
                    if (!_context.ComponentTypes.Any(t => t.Title == type))
                    {
                        _context.ComponentTypes.Add(new ComponentType { Title = type });
                    }
                }
                _context.SaveChanges();
            }


            if (!_context.Users.Any())
            {
                var user = new ApplicationUser
                {
                    FirstName = "Jens Evald",
                    LastName = "Vandel",
                    Email = "jorvica@gmail.com",
                    UserName = "Evald",
                    PhoneNumber = "+4792161392",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user, "password");
                user.PasswordHash = hashed;

                _context.Users.Add(user);

                _context.SaveChanges();
            }

            if (!_context.UserRoles.Any())
            {
                var user = await _userManager.FindByEmailAsync("Evald");
                if (user != null)   
                {
                    var result = await _userManager.AddToRoleAsync(user, "Owner");
                    await _context.SaveChangesAsync();
                }
            }

            if (!_context.Notebooks.Any())
            {
                var user = _context.Users.Single(u => u.FirstName == "Jens Evald");
                var code = _context.ComponentTypes.Single(t => t.Title == "Code");
                var text = _context.ComponentTypes.Single(t => t.Title == "Text");

                var notebook1 = _context.Notebooks.Add(new Notebook { Title = "Asp.Net Core", Author = user, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }).Entity;
                var notebook2 = _context.Notebooks.Add(new Notebook { Title = "Angular2", Author = user, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }).Entity;

                var Note1 = _context.Add(new Note { Title = "An overview of Entity Framwork Core model creation", Notebook = notebook1, Author = user, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }).Entity;
                var Note2 = _context.Add(new Note { Title = "Components in Angular2", Notebook = notebook2, Author = user, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }).Entity;

                _context.Components.AddRange(
                    new Component { ComponentType = text, Note = Note1, Content = "This is why data annotations are awesome when creating models." },
                    new Component { ComponentType = code, Note = Note1, Content = " [DatabaseGenerated(DatabaseGeneratedOption.Computed)]public DateTime LastUpdated { get; set; }" },
                    new Component { ComponentType = text, Note = Note2, Content = "Components in Angular2 are declared using this decorator." },
                    new Component { ComponentType = code, Note = Note2, Content = "@Component { // content of the decorator}" }
                );
                _context.SaveChanges();
            }
        }
    }
}