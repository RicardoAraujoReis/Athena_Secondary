using MudBlazor;
using Common.Responses.PainelGeral;
using Athena.Web.PainelGeral.Models;
using Microsoft.JSInterop;

namespace Athena.Web.Pages;

public partial class Index
{
    private int _index = -1;
    private string _width = "800px";
    private string _height = "650px";

    private List<ChartSeries> _series = new List<ChartSeries>();
    private string[] _labels = null;


    private List<PainelGeralBigNumbersResponse> PainelGeralBigNumbersResponse { get; set; } = new List<PainelGeralBigNumbersResponse>();
    private List<PainelGeralGraficosResponse> PainelGeralGraficosResponse { get; set; } = new List<PainelGeralGraficosResponse>();

    private bool _renderChart = false;

    protected override async Task OnInitializedAsync()
    {
        var responseBigNumbers = await _painelBigNumberServices.GetPainelGeralBigNumbersAllAsync();

        if (responseBigNumbers.IsSuccessful)
        {
            PainelGeralBigNumbersResponse = responseBigNumbers.Data;
        }
        else
        {
            _snackbar.Add("Falha ao buscar os dados dos BigNumbers", Severity.Error);
        }        
    }    
}



/* TRECHO COMENTADO, REFERENTE AOS GRAFICOS DO PAINEL GERAL
     * 
     var responseGraficos = await _painelGraficosServices.GetPainelGeralGraficosAllAsync();

        if (responseGraficos.IsSuccessful)
        {
            PainelGeralGraficosResponse = responseGraficos.Data;
            //MontarGraficos3();
            //MontarGraficosApex();
        }

    private async Task MontarGraficos()
    {
        var groupedData = PainelGeralGraficosResponse
        .GroupBy(x => x.NomeCliente)
        .Select(g => new
        {
            NomeCliente = g.Key,
            QuantidadeTotal = g.Sum(x => x.Quantidade)
        });

        // Define os rótulos do eixo X (nomes dos clientes)
        _labels = groupedData.Select(g => g.NomeCliente).ToArray();

        // Cria uma série com os totais por cliente        
        _series.Add(new ChartSeries
        {
            Name = "Total por Cliente",
            Data = groupedData.Select(x => (double)x.QuantidadeTotal).ToArray()
        });
    }

    private void MontarGraficos3()
    {
        var groupedData = PainelGeralGraficosResponse
            .GroupBy(x => x.NomeCliente);

        _labels = groupedData.Select(g => g.Key).ToArray();

        foreach (var item in PainelGeralGraficosResponse)
        {
            var chart = new ChartSeries
            {
                Name = item.NomeCliente,
                Data = new double[] { item.Quantidade }
            };
            _series.Add(chart);
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _renderChart = true;
            StateHasChanged();
            await Task.Yield();

            var labels = new[] { "January", "February", "March", "April" };
            var data = new[] { 10, 20, 15, 25 };

            await JSRuntime.InvokeVoidAsync(
                "renderBarChart",
                "barChart",
                labels,
                data,
                "Monthly Sales"
            );


            //try
            //{
            //    await JSRuntime.InvokeVoidAsync(
            //        "renderBarChart",
            //        "barChart",
            //        labels,
            //        data,
            //        "Monthly Sales"
            //    );
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Erro ao chamar renderBarChart: {ex.Message}");
            //}
            //;
        }
    }
    */