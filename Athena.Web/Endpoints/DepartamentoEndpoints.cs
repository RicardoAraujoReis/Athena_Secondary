namespace Athena.Web.Endpoints;

public static class DepartamentoEndpoints
{
    public const string Create = "api/departamento/add";
    public const string Update = "api/departamento/update";
    public const string Delete = "api/departamento/delete?";
    public const string GetAll = "api/departamento/getall";
    public const string GetById = "api/departamento/getbyid";
    public const string GetByStatus = "api/departamento/getbystatus";
    public const string GetByParameters = "api/departamento/getbyparameters";
    public const string GetByDescription = "api/departamento/getbydescription?description=";

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
