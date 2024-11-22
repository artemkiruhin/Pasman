using Microsoft.EntityFrameworkCore;
using Pasman.Domain.Entities;

namespace Pasman.Database.SQLite.Repositories.Password;

public class PasswordNoteRepository : IPasswordNoteRepository
{
    private readonly AppDbContext _context;

    public PasswordNoteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(PasswordNote entity)
    {
        await _context.PasswordNotes.AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(PasswordNote entity)
    {
        _context.Update(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var password = await _context.PasswordNotes.FindAsync(id);
        
        if (password is null)
            throw new KeyNotFoundException($"Password with GUID {id} not found!");

        _context.PasswordNotes.Remove(password);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<PasswordNote>> GetAllAsync()
    {
        return await _context.PasswordNotes.ToListAsync();
    }

    public async Task<PasswordNote?> GetByIdAsync(Guid id)
    {
        return await _context.PasswordNotes.FindAsync(id);
    }
}