namespace Biblioteca.Models;

public class Livros
{
    public int LivroId { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Categoria { get; set; }
    public int AnoPublicacao { get; set; }
    public string Editora { get; set; }
    public string ISBN { get; set; }
    public bool Disponivel { get; set; }
    
    public Livros()
    {
        // Construtor padrão necessário para a serialização JSON
    }
    public Livros(int LivroId, string titulo, string autor, string categoria, int anoPublicacao, string editora, string isbn, bool disponivel)
    {
        LivroId = LivroId;
        Titulo = titulo;
        Autor = autor;
        Categoria = categoria;
        AnoPublicacao = anoPublicacao;
        Editora = editora;
        ISBN = isbn;
        Disponivel = disponivel;
    }
    
    public void CadastrarLivro(int livroId, string titulo, string autor, string categoria, int anoPublicacao, string editora, string isbn, bool disponivel)
    {
        LivroId = livroId;
        Titulo = titulo;
        Autor = autor;
        Categoria = categoria;
        AnoPublicacao = anoPublicacao;
        Editora = editora;
        ISBN = isbn;
        Disponivel = disponivel;
    }
    
    
    public Livros ObterLivro(int livroId)
    {
        if (LivroId == livroId)
        {
            return this;
        }
        return null; // Retorna null se o livro não for encontrado
    }
    
}