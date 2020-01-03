using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Cores.DbObject
{
    public interface IDbObject
    {
        void Insert();
        void Update();
    }
}
