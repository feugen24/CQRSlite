using System;
using System.Collections.Generic;
using System.Text;

namespace CQRSlite.Events
{
    public interface IEventMigration<TSource,TDest>
    {
        TDest Migrate(TSource source);
    }
}
