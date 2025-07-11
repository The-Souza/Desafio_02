namespace Desafio_02;

public class Program
{
    public static void Main(string[] args)
    {
        DataBaseManager dbManager = new();
        int numRows = 100;

        //dbManager.CreateTable();
        dbManager.InsertData(numRows);
        dbManager.ConsultData();
        //dbManager.DeleteTable();
    }
}