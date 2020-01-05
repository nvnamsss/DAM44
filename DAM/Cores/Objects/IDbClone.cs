using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.Objects
{
    interface IDbClone
    {
        DbObject Clone();
    }
}
