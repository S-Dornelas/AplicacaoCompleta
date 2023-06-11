using AppMvcBasica.Models;
using Business.Interfaces;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid forncedorId)
        {
#pragma warning disable CS8603 // Possível retorno de referência nula.
            return await _appDbContext.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.FornecedorId == forncedorId);
#pragma warning restore CS8603 // Possível retorno de referência nula.
        }
    }
}
