using Models.Interfaces;

namespace Athena.Models;

public class CategoriaAtendimento : BaseEntity<int>
{    
    public int? Cat_catpai { get; set; }
    public String? Cat_despai { get; set; }
    public int Cat_nivel { get; set; }
    public String Cat_valor { get; set; }
    public String Cat_ativo { get; set; }
    public String Cat_usubdd { get; set; }
    public int Cat_usucri { get; set; }
    public int? Cat_usualt { get; set; }
    public DateTime Cat_datcri { get; set; }
    public DateTime? Cat_datalt { get; set; }
    public virtual List<AtendimentoPlantao> Atendimentos { get; set; }

    public CategoriaAtendimento UpdateCategoriaAtendimento(
        int id,
        int cat_catpai,
        String cat_despai,
        int cat_nivel,
        String cat_valor,
        String cat_ativo,
        String cat_usubdd,
        int cat_usucri,
        int cat_usualt,
        DateTime cat_datcri,
        DateTime cat_datalt
    )
    {
        Id = id;
        Cat_catpai = cat_catpai;
        Cat_despai = cat_despai;
        Cat_nivel = cat_nivel;
        Cat_valor = cat_valor;
        Cat_ativo = cat_ativo;
        Cat_usubdd = cat_usubdd;
        Cat_usucri = cat_usucri;
        Cat_usualt = cat_usualt;
        Cat_datcri = cat_datcri;
        Cat_datalt = cat_datalt;

        return this;
    }
}
