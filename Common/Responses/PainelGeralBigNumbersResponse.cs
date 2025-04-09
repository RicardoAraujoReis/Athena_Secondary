using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Responses;

public class PainelGeralBigNumbersResponse
{
    public int Id { get; set; }
    public string Icon { get; set; }
    public double Value { get; set; }
    public string Label { get; set; }
    public DateTime DataAtualizacao { get; set; }
}
