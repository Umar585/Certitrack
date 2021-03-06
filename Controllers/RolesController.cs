using Certitrack.Data;
using Certitrack.Extensions.Alerts;
using Certitrack.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Certitrack.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly CertitrackContext _context;

        private UserManager<Staff> UserManager { get; set; }
        private RoleManager<Role> RoleManager { get; set; }

        public RolesController(CertitrackContext context, UserManager<Staff> userManager, RoleManager<Role> roleManager)
        {
            _context = context;
            UserManager = userManager;
            RoleManager = roleManager;
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
            return View(await RoleManager.Roles.ToListAsync());
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] Role role)
        {
            if (RoleExists(role.Title))
            {
                return View(role)
                    .WithWarning("Role Exists", "A role with the same title exists. Try a different title.");
            }

            if (ModelState.IsValid)
            {
                await RoleManager.SetRoleNameAsync(role, role.Title);
                await RoleManager.CreateAsync(role);

                return RedirectToAction(nameof(Index))
                    .WithSuccess("Success", role.Title + " role successfully created.");
            }
            return View(role)
                .WithWarning("Uh-Oh!", "Something went wrong. Try again.");
        }

        // GET: Roles/Edit/5
        public IActionResult Edit(int id)
        {
            Role role = null;
            if (id >= 0)
            {
                role = _context.Role.Find(id);
                if (role == null)
                {
                    return NotFound();
                }
            }
            return View(role);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] Role role)
        {
            if (id != role.Id)
            {
                return NotFound();
            }
            if (RoleExists(role.Title) && RoleDescriptionExists(role.Description))
            {
                return View(role)
                    .WithWarning("Role Exists", "A role with the same title & description exists. Try a different title.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Role _role = await RoleManager.FindByIdAsync(role.Id.ToString());
                    await RoleManager.SetRoleNameAsync(_role, role.Title);

                    _role.Title = role.Title;
                    _role.Description = role.Description;

                    await RoleManager.UpdateAsync(_role);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleExists(role.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index))
                    .WithSuccess("Update Successful", role.Title + " role successfully updated.");
            }
            return View(role)
                .WithWarning("Uh-Oh!", "Something went wrong. Try again.");
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<string> DeleteConfirmed(int id)
        {
            try
            {
                Role role = await _context.Role.FindAsync(id);
                _context.Role.Remove(role);
                await _context.SaveChangesAsync();
                return "The " + role.Title + " role was deleted successfully";
            }
            catch (Exception e)
            {
                if (!RoleExists(id))
                {
                    return "Role Id #" + id + " doesn't exist";
                }
                else
                {
                    Console.WriteLine(e.Message.ToString());
                    return "Delete staff associated with this role and try again.";
                    throw;
                }
            }
        }

        private bool RoleExists(int id)
        {
            return _context.Role.Any(e => e.Id == id);
        }

        private bool RoleExists(string title)
        {
            return _context.Role.Any(e => e.Title == title);
        }

        private bool RoleDescriptionExists(string description)
        {
            return _context.Role.Any(e => e.Description == description);
        }
    }
}
