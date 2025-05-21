using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.PainelGeral;

public class PainelGeralBigNumbers : BaseEntity<int>
{
    public string Icon { get; set; }
    public double Value { get; set; }
    public string Label { get; set; }
    public DateTime DataAtualizacao { get; set; }

    public PainelGeralBigNumbers UpdatePainelGeralBigNumbers(
    int id,
    string icon,
    double value,
    string label,
    DateTime dataAtualizacao
    )
    {
        Id = id;
        Icon = icon;
        Value = value;
        Label = label;
        DataAtualizacao = dataAtualizacao;

        return this;
    }
}


