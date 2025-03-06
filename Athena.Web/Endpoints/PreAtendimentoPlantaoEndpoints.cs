namespace Athena.Web.Endpoints;

public static class PreAtendimentoPlantaoEndpoints
{
    public const string Create = "api/PreAtendimentoPlantao/add";
    public const string Update = "api/PreAtendimentoPlantao/update";
    public const string Delete = "api/PreAtendimentoPlantao/delete?";
    public const string GetAll = "api/PreAtendimentoPlantao/getall";
    public const string GetById = "api/PreAtendimentoPlantao/getbyid?";
    public const string GetByParameters = "api/PreAtendimentoPlantao/getbyparameters";

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
