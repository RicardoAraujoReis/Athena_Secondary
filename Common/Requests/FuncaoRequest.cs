namespace Common.Requests;

public class CreateFuncao {
    public string Fnc_descri { get; set; }
    public string Fnc_ativo { get; set; }
    public string Fnc_usubdd { get; set; }
    public int Fnc_usucri { get; set; }
    public int? Fnc_usualt { get; set; }
    public DateTime Fnc_datcri { get; set; }
    public DateTime? Fnc_datalt { get; set; }
};

public class UpdateFuncao {
    public int Id { get; set; }
    public string Fnc_descri { get; set; }
    public string Fnc_ativo { get; set; }
    public string Fnc_usubdd { get; set; }
    public int Fnc_usucri { get; set; }
    public int? Fnc_usualt { get; set; }
    public DateTime Fnc_datcri { get; set; }
    public DateTime? Fnc_datalt { get; set; }
};