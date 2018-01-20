using System.Collections.ObjectModel;
namespace Compiler.Scanner.Common
{
    class RevertPointCollection : KeyedCollection<int, RevertPoint>
    {
        protected override int GetKeyForItem(RevertPoint item)
        {
            return item.Key;
        }
    }
}
