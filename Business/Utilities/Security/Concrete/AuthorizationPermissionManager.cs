using Business.Utilities.Security.Abstract;
using Core.Entities.Concrete.Auth;
using DataAccess.EFCore;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
public class AuthorizationPermissionManager : IAuthorizationPermissionService
{
    private readonly EducationDbContext _context;
    private readonly UserManager<AppUser> _userManager;

    public AuthorizationPermissionManager(
        EducationDbContext context,
        UserManager<AppUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // =====================================================
    // Permission Check (Attribute istifadə edir)
    // =====================================================
    public async Task<bool> HasPermissionAsync(
        string userId,
        List<string> roles,
        string permission)
    {
        // 🔐 SuperAdmin bypass (case-safe)
        if (roles.Any(r => r.Equals("SuperAdmin", StringComparison.OrdinalIgnoreCase)))
            return true;

        // 1️⃣ User override
        var hasUserPermission = await _context.Set<AppUserPermission>()
            .AnyAsync(x =>
                x.AppUserId == userId &&
                x.Permission.Code == permission);

        if (hasUserPermission)
            return true;

        // 2️⃣ Role permission
        return await _context.Set<RolePermission>()
            .AnyAsync(x =>
                roles.Contains(x.Role.Name) &&
                x.Permission.Code == permission);
    }

    // =====================================================
    // Full Permission List
    // =====================================================
    public async Task<List<Permission>> GetPermissionsForUserAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return new List<Permission>();

        var roles = await _userManager.GetRolesAsync(user);

        // SuperAdmin → hamısı
        if (roles.Any(r => r.Equals("SuperAdmin", StringComparison.OrdinalIgnoreCase)))
            return await _context.Set<Permission>().ToListAsync();

        var rolePermissionIds = await _context.Set<RolePermission>()
            .Where(rp => roles.Contains(rp.Role.Name))
            .Select(rp => rp.PermissionId)
            .ToListAsync();

        var userPermissionIds = await _context.Set<AppUserPermission>()
            .Where(up => up.AppUserId == userId)
            .Select(up => up.PermissionId)
            .ToListAsync();

        var finalIds = rolePermissionIds
            .Concat(userPermissionIds)
            .Distinct()
            .ToList();

        return await _context.Set<Permission>()
            .Where(p => finalIds.Contains(p.Id))
            .ToListAsync();
    }

    // =====================================================
    // JWT üçün
    // =====================================================
    public async Task<List<string>> GetUserPermissionsAsync(string userId)
    {
        var permissions = await GetPermissionsForUserAsync(userId);
        return permissions.Select(p => p.Code).ToList();
    }

    // =====================================================
    // Delegation Logic
    // =====================================================
    //public async Task<bool> CanAssignPermissionAsync(string currentUserId, string targetUserId)
    //{
    //    var currentUser = await _userManager.FindByIdAsync(currentUserId);
    //    if (currentUser == null) return false;

    //    var roles = await _userManager.GetRolesAsync(currentUser);

    //    // SuperAdmin → hər kəsə
    //    if (roles.Any(r => r.Equals("SuperAdmin", StringComparison.OrdinalIgnoreCase)))
    //        return true;

    //    // Admin → yalnız Teacher-lara
    //    if (roles.Any(r => r.Equals("Admin", StringComparison.OrdinalIgnoreCase)))
    //    {
    //        return await _context.Set<Teacher>()
    //            .AnyAsync(t => t.AppUserId == targetUserId);
    //    }

    //    // Teacher → yalnız öz studentlərinə
    //    if (roles.Any(r => r.Equals("Teacher", StringComparison.OrdinalIgnoreCase)))
    //    {
    //        var teacher = await _context.Set<Teacher>()
    //            .FirstOrDefaultAsync(t => t.AppUserId == currentUserId);

    //        if (teacher == null) return false;

    //        return await _context.Set<Student>()
    //            .AnyAsync(s =>
    //                s.AppUserId == targetUserId &&
    //                s.Group != null &&
    //                s.Group.TeacherId == teacher.Id);
    //    }

    //    return false;
    //}

    public async Task<bool> CanAssignPermissionAsync(string currentUserId, string targetUserId)
    {
        var currentUser = await _userManager.FindByIdAsync(currentUserId);
        if (currentUser == null) return false;

        var roles = await _userManager.GetRolesAsync(currentUser);

        // SuperAdmin → hər kəsə
        if (roles.Any(r => r.Equals("SuperAdmin", StringComparison.OrdinalIgnoreCase)))
            return true;

        // Admin → yalnız Teacher-lara
        if (roles.Any(r => r.Equals("Admin", StringComparison.OrdinalIgnoreCase)))
        {
            return await _context.Set<Teacher>()
                .AnyAsync(t => t.AppUserId == targetUserId);
        }

        // Teacher → yalnız öz studentlərinə
        if (roles.Any(r => r.Equals("Teacher", StringComparison.OrdinalIgnoreCase)))
        {
            var teacherId = await _context.Set<Teacher>()
                .Where(t => t.AppUserId == currentUserId)
                .Select(t => t.Id)
                .FirstOrDefaultAsync();

            if (teacherId == Guid.Empty)
                return false;

            return await _context.Set<Student>()
                .AnyAsync(s =>
                    s.AppUserId == targetUserId &&
                    s.Group.TeacherId == teacherId);
        }

        return false;
    }


    public async Task<bool> IsSuperAdmin(string roleId)
    {
        var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == roleId);

        if (role == null) return false;

        return role.Name.Equals("SuperAdmin", StringComparison.OrdinalIgnoreCase);
    }
}
