using Biblioteca.Models;

namespace Biblioteca.Data;

public class EmprestimoRepositorio
{
    private const string arquivoEmprestimos = "emprestimos.json";
    private string path = arquivoEmprestimos;
    
    public EmprestimoRepositorio()
    {
        if (!File.Exists(path))
        {
            // Inicializa com uma lista vazia em JSON
            File.WriteAllText(path, "[]");
        }
    }
    
    public void RegistrarEmprestimo(Emprestimo emprestimo)
    {
        var emprestimos = ObterEmprestimos();
        emprestimos.Add(emprestimo);
        SalvarEmprestimos(emprestimos);
    }
    
    public void registrarDevolucao(Emprestimo emprestimo)
    {
        var emprestimos = ObterEmprestimos();
        var emprestimoExistente = emprestimos.FirstOrDefault(e => e.emprestimoId == emprestimo.emprestimoId);
        
        if (emprestimoExistente != null)
        {
            emprestimoExistente.dataDevolucao = emprestimo.dataDevolucao;
            SalvarEmprestimos(emprestimos);
        }
    }

    public List<Emprestimo> ObterEmprestimos()
    {
        if (!File.Exists(path))
        {
            return new List<Emprestimo>();
        }

        var json = File.ReadAllText(path);
        
        // Verifica se o arquivo está vazio
        if (string.IsNullOrWhiteSpace(json))
        {
            return new List<Emprestimo>();
        }
        
        return System.Text.Json.JsonSerializer.Deserialize<List<Emprestimo>>(json) ?? new List<Emprestimo>();
    }
    
    public void SalvarEmprestimos(List<Emprestimo> emprestimos)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(emprestimos);
        File.WriteAllText(path, json);
    }
}