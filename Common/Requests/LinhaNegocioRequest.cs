namespace Common.Requests;

public class CreateLinhaNegocio 
{         
    public string Lhn_descri { get; set; }
    public string Lhn_ativo { get; set; }
    public string Lhn_usubdd { get; set; }
    public int Lhn_usucri { get; set; }
    public int? Lhn_usualt { get; set; }
    public DateTime Lhn_datcri { get; set; }
    public DateTime? Lhn_datalt { get; set; }
};

public class UpdateLinhaNegocio
{
    public int Id { get; set; }
    public string Lhn_descri { get; set; }
    public string Lhn_ativo { get; set; }
    public string Lhn_usubdd { get; set; }
    public int Lhn_usucri { get; set; }
    public int? Lhn_usualt { get; set; }
    public DateTime Lhn_datcri { get; set; }
    public DateTime? Lhn_datalt { get; set; }
};