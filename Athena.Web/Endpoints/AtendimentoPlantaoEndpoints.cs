namespace Athena.Web.Endpoints;

public static class AtendimentoPlantaoEndpoints
{
    public const string Create = "api/AtendimentoPlantao/add";
    public const string Update = "api/AtendimentoPlantao/update";
    public const string Delete = "api/AtendimentoPlantao/delete?";
    public const string GetAll = "api/AtendimentoPlantao/getall";
    public const string GetById = "api/AtendimentoPlantao/getbyid?";
    public const string GetByParameters = "api/AtendimentoPlantao/getbyparameters";

    public static string BuildEndpoints(string baseEndpoint, int id = 0, string parameter = "")
    {
        if (id > 0)
        {
            return $"{baseEndpoint}id={id}";
        }

        if (!string.IsNullOrWhiteSpace(parameter))
        {
            return $"{baseEndpoint}/{parameter}";
        }

        return baseEndpoint;
    }
}