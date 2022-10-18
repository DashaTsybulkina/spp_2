﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerClass.generator
{
    public interface IGenerator
    {
        object Generate();
        Type GetGenType();
    }
}
