using gs_tria_2025.Connection;
using gs_tria_2025.Models;
using Microsoft.EntityFrameworkCore;

namespace gs_tria_2025.Repository
{
    public class EnderecoRepository
    {
        private readonly AppDbContext _context;

        public EnderecoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Endereco>> GetAllAsync()
        {
            return await _context.Enderecos.ToListAsync();
        }

        public async Task<Endereco?> GetByIdAsync(int id)
        {
            return await _context.Enderecos.FindAsync(id);
        }

        public async Task AddAsync(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Endereco endereco)
        {
            _context.Entry(endereco).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Endereco endereco)
        {
            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Endereco>> GetByLogradouroAsync(string logradouro)
        {
            return await _context.Enderecos.Where(p => p.Logradouro.Contains(logradouro)).ToListAsync();
        }

        public async Task<Endereco> GetByCepAsync(string cep)
        {
            return await _context.Enderecos.FirstOrDefaultAsync(p => p.Cep == cep);
        }


        public async Task<IEnumerable<Endereco>> FiltrarAsync(string cidade)
        {

            return await _context.Enderecos.Where(p => p.Cidade != null && p.Cidade.ToLower().Contains(cidade.ToLower())).ToListAsync();

        }
    }
}
