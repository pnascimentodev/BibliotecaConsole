namespace Biblioteca.Models;

public class Emprestimo
{
    public int emprestimoId { get; set; }
    public int usuarioId { get; set; }
    public int livroId { get; set; }
    public DateTime? dataEmprestimo { get; set; }
    public DateTime? dataDevolucao { get; set; }
    
    public Emprestimo()
    {
        // Construtor padrão necessário para a serialização JSON
    }
    
    public Emprestimo(int emprestimoId, int usuarioId, int livroId, DateTime dataEmprestimo, DateTime dataDevolucao)
    {
        this.emprestimoId = emprestimoId;
        this.usuarioId = usuarioId;
        this.livroId = livroId;
        this.dataEmprestimo = dataEmprestimo;
        this.dataDevolucao = dataDevolucao;
    }
    
    public void RegistrarEmprestimo(int emprestimoId, int usuarioId, int livroId, DateTime dataEmprestimo, DateTime dataDevolucao)
    {
        this.emprestimoId = emprestimoId;
        this.usuarioId = usuarioId;
        this.livroId = livroId;
        this.dataEmprestimo = dataEmprestimo;
        this.dataDevolucao = dataDevolucao;
    }
    
    public void RegistrarDevolucao(int emprestimoId, DateTime dataDevolucao)
    {
        if (this.emprestimoId == emprestimoId)
        {
            this.dataDevolucao = dataDevolucao;
        }
    }
    
    

}