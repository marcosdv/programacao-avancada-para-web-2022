using System.ComponentModel.DataAnnotations;

namespace MeusLivros.Website.Models;

public class LivroViewModel
{
    public int? Id { get; set; }

    [Display(Name = "Nome")]
    [Required(ErrorMessage = "O campo nome é obrigatório")]
    public string Nome { get; set; }

    [Display(Name = "Editora")]
    [Required(ErrorMessage = "O campo editora é obrigatório")]
    public int EditoraId { get; set; }
}