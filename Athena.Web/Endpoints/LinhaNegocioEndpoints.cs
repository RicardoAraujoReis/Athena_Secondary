namespace Athena.Web.Endpoints;

public static class LinhaNegocioEndpoints
{
    public const string Create = "api/linhanegocio/add";
    public const string Update = "api/linhanegocio/update";
    public const string Delete = "api/linhanegocio/delete?";
    public const string GetAll = "api/linhanegocio/getall";
    public const string GetById = "api/linhanegocio/getbyid";
    public const string GetByStatus = "api/linhanegocio/getbystatus";
    public const string GetByParameters = "api/linhanegocio/getbyparameters";
    public const string GetByDescription = "api/linhanegocio/getbydescription?description=";

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
