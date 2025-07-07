namespace Biblioteca.Models;

public class Usuarios
{
    public int usuarioId { get; set; }
    public string nome { get; set; }
    public string email { get; set; }
    public string telefone { get; set; }
    public string endereco { get; set; }

    public Usuarios()
    {
        // Construtor padrão necessário para a serialização JSON
    }
    
    public Usuarios(int usuarioId, string nome, string email, string telefone, string endereco)
    {
        usuarioId = usuarioId;
        nome = nome;
        email = email;
        telefone = telefone;
        endereco = endereco;
    }
    
    public void CadastrarUsuario(int usuarioId, string nome, string email, string telefone, string endereco)
    {
        this.usuarioId = usuarioId;
        this.nome = nome;
        this.email = email;
        this.telefone = telefone;
        this.endereco = endereco;
    }

    public Usuarios ObterUsuario(int usuarioId)
    {
        if (this.usuarioId == usuarioId)
        {
            return this;
        }
        return null;
    }
    
}