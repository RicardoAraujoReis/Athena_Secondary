namespace Common.Requests;

public class CreateLinhaNegocio 
{         
    public String Lhn_descri { get; set; }
    public String Lhn_ativo { get; set; }
    public String Lhn_usubdd { get; set; }
    public int Lhn_usucri { get; set; }
    public int? Lhn_usualt { get; set; }
    public DateTime Lhn_datcri { get; set; }
    public DateTime? Lhn_datalt { get; set; }
};

public class UpdateLinhaNegocio
{
    public int Id { get; set; }
    public String Lhn_descri { get; set; }
    public String Lhn_ativo { get; set; }
    public String Lhn_usubdd { get; set; }
    public int Lhn_usucri { get; set; }
    public int? Lhn_usualt { get; set; }
    public DateTime Lhn_datcri { get; set; }
    public DateTime? Lhn_datalt { get; set; }
};