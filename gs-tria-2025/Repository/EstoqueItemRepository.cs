using gs_tria_2025.Connection;
using gs_tria_2025.Models;
using Microsoft.EntityFrameworkCore;

namespace gs_tria_2025.Repository
{
    public class EstoqueItemRepository
    {
        private readonly AppDbContext _context;
        public EstoqueItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EstoqueItem>> GetAllAsync()
        {
            return await _context.Estoques.ToListAsync();
        }

        public async Task<EstoqueItem?> GetByIdAsync(int id)
        {
            return await _context.Estoques.FindAsync(id);
        }

        public async Task AddAsync(EstoqueItem estoque)
        {
            _context.Estoques.Add(estoque);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EstoqueItem estoque)
        {
            _context.Entry(estoque).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(EstoqueItem estoque)
        {
            _context.Estoques.Remove(estoque);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EstoqueItem>> GetByPontoAsync(int idPontoDistribuicao)
        {
            return await _context.Estoques
                .Include(e => e.Item)
                .Include(e => e.PontoDistribuicao)
                .Where(e => e.IdPontoDistribuicao == idPontoDistribuicao)
                .ToListAsync();
        }

        public async Task<IEnumerable<EstoqueItem>> GetByItemAsync(int idItem)
        {
            return await _context.Estoques
                .Include(e => e.Item)
                .Include(e => e.PontoDistribuicao)
                .Where(e => e.IdItem == idItem)
                .ToListAsync();
        }
    }
}
