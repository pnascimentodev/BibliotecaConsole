using Biblioteca.Data;
using Biblioteca.Models;

namespace Biblioteca.Controllers;

public class EmprestimoController
{
    private readonly EmprestimoRepositorio _emprestimoRepositorio;
    private readonly LivrosRepositorio _livrosRepositorio;
    private readonly UsuarioRepositorio _usuarioRepositorio;
    private Emprestimo _emprestimo;

    public EmprestimoController()
    {
        _emprestimo = new Emprestimo();
        _emprestimoRepositorio = new EmprestimoRepositorio();
        _livrosRepositorio = new LivrosRepositorio();
        _usuarioRepositorio = new UsuarioRepositorio();
    }

public void RegistrarEmprestimo(Emprestimo emprestimo, int usuarioId, int livroId)
    {
        var usuario = _usuarioRepositorio.ObterUsuarios().FirstOrDefault(u => u.usuarioId == usuarioId);
        var livro = _livrosRepositorio.ObterLivros().FirstOrDefault(l => l.LivroId == livroId);

        if (usuario == null)
        {
            Console.WriteLine("Usuário não encontrado.");
            return;
        }

        if (livro == null)
        {
            Console.WriteLine("Livro não encontrado.");
            return;
        }

        if (emprestimo == null)
            emprestimo = new Emprestimo();

        emprestimo.usuarioId = usuario.usuarioId;
        emprestimo.livroId = livro.LivroId;
        emprestimo.dataEmprestimo = DateTime.Now;

        if (emprestimo.dataDevolucao == null)
        {
            Console.WriteLine("Digite a data prevista de devolução (formato: dd/MM/yyyy):");
            string input = Console.ReadLine();
            if (DateTime.TryParse(input, out DateTime dataPrevista))
            {
                emprestimo.dataDevolucao = dataPrevista;
            }
            else
            {
                Console.WriteLine("Data inválida. O campo ficará em branco.");
            }
        }

        _emprestimoRepositorio.RegistrarEmprestimo(emprestimo);
        Console.WriteLine("Empréstimo registrado com sucesso!");
    }
    
    public void RegistrarDevolucao(int emprestimoId)
    {
        var emprestimos = _emprestimoRepositorio.ObterEmprestimos();
        var emprestimo = emprestimos.FirstOrDefault(e => e.emprestimoId == emprestimoId);
        
        if (emprestimo != null)
        {
            emprestimo.dataDevolucao = DateTime.Now;
            _emprestimoRepositorio.registrarDevolucao(emprestimo);
            Console.WriteLine("Devolução registrada com sucesso!");
        }
        else
        {
            Console.WriteLine("Empréstimo não encontrado.");
        }
    }
 
    
    public void ListarEmprestimos()
    {
        var emprestimos = _emprestimoRepositorio.ObterEmprestimos();
        if (emprestimos.Count == 0)
        {
            Console.WriteLine("Nenhum empréstimo registrado.");
            return;
        }

        var usuarios = _usuarioRepositorio.ObterUsuarios();
        var livros = _livrosRepositorio.ObterLivros();

        Console.WriteLine("Lista de Empréstimos:");
        foreach (var emprestimo in emprestimos)
        {
            var usuario = usuarios.FirstOrDefault(u => u.usuarioId == emprestimo.usuarioId);
            var livro = livros.FirstOrDefault(l => l.LivroId == emprestimo.livroId);
            
            string nomeUsuario = usuario != null ? usuario.nome : "Usuário não encontrado";
            string tituloLivro = livro != null ? livro.Titulo : "Livro não encontrado";
            
            Console.WriteLine($"ID: {emprestimo.emprestimoId}, " +
                             $"Usuário: {nomeUsuario} (ID: {emprestimo.usuarioId}), " +
                             $"Livro: {tituloLivro} (ID: {emprestimo.livroId}), " +
                             $"Data de Empréstimo: {emprestimo.dataEmprestimo}, " +
                             $"Data de Devolução: {emprestimo.dataDevolucao}");
        }
    }
    
}