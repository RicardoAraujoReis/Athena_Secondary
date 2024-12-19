namespace Athena.Web.Endpoints;

public static class FuncaoEndpoints
{
    public const string Create = "api/funcao/add";
    public const string Update = "api/funcao/update";
    public const string Delete = "api/funcao/delete?";
    public const string GetAll = "api/funcao/getall";
    public const string GetById = "api/funcao/getbyid";
    public const string GetByStatus = "api/funcao/getbystatus";
    public const string GetByParameters = "api/funcao/getbyparameters";
    public const string GetByDescription = "api/funcao/getbydescription?description=";

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
