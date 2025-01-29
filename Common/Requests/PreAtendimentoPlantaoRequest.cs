namespace Common.Requests;

public class CreatePreAtendimentoPlantao {
    public DateTime Ptd_datptd { get; set; }
    public int Ptd_usu_identi { get; set; }
    public int Ptd_cli_identi { get; set; }
    public String Ptd_tipptd { get; set; }
    public String Ptd_critic { get; set; }
    public String Ptd_resumo { get; set; }
    public String? Ptd_numcha { get; set; }
    public String? Ptd_jirarl { get; set; }
    public String? Ptd_numjir { get; set; }
    public String? Ptd_diagn1 { get; set; }
    public String Ptd_status { get; set; }
    public String? Ptd_reton2 { get; set; }
    public String? Ptd_observ { get; set; }
    public String Ptd_nomal1 { get; set; }
    public int? Ptd_numatd { get; set; }
    public String Ptd_usubdd { get; set; }
    public DateTime Ptd_datcri { get; set; }
    public DateTime? Ptd_datalt { get; set; }
    public int Ptd_usucri { get; set; }
    public int? Ptd_usualt { get; set; }
};

public class UpdatePreAtendimentoPlantao {
    public int Id { get; set; }
    public DateTime Ptd_datptd { get; set; }
    public int Ptd_usu_identi { get; set; }
    public int Ptd_cli_identi { get; set; }
    public String Ptd_tipptd { get; set; }
    public String Ptd_critic { get; set; }
    public String Ptd_resumo { get; set; }
    public String? Ptd_numcha { get; set; }
    public String Ptd_jirarl { get; set; }
    public String? Ptd_numjir { get; set; }
    public String? Ptd_diagn1 { get; set; }
    public String Ptd_status { get; set; }
    public String? Ptd_reton2 { get; set; }
    public String? Ptd_observ { get; set; }
    public String Ptd_nomal1 { get; set; }
    public int? Ptd_numatd { get; set; }
    public String Ptd_usubdd { get; set; }
    public DateTime Ptd_datcri { get; set; }
    public DateTime? Ptd_datalt { get; set; }
    public int Ptd_usucri { get; set; }
    public int? Ptd_usualt { get; set; }
};