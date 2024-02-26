using System.Collections.ObjectModel;
namespace ApiCatalogo.Models;

public class Categoria
{

    public Categoria()
    {
        Produtos = new Collection<Produto>();
    }
    public int CategoriaId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;

    public ICollection<Produto>? Produtos { get; set; }

}