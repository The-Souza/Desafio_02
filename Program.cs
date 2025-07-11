namespace Desafio_02;

public class Program
{
    public static void Main(string[] args)
    {
        DataBaseManager dbManager = new();
        int numRows = 100;

        //dbManager.CriarTabela();
        dbManager.InserirDados(numRows);
        dbManager.ConsultarDados();
    }
}