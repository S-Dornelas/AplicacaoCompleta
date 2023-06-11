using AppMvcBasica.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Business.Models;

namespace App.ViewModels
{
    public class FornecedorViewModel
    {
        [Key]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo {0} precisar ter entre {2} e {1} caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "O campo {0} precisar ter entre {2} e {1} caracteres.")]
        public string? Documento { get; set; }

        [DisplayName("Tipo")]
        public TipoFornecedor? TipoFornecedor { get; set; }
        
        public Endereco? Endereco { get; set; }

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }


        public IEnumerable<ProdutoViewModel>? Produtos { get; set; }
    }
}
