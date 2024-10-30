namespace Common.Requests;

public record CreatePreAtendimentoPlantao(        
    DateTime Ptd_datptd,
    int Ptd_usu_identi,
    int Ptd_cli_identi,
    String Ptd_tipptd,
    String Ptd_critic,
    String Ptd_resumo,
    String Ptd_numcha,
    String Ptd_jirarl,
    String Ptd_numjir,
    String Ptd_diagn1,
    String Ptd_status,
    String Ptd_reton2,
    String Ptd_observ,
    String Ptd_nomal1,
    int Ptd_numatd,
    String Ptd_usubdd,
    DateTime Ptd_datcri,
    DateTime Ptd_datalt,
    int Ptd_usucri,
    int Ptd_usualt
);

public record UpdatePreAtendimentoPlantao(
    int Ptd_identi,
    DateTime Ptd_datptd,
    int Ptd_usu_identi,
    int Ptd_cli_identi,
    String Ptd_tipptd,
    String Ptd_critic,
    String Ptd_resumo,
    String Ptd_numcha,
    String Ptd_jirarl,
    String Ptd_numjir,
    String Ptd_diagn1,
    String Ptd_status,
    String Ptd_reton2,
    String Ptd_observ,
    String Ptd_nomal1,
    int Ptd_numatd,
    String Ptd_usubdd,
    DateTime Ptd_datcri,
    DateTime Ptd_datalt,
    int Ptd_usucri,
    int Ptd_usualt
);