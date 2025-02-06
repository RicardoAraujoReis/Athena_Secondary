namespace Common.Requests;

public class CreateCategoriaAtendimento {
    public int Cat_catpai { get; set; }
    public string? Cat_despai { get; set; }
    public int Cat_nivel { get; set; }
    public string Cat_valor { get; set; }
    public string Cat_ativo { get; set; }
    public string Cat_usubdd { get; set; }
    public int Cat_usucri { get; set; }
    public int? Cat_usualt { get; set; }
    public DateTime Cat_datcri { get; set; } 
    public DateTime? Cat_datalt { get; set; }
};

public class UpdateCategoriaAtendimento {
    public int Id { get; set; }
    public int Cat_catpai { get; set; }
    public string? Cat_despai { get; set; }
    public int Cat_nivel { get; set; }
    public string Cat_valor { get; set; }
    public string Cat_ativo { get; set; }
    public string Cat_usubdd { get; set; }
    public int Cat_usucri { get; set; }
    public int? Cat_usualt { get; set; }
    public DateTime Cat_datcri { get; set; }
    public DateTime? Cat_datalt { get; set; }
};