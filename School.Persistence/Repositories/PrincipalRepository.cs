using Microsoft.EntityFrameworkCore;
using School.Application.Interfaces;
using School.Domain.Entities;
using School.Persistence.DBcontextsManahement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Persistence.Repositories
{
    public class PrincipalRepository : IPrincipalRepository
    {
        private readonly SchoolDbContext _context;

        public PrincipalRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AnyPrincipalExistsAsync()
        {
            return await _context.Principals.AnyAsync();
        }

        public async Task<bool> AddPrincipalAsync(Principal principal)
        {
            _context.Principals.Add(principal);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<Principal?> GetPrincipalByEmailAndPasswordAsync(string email, string encryptedPassword)
        {
            return await _context.Principals
                .FirstOrDefaultAsync(p => p.Email == email && p.PasswordHash == encryptedPassword);
        }

    }

}
