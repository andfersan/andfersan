using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DioSeries
{
    public abstract class EntidadeBase
    {
        // Serve para todas as outras classes
        public int Id { get; protected set; }
    }
}
