namespace Common.Requests;

public class CreateUsuario {
    public string Usu_descri { get; set; }
    public string Usu_login { get; set; }
    public string Usu_senha { get; set; }
    public string Usu_email { get; set; }
    public string Usu_ativo { get; set; }
    public string Usu_status { get; set; }
    public string Usu_master { get; set; }
    public string Usu_tipusu { get; set; }
    public string Usu_usubdd { get; set; }
    public int Usu_usucri { get; set; }
    public int? Usu_usualt { get; set; }
    public DateTime usu_datcri { get; set; }
    public DateTime? usu_datalt { get; set; }
};

public class UpdateUsuario {
    public int Id { get; set; }
    public string Usu_descri { get; set; }
    public string Usu_login { get; set; }
    public string Usu_senha { get; set; }
    public string Usu_email { get; set; }
    public string Usu_ativo { get; set; }
    public string Usu_status { get; set; }
    public string Usu_master { get; set; }
    public string Usu_tipusu { get; set; }
    public string Usu_usubdd { get; set; }
    public int Usu_usucri { get; set; }
    public int? Usu_usualt { get; set; }
    public DateTime Usu_datcri { get; set; }
    public DateTime? Usu_datalt { get; set; }
};