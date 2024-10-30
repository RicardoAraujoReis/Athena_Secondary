using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces;

public abstract class BaseEntity<TId> : IEntity<TId>
{
    public TId Id { get; set; }
}
