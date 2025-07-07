namespace Biblioteca.Views;

public class BibliotecaView
{
    public int ExibirMenuPrincipal()
    {
        Console.WriteLine("===================================");
        Console.WriteLine(" BEM-VINDO A NOSSA BIBLIOTECA ");
        Console.WriteLine("===================================");
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1 - Cadastrar Usuário");
        Console.WriteLine("2 - Consultar Usuário");
        Console.WriteLine("3 - Cadastrar Livro");
        Console.WriteLine("4 - Consultar Livro");
        Console.WriteLine("5 - Realizar Empréstimo");
        Console.WriteLine("6 - Realizar Devolução");
        Console.WriteLine("7 - Consultar Empréstimo");
        Console.WriteLine("8 - Sair");

       
        return int .Parse(Console.ReadLine());
    }
}