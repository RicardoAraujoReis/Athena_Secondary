namespace Athena.Web.Endpoints;

public static class CategoriaAtendimentoEndpoints
{
    public const string Create = "api/categoriaAtendimento/add";
    public const string Update = "api/categoriaAtendimento/update";
    public const string Delete = "api/categoriaAtendimento/delete?";
    public const string GetAll = "api/categoriaAtendimento/getall";
    public const string GetById = "api/categoriaAtendimento/getbyid?";
    public const string GetByStatus = "api/categoriaAtendimento/getbystatus";
    public const string GetByParameters = "api/categoriaAtendimento/getbyparameters";
    public const string GetByDescription = "api/categoriaAtendimento/getbydescription?description=";

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
