// Produto.cs (Crie este arquivo no seu projeto C# se ainda não o tiver)
public class Produto
{
    // Corresponde ao 'id' retornado pela API
    public int Id { get; set; } // Use 'int' se o ID for numérico, como em INTEGER PRIMARY KEY
    public string TipoProduto { get; set; }
    public string Tamanho { get; set; }
    public string Genero { get; set; }
    public string Cor { get; set; }
    public decimal Preco { get; set; }
    public int Quantidade { get; set; } // Adicionada a propriedade Quantidade
}