namespace Common.Requests;

public class CreatePreAtendimentoPlantao {
    public string Ptd_titulo { get; set; }
    public DateTime Ptd_datptd { get; set; }
    public int Ptd_usu_identi { get; set; }
    public int Ptd_cli_identi { get; set; }
    public string Ptd_tipptd { get; set; }
    public string Ptd_critic { get; set; }
    public string Ptd_resumo { get; set; }
    public string? Ptd_numcha { get; set; }
    public string? Ptd_jirarl { get; set; }
    public string? Ptd_numjir { get; set; }
    public string? Ptd_diagn1 { get; set; }
    public string Ptd_status { get; set; }
    public string? Ptd_reton2 { get; set; }
    public string? Ptd_observ { get; set; }
    public string Ptd_nomal1 { get; set; }
    public int? Ptd_numatd { get; set; }
    public string Ptd_usubdd { get; set; }
    public DateTime Ptd_datcri { get; set; }
    public DateTime? Ptd_datalt { get; set; }
    public int Ptd_usucri { get; set; }
    public int? Ptd_usualt { get; set; }
    public string? Ptd_linjir { get; set; }
    public string? Ptd_verjir { get; set; }
};

public class UpdatePreAtendimentoPlantao {
    public int Id { get; set; }
    public string Ptd_titulo { get; set; }
    public DateTime Ptd_datptd { get; set; }
    public int Ptd_usu_identi { get; set; }
    public int Ptd_cli_identi { get; set; }
    public string Ptd_tipptd { get; set; }
    public string Ptd_critic { get; set; }
    public string Ptd_resumo { get; set; }
    public string? Ptd_numcha { get; set; }
    public string Ptd_jirarl { get; set; }
    public string? Ptd_numjir { get; set; }
    public string? Ptd_diagn1 { get; set; }
    public string Ptd_status { get; set; }
    public string? Ptd_reton2 { get; set; }
    public string? Ptd_observ { get; set; }
    public string Ptd_nomal1 { get; set; }
    public int? Ptd_numatd { get; set; }
    public string Ptd_usubdd { get; set; }
    public DateTime Ptd_datcri { get; set; }
    public DateTime? Ptd_datalt { get; set; }
    public int Ptd_usucri { get; set; }
    public int? Ptd_usualt { get; set; }
    public string? Ptd_linjir { get; set; }
    public string? Ptd_verjir { get; set; }
};