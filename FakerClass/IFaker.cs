using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerClass
{
    public interface IFaker
    {
        T create<T>();
    }
}
