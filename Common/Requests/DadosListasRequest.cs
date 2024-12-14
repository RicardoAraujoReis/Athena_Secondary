namespace Common.Requests;

public class CreateDadosListas {
    public int Dal_tid_identi { get; set; }
    public String Dal_valor { get; set; }
    public String Dal_usubdd { get; set; }
    public DateTime Dal_datcri { get; set; }
    public DateTime? Dal_datalt { get; set; }
    public int Dal_usucri { get; set; }
    public int? Dal_usualt { get; set; }
};

public class UpdateDadosListas {
    public int Id { get; set; }
    public int Dal_tid_identi { get; set; }
    public String Dal_valor { get; set; }
    public String Dal_usubdd { get; set; }
    public DateTime Dal_datcri { get; set; }
    public DateTime? Dal_datalt { get; set; }
    public int Dal_usucri { get; set; }
    public int? Dal_usualt { get; set; }
};