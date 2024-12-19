namespace Athena.Web.Endpoints;

public static class ClienteEndpoints
{
    public const string Create = "api/cliente/add";
    public const string Update = "api/cliente/update";
    public const string Delete = "api/cliente/delete?";
    public const string GetAll = "api/cliente/getall";
    public const string GetById = "api/cliente/getbyid";
    public const string GetByStatus = "api/cliente/getbystatus";
    public const string GetByParameters = "api/cliente/getbyparameters";
    public const string GetByDescription = "api/cliente/getbydescription?description=";

    public static string BuildEndpoints(string baseEndpoint,int id=0, string parameter="")
    {
        if(id > 0)
        {
            return $"{baseEndpoint}id={id}";
        }
        
        if(!string.IsNullOrWhiteSpace(parameter))
        {
            return $"{baseEndpoint}/{parameter}";
        }
        return baseEndpoint;
    }
}
