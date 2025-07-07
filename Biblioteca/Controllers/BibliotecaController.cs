using Biblioteca.Data;
using Biblioteca.Models;
using Biblioteca.Views;

namespace Biblioteca.Controllers;

public class BibliotecaController
{   
    private readonly BibliotecaView _bibliotecaView;
    private readonly LivrosRepositorio _livrosRepositorio;
    private readonly LivroController _livrosController;
    private readonly UsuariosController _usuariosController;
    private readonly UsuarioRepositorio _usuarioRepositorio;
    private readonly EmprestimoRepositorio _emprestimoRepositorio;
    private readonly EmprestimoController _emprestimoController;
    
    public BibliotecaController()
    {
        _bibliotecaView = new BibliotecaView();
        _livrosRepositorio = new LivrosRepositorio();
        _livrosController = new LivroController();
        _usuariosController = new UsuariosController();
        _usuarioRepositorio = new UsuarioRepositorio();
        _emprestimoRepositorio = new EmprestimoRepositorio();
        _emprestimoController = new EmprestimoController();
    }
    
    public void Iniciar()
    {
        while (true)
        {
            var opcao = _bibliotecaView.ExibirMenuPrincipal().ToString();

            switch (opcao)
            {
                case "1":
                    _usuariosController.CadastrarUsuario();
                    break;
                case "2":
                    _usuariosController.ListarUsuarios();
                    break;
                case "3":
                    _livrosController.CadastrarLivro();
                    break;
                case "4":
                    _livrosController.ListarLivros();
                    break;
                case "5":
                    RealizarEmprestimo();
                    break;
                case "6":
                    RealizarDevolucao();
                    break;
                case "7":
                    _emprestimoController.ListarEmprestimos();
                    break;
                case "8":
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
    
    private void RealizarEmprestimo()
    {
        Console.WriteLine("=== Realizar Empréstimo ===");
        Console.WriteLine("Digite o ID do usuário:");
        
        if (int.TryParse(Console.ReadLine(), out int usuarioId))
        {
            Console.WriteLine("Digite o ID do livro:");
            
            if (int.TryParse(Console.ReadLine(), out int livroId))
            {
                _emprestimoController.RegistrarEmprestimo(new Emprestimo(), usuarioId, livroId);
            }
            else
            {
                Console.WriteLine("ID do livro inválido. Operação cancelada.");
            }
        }
        else
        {
            Console.WriteLine("ID do usuário inválido. Operação cancelada.");
        }
    }
    
    private void RealizarDevolucao()
    {
        Console.WriteLine("=== Realizar Devolução ===");
        Console.WriteLine("Digite o ID do empréstimo que deseja devolver:");
        
        if (int.TryParse(Console.ReadLine(), out int emprestimoId))
        {
            _emprestimoController.RegistrarDevolucao(emprestimoId);
        }
        else
        {
            Console.WriteLine("ID inválido. Operação cancelada.");
        }
    }
}
