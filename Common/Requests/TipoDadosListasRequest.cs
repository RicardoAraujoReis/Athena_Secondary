namespace Common.Requests;

public class CreateTipoDadosListas {
    public string Tid_descri { get; set; }
    public string Tid_usubdd { get; set; }
    public DateTime Tid_datcri { get; set; }
    public DateTime? Tid_datalt { get; set; }
    public int Tid_usucri { get; set; }
    public int? Tid_usualt { get; set; }
};

public class UpdateTipoDadosListas {
    public int Id { get; set; }
    public string Tid_descri { get; set; }
    public string Tid_usubdd { get; set; }
    public DateTime Tid_datcri { get; set; }
    public DateTime? Tid_datalt { get; set; }
    public int Tid_usucri { get; set; }
    public int? Tid_usualt { get; set; }

    public static implicit operator UpdateTipoDadosListas(string v)
    {
        throw new NotImplementedException();
    }
}