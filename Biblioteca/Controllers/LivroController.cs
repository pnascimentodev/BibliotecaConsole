using Biblioteca.Data;
using Biblioteca.Models;

namespace Biblioteca.Controllers;

public class LivroController
{
    private Livros _livro;
    private readonly LivrosRepositorio _livrosRepositorio;

    public LivroController()
    {
        _livro = new Livros();
        _livrosRepositorio = new LivrosRepositorio();
        
    }
    
    public void CadastrarLivro()
    {
        Console.WriteLine("Digite o título do livro:");
        _livro.Titulo = Console.ReadLine();
        
        Console.WriteLine("Digite o autor do livro:");
        _livro.Autor = Console.ReadLine();
        
        Console.WriteLine("Digite o ano de publicação do livro:");
        _livro.AnoPublicacao = int.Parse(Console.ReadLine() ?? "0");
        
        _livrosRepositorio.CadastrarLivro(_livro);
        
        Console.WriteLine("Livro cadastrado com sucesso!");
    }
    public void ListarLivros()
    {
        var livros = _livrosRepositorio.ObterLivros();
        if (livros.Count == 0)
        {
            Console.WriteLine("Nenhum livro cadastrado.");
            return;
        }
        
        Console.WriteLine("Lista de Livros:");
        foreach (var livro in livros)
        {
            Console.WriteLine($"ID: {livro.LivroId}, Título: {livro.Titulo}, Autor: {livro.Autor}, Ano de Publicação: {livro.AnoPublicacao}");
        }
    }
    public void ObterLivro(int livroId)
    {
        var livro = _livrosRepositorio.ObterLivros().FirstOrDefault(l => l.LivroId == livroId);
        if (livro != null)
        {
            Console.WriteLine($"ID: {livro.LivroId}, Título: {livro.Titulo}, Autor: {livro.Autor}, Ano de Publicação: {livro.AnoPublicacao}");
        }
        else
        {
            Console.WriteLine("Livro não encontrado.");
        }
    }
    
    
}