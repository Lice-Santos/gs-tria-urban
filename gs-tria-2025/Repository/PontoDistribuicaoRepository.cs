using gs_tria_2025.Connection;
using gs_tria_2025.Enums;
using gs_tria_2025.Models;
using gs_tria_2025.Services;
using Microsoft.EntityFrameworkCore;

namespace gs_tria_2025.Repository
{
    public class PontoDistribuicaoRepository
    {
        private readonly AppDbContext _context;

        public PontoDistribuicaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PontoDistribuicao>> GetAllAsync()
        {
            return await _context.PontosDistribuicao.ToListAsync();
        }

        public async Task<PontoDistribuicao?> GetByIdAsync(int id)
        {
            return await _context.PontosDistribuicao.FindAsync(id);
        }

        public async Task AddAsync(PontoDistribuicao ponto)
        {
            _context.PontosDistribuicao.Add(ponto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PontoDistribuicao ponto)
        {
            _context.Entry(ponto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(PontoDistribuicao ponto)
        {
            _context.PontosDistribuicao.Remove(ponto);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PontoDistribuicao>> GetByNomeAsync(string nome)
        {
            return await _context.PontosDistribuicao.Where(p => p.Nome.Contains(nome)).ToListAsync();
        }

        public async Task<IEnumerable<PontoDistribuicao>> GetByTipoAsync(Tipo tipo)
        {
            return await _context.PontosDistribuicao
                .Include(p => p.Endereco)
                .Include(p => p.Usuario)
                .Where(p => p.Tipo == tipo)
                .ToListAsync();
        }
    }
}
