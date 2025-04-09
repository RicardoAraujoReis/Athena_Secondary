using MudBlazor;
using static MudBlazor.CategoryTypes;
using static MudBlazor.Colors;
using System.Reflection.Emit;
using Common.Responses;

namespace Athena.Web.Pages;

public partial class Index
{
    private int _index = -1; //default value cannot be 0 -> first selectedindex is 0.
    private string _width = "500px";
    private string _height = "350px";
    private ChartOptions _axisChartOptions = new ChartOptions();

    private List<ChartSeries> _series = new List<ChartSeries>()
    {
        new ChartSeries() { Name = "United States", Data = new double[] { 40, 20, 25, 27, 46, 60, 48, 80, 15 } },
        new ChartSeries() { Name = "Germany", Data = new double[] { 19, 24, 35, 13, 28, 15, 13, 16, 31 } },
        new ChartSeries() { Name = "Sweden", Data = new double[] { 8, 6, 11, 13, 4, 16, 10, 16, 18 } },
    };
    private string[] _xAxisLabels = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep" };
    
    private List<PainelGeralBigNumbersResponse> PainelGeralBigNumbersResponse { get; set; } = new List<PainelGeralBigNumbersResponse>();

    protected override async Task OnInitializedAsync()
    {
        var response = await _painelBigNumberServices.GetPainelGeralBigNumbersAllAsync();

        if (response.IsSuccessful)
        {
            PainelGeralBigNumbersResponse = response.Data;
        }
        else
        {
            _snackbar.Add("Falha ao buscar os dados dos BigNumbers", Severity.Error);
        }        
    }
}
