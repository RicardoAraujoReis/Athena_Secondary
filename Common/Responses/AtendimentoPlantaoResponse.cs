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
    public String Atd_tipatd { get; set; }
    public int Atd_cat_identi { get; set; }
    public String Atd_resumo { get; set; }
    public String Atd_respn2 { get; set; }
    public String Atd_crijir { get; set; }
    public String Atd_issue { get; set; }
    public String Atd_critic { get; set; }
    public String Atd_resplt { get; set; }
    public String Atd_ren1hm { get; set; }
    public String Atd_resn1 { get; set; }
    public String Atd_evoln1 { get; set; }
    public String Atd_observ { get; set; }
    public String Atd_usubdd { get; set; }
    public DateTime Atd_datatd { get; set; }
    public String Atd_nomal2 { get; set; }
    public String Atd_status { get; set; }
    public int Atd_usucri { get; set; }
    public int Atd_usualt { get; set; }
    public DateTime Atd_datcri { get; set; }
    public DateTime Atd_datalt { get; set; }
}
