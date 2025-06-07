using gs_tria_2025.DTOs;
using gs_tria_2025.Models;
using gs_tria_2025.Repository;
using gs_tria_2025.Validations;

namespace gs_tria_2025.Services
{
    public class EstoqueItemService
    {
        private readonly EstoqueItemRepository _estoqueItemRepository;
        private readonly ItemRepository _itemRepository;
        private readonly PontoDistribuicaoRepository _pontoRepository;

        public EstoqueItemService(
            EstoqueItemRepository estoqueItemRepository,
            ItemRepository itemRepository,
            PontoDistribuicaoRepository pontoRepository)
        {
            _estoqueItemRepository = estoqueItemRepository;
            _itemRepository = itemRepository;
            _pontoRepository = pontoRepository;
        }

        public async Task<IEnumerable<EstoqueItem>> GetAllAsync()
        {
            return await _estoqueItemRepository.GetAllAsync();
        }

        public async Task<EstoqueItem?> GetByIdAsync(int id)
        {
            return await _estoqueItemRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(EstoqueItemDTO dto)
        {
            var item = await _itemRepository.GetByIdAsync(dto.IdItem);
            EstoqueItemValidation.ValidarExistenciaItem(item);

            var ponto = await _pontoRepository.GetByIdAsync(dto.IdPontoDistribuicao);
            EstoqueItemValidation.ValidarExistenciaPonto(ponto);

            

            var estoque = new EstoqueItem
            {
                Quantidade = dto.Quantidade,
                IdItem = dto.IdItem,
                IdPontoDistribuicao = dto.IdPontoDistribuicao,
                DataAtualizacao = DateTime.UtcNow
            };

            EstoqueItemValidation.ValidarEstoque(dto);


            await _estoqueItemRepository.AddAsync(estoque);
        }

        public async Task UpdateAsync(int id, EstoqueItemDTO dto)
        {
            var estoque = await _estoqueItemRepository.GetByIdAsync(id);
            EstoqueItemValidation.ValidarExistenciaEstoque(estoque);

            var item = await _itemRepository.GetByIdAsync(dto.IdItem);
            EstoqueItemValidation.ValidarExistenciaItem(item);

            var ponto = await _pontoRepository.GetByIdAsync(dto.IdPontoDistribuicao);
            EstoqueItemValidation.ValidarExistenciaPonto(ponto);

            EstoqueItemValidation.ValidarEstoque(dto);

            estoque.Quantidade = dto.Quantidade;
            estoque.IdItem = dto.IdItem;
            estoque.IdPontoDistribuicao = dto.IdPontoDistribuicao;
            estoque.DataAtualizacao = DateTime.UtcNow;

            await _estoqueItemRepository.UpdateAsync(estoque);
        }

        public async Task DeleteAsync(int id)
        {
            var estoque = await _estoqueItemRepository.GetByIdAsync(id);
            EstoqueItemValidation.ValidarExistenciaEstoque(estoque);

            await _estoqueItemRepository.DeleteAsync(estoque);
        }

        public async Task<IEnumerable<EstoqueItem>> GetByItemAsync(int idItem)
        {
            return await _estoqueItemRepository.GetByItemAsync(idItem);
        }

        public async Task<IEnumerable<EstoqueItem>> GetByPontoDistribuicaoAsync(int idPonto)
        {
            return await _estoqueItemRepository.GetByPontoAsync(idPonto);
        }
    }
}
