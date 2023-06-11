using AppMvcBasica.Models;
using Business.Interfaces;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class ProdutoReposityory : Repository<Produto>, IProdutoRepository
    {
        public ProdutoReposityory(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await _appDbContext.Produtos.AsNoTracking()
                .Include(f => f.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await _appDbContext.Produtos.AsNoTracking()
                .Include(f => f.Fornecedor)
                .OrderBy(p => p.Nome)
                .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }
    }
}
