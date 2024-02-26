namespace ApiCatalogo.Models;

public class Produto
{
    public int ProdutoId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public float Estoque { get; set; }
    public DateTime DataCadastro { get; set; }

    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }

}