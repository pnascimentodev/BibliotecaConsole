using Biblioteca.Models;

namespace Biblioteca.Data;

public class LivrosRepositorio
{
    private const string arquivoLivros = "livros.json";
    private string path = arquivoLivros;

    public LivrosRepositorio()
    {
        if (!File.Exists(path))
        {
            // Inicializa com uma lista vazia em JSON
            File.WriteAllText(path, "[]");
        }
    }

    public void CadastrarLivro(Livros livro)
    {
        var livros = ObterLivros();
        livros.Add(livro);
        SalvarLivros(livros);
    }
    
    public List<Livros> ObterLivros()
    {
        if (!File.Exists(path))
        {
            return new List<Livros>();
        }
        
        var json = File.ReadAllText(path);
        
        // Verifica se o arquivo está vazio
        if (string.IsNullOrWhiteSpace(json))
        {
            return new List<Livros>();
        }
        
        return System.Text.Json.JsonSerializer.Deserialize<List<Livros>>(json) ?? new List<Livros>();
    }
    
    public void SalvarLivros(List<Livros> livros)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(livros);
        File.WriteAllText(path, json);
    }
}