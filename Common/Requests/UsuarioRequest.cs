namespace Common.Requests;

public record CreateUsuario(        
    String Usu_descri,
    String Usu_login,
    String Usu_senha,
    String Usu_email, 
    String Usu_ativo, 
    String Usu_status,
    String Usu_master,
    String Usu_tipusu,
    String Usu_Usubdd,
    int Usu_Usucri,
    int Usu_Usualt,
    DateTime Usu_datcri,
    DateTime Usu_datalt
);

public record UpdateUsuario(
    int Id,
    String Usu_descri,
    String Usu_login,
    String Usu_senha,
    String Usu_email,
    String Usu_ativo,
    String Usu_status,
    String Usu_master,
    String Usu_tipusu,
    String Usu_usubdd,
    int Usu_usucri,
    int Usu_usualt,
    DateTime Usu_datcri,
    DateTime Usu_datalt
);