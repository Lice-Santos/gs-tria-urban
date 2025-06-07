using gs_tria_2025.Connection;
using gs_tria_2025.Exceptions;
using gs_tria_2025.Models;
using Microsoft.EntityFrameworkCore;

namespace gs_tria_2025.Repository
{
    public class ItemRepository
    {
        private readonly AppDbContext _context;
        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _context.Itens.ToListAsync();
        }

        public async Task<Item> GetByIdAsync(int id)
        {
            return await _context.Itens.FindAsync(id);
        }

        public async Task AddAsync(Item item)
        {
            _context.Itens.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Item item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(Item item)
        {
            _context.Itens.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> GetByNomeAsync(string nome)
        {
            return await _context.Itens.Where(p => p.Nome.ToLower().Contains(nome.ToLower())).ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetByCategoriaAsync(string categoria)
        {
            return await _context.Itens.Where(p => p.Categoria.ToLower().Contains(categoria.ToLower())).ToListAsync();

        }


        public async Task<IEnumerable<Endereco>> FiltrarAsync(string cidade)
        {

            return await _context.Enderecos
                .Where(p => p.Cidade.Contains(cidade)).ToListAsync();
        }
    }
}
