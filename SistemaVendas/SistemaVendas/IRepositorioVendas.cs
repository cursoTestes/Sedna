using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVendas
{
    public interface IRepositorioVendas
    {
        List<decimal> GetVendas(int mes, int ano);
    }
}
