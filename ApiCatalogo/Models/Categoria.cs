using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCatalogo.Models;

[Table("Caregorias")]
public class Categoria
{

    public Categoria()
    {
        Produtos = new Collection<Produto>();
    }

    [Key]
    public int CategoriaId { get; set; }

    [Required]
    [StringLength(80)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(300)]
    public string ImageUrl { get; set; } = string.Empty;

    public ICollection<Produto>? Produtos { get; set; }

}