namespace Common.Requests;

public class CreateUsuLhn {
    public int Uln_usu_identi { get; set; }
    public int Uln_lhn_identi { get; set; }
    public String Uln_usubdd { get; set; }
    public int Uln_usucri { get; set; }
    public int? Uln_usualt { get; set; }
    public DateTime Uln_datcri { get; set; }
    public DateTime? Uln_datalt { get; set; }
};

public class UpdateUsuLhn {
    public int Id { get; set; }
    public int Uln_usu_identi { get; set; }
    public int Uln_lhn_identi { get; set; }
    public String Uln_usubdd { get; set; }
    public int Uln_usucri { get; set; }
    public int? Uln_usualt { get; set; }
    public DateTime Uln_datcri { get; set; }
    public DateTime? Uln_datalt { get; set; }
};