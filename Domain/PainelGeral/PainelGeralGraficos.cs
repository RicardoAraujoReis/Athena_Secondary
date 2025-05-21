using Athena.Models;
using Models.Interfaces;

namespace Models.PainelGeral;

public class PainelGeralGraficos : BaseEntity<int>
{
    public string NomeCliente { get; set; }
    public int Quantidade { get; set; }
    public int Mes { get; set; }
    public int Ano { get; set; }    

    public PainelGeralGraficos UpdatePainelGeralGraficos(string nomeCliente, int quantidade, int mes, int ano)
    {
        NomeCliente = nomeCliente;
        Quantidade = quantidade;
        Mes = mes;
        Ano = ano;

        return this;
    }
}
