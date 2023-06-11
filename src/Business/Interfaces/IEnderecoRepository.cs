using AppMvcBasica.Models;

namespace Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid forncedorId);
    }
}
