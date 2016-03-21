using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTunesSearch
{
    public enum ParameterKey
    {
        //Media e Term são obrigatórios e estarão presentes nas chamadas de método.
        Country,
        Entity,
        Attribute,
        CallBack,
        Limit,
        Lang,
        Version,
        Explicit,
    }
}
