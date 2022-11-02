using System.ComponentModel.DataAnnotations;

namespace MeusLivros.Website.Models;

public class EditoraViewModel
{
    public int? Id { get; set; }

    [Display(Name = "Nome")]
    [Required(ErrorMessage = "O campo nome é obrigatório")]
    public string Nome { get; set; }
}