using Biblioteca.Models;

namespace Biblioteca.Data;

public class UsuarioRepositorio
{
    private const string arquivoUsuarios = "usuarios.json";
    private string path = arquivoUsuarios;

    public UsuarioRepositorio()
    {
        if (!File.Exists(path))
        {
            // Cria o arquivo com uma lista vazia válida em JSON
            File.WriteAllText(path, "[]");
        }
    }

    public void CadastrarUsuario(Usuarios usuario)
    {
        var usuarios = ObterUsuarios();
        usuarios.Add(usuario);
        SalvarUsuarios(usuarios);
    }

    public List<Usuarios> ObterUsuarios()
    {
        if (!File.Exists(path))
        {
            return new List<Usuarios>();
        }
        
        var json = File.ReadAllText(path);
        
        // Se o arquivo estiver vazio, retorna uma lista vazia
        if (string.IsNullOrWhiteSpace(json))
        {
            return new List<Usuarios>();
        }
        
        return System.Text.Json.JsonSerializer.Deserialize<List<Usuarios>>(json) ?? new List<Usuarios>();
    }

    public void SalvarUsuarios(List<Usuarios> usuarios)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(usuarios);
        File.WriteAllText(path, json);
    }
}