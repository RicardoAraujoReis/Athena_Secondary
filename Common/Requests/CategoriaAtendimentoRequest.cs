namespace Common.Requests;

public record CreateCategoriaAtendimento(        
    int cat_catpai,
    int cat_nivel,
    String cat_valor,
    String cat_usubdd,
    int cat_usucri,
    int cat_usualt,
    DateTime cat_datcri, 
    DateTime cat_datalt 
);

public record UpdateCategoriaAtendimento(
    int cat_identi,
    int cat_catpai,
    int cat_nivel,
    String cat_valor,
    String cat_usubdd,
    int cat_usucri,
    int cat_usualt,
    DateTime cat_datcri,
    DateTime cat_datalt
);