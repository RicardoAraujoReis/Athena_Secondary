using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Responses;

public class AtendimentoPlantaoResponse
{
    public int Id { get; set; }
    public int Atd_usu_identi { get; set; }
    public int Atd_ptd_identi { get; set; }
    public int Atd_cli_identi { get; set; }
    public string Atd_titulo { get; set; }
    public string Atd_tipatd { get; set; }    
    public string Atd_resumo { get; set; }
    public string Atd_respn2 { get; set; }
    public string Atd_crijir { get; set; }
    public string? Atd_issue { get; set; }
    public string Atd_critic { get; set; }
    public string Atd_resplt { get; set; }
    public string Atd_ren1hm { get; set; }
    public string Atd_resn1 { get; set; }
    public string Atd_evoln1 { get; set; }
    public string? Atd_jusevo { get; set; }
    public string Atd_usubdd { get; set; }
    public DateTime Atd_datatd { get; set; }
    public string Atd_nomal2 { get; set; }
    public string Atd_nomal1 { get; set; }
    public string Atd_status { get; set; }
    public string Atd_catnv1 { get; set; }
    public string Atd_catnv2 { get; set; }
    public string Atd_catnv3 { get; set; }
    public string? Atd_catnv4 { get; set; }
    public int Atd_usucri { get; set; }
    public int Atd_usualt { get; set; }
    public DateTime Atd_datcri { get; set; }
    public DateTime Atd_datalt { get; set; }
    public string? Atd_linjir { get; set; }
    public string? Atd_verjir { get; set; }
    public string Atd_jirarl { get; set; }
}
