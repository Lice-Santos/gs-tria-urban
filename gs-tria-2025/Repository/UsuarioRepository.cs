using gs_tria_2025.Connection;
using gs_tria_2025.Models;
using Microsoft.EntityFrameworkCore;

namespace gs_tria_2025.Repository
{
    public class UsuarioRepository
    {
        private readonly AppDbContext _context;
        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task AddUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuario>> GetByNomeAsync(string nome)
        {
            return await _context.Usuarios.Where(p => p.NomeCompleto.Contains(nome)).ToListAsync();
        }


        public async Task<IEnumerable<Usuario>> FiltrarUsernameAsync(string username)
        {

            return await _context.Usuarios
                .Where(p => p.Username.Contains(username)).ToListAsync();
        }
    }
}
