namespace Common.Requests;

public class CreateDepFunc {
    public int Dfc_dpt_identi { get; set; }
    public int Dfc_fnc_identi { get; set; }
    public int Dfc_usu_identi { get; set; }
    public String Dfc_usubdd { get; set; }
    public int Dfc_usucri { get; set; }
    public int? Dfc_usualt { get; set; }
    public DateTime Dfc_datcri { get; set; }
    public DateTime? Dfc_datalt { get; set; }
};

public class UpdateDepFunc {
    public int Id { get; set; }
    public int Dfc_dpt_identi { get; set; }
    public int Dfc_fnc_identi { get; set; }
    public int Dfc_usu_identi { get; set; }
    public String Dfc_usubdd { get; set; }
    public int Dfc_usucri { get; set; }
    public int? Dfc_usualt { get; set; }
    public DateTime Dfc_datcri { get; set; }
    public DateTime? Dfc_datalt { get; set; }
};