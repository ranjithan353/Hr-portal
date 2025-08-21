using HRPortal.Data;
using HRPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HRPortal.Controllers
{
    [ApiController]
    [Route("api/profile")]
    public class ProfileController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpPost("update-salary")]
        public async Task<IActionResult> UpdateSalary(long userId, decimal newSalary)
        {
            // ✅ Get the logged-in user's role from JWT
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            // ❌ Block if not Admin
            if (role != "Admin")
                return Unauthorized("Permission not granted: Only Admins can update salary.");

            var profile = await _context.Profiles.FirstOrDefaultAsync(p => p.UserId == userId);
            if (profile == null)
                return NotFound("Profile not found");

            profile.Salary = newSalary;
            await _context.SaveChangesAsync();

            return Ok("Salary updated successfully.");
        }
    }
}