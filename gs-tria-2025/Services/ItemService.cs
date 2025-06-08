using gs_tria_2025.Models;
using gs_tria_2025.Repository;
using gs_tria_2025.Validations;

namespace gs_tria_2025.Services
{
    public class ItemService
    {
        private readonly ItemRepository _itemRepository;

        // Construtor com injeção de dependência do repositório de item
        public ItemService(ItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _itemRepository.GetAllAsync();
        }

        public async Task<Item?> GetByIdAsync(int id)
        {
            return await _itemRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Item item)
        {
            
            ItemValidation.ValidarCamposObrigatorios(item);
            await _itemRepository.AddAsync(item);
        }

        public async Task UpdateAsync(Item item)
        {
            var existente = await _itemRepository.GetByIdAsync(item.Id);
            ItemValidation.ValidarItemExistenteParaAtualizacao(existente);
            existente.Nome = item.Nome;
            existente.Categoria = item.Categoria;

            await _itemRepository.UpdateAsync(existente);
        }

        public async Task DeleteAsync(Item item)
        {
            var existente = await _itemRepository.GetByIdAsync(item.Id);
            ItemValidation.ValidarItemExistenteParaExclusao(existente);
            await _itemRepository.DeleteAsync(item);
        }

        public async Task<IEnumerable<Item>> GetByNomeAsync(string nome)
        {
            return await _itemRepository.GetByNomeAsync(nome);
        }

        public async Task<IEnumerable<Item>> GetByCategoriaAsync(string categoria)
        {
            return await _itemRepository.GetByCategoriaAsync(categoria);
        }
    }
}
