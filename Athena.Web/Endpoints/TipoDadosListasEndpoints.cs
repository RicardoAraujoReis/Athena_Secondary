namespace Athena.Web.Endpoints;

public static class TipoDadosListasEndpoints
{
    public const string Create = "api/TipoDadosListas/add";
    public const string Update = "api/TipoDadosListas/update";
    public const string Delete = "api/TipoDadosListas/delete?";
    public const string GetAll = "api/TipoDadosListas/getall";
    public const string GetById = "api/TipoDadosListas/getbyid?";

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
