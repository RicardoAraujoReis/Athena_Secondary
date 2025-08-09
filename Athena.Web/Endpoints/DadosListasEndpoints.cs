namespace Athena.Web.Endpoints;

public static class DadosListasEndpoints
{
    public const string Create = "api/DadosListas/add";
    public const string Update = "api/DadosListas/update";
    public const string Delete = "api/DadosListas/delete?";
    public const string GetAll = "api/DadosListas/getall";
    public const string GetById = "api/DadosListas/getbyid";    

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
