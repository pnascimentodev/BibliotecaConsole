using Biblioteca.Data;
using Biblioteca.Models;

namespace Biblioteca.Controllers;

public class UsuariosController
{
    private Usuarios _usuarios;
    private readonly UsuarioRepositorio _usuariosRepositorio;
    
    public UsuariosController()
    {
        _usuarios = new Usuarios();
        _usuariosRepositorio = new UsuarioRepositorio();
    }
    
    public void CadastrarUsuario()
    {
        Console.WriteLine("Digite o nome do usuário:");
        _usuarios.nome = Console.ReadLine();
        
        Console.WriteLine("Digite o email do usuário:");
        _usuarios.email = Console.ReadLine();

        Console.WriteLine("Digite o telefone do usuário:");
        _usuarios.telefone = Console.ReadLine();
        
        Console.WriteLine("Digite o endereço do usuário:");
        _usuarios.endereco = Console.ReadLine();
        
        _usuariosRepositorio.CadastrarUsuario(_usuarios);
        Console.WriteLine("Usuário cadastrado com sucesso!");

    }
    
    public void ListarUsuarios()
    {
        var usuarios = _usuariosRepositorio.ObterUsuarios();
        if (usuarios.Count == 0)
        {
            Console.WriteLine("Nenhum usuário cadastrado.");
            return;
        }
        
        Console.WriteLine("Lista de Usuários:");
        foreach (var usuario in usuarios)
        {
            Console.WriteLine($"ID: {usuario.usuarioId}, Nome: {usuario.nome}, Email: {usuario.email}, Telefone: {usuario.telefone}, Endereço: {usuario.endereco}");
        }
    }
    
    
}