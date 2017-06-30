using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Inspire
{
    public class CollectionHelpers
    {
        public static IEnumerable GetRemainingStringCollection(object filterVar, IEnumerable<string> filterCollection, IEnumerable<string> collectionToFilter)
        {
            var startIndex = 0;

            if (filterVar != null)
                startIndex = collectionToFilter.ToList().Select(s => s[0].ToString()).ToList().IndexOf(filterVar.ToString());

            if (startIndex == -1)
                return GetRemainingStringCollection(GetNext(filterVar, filterCollection), filterCollection, collectionToFilter);

            var endIndex = collectionToFilter.Count() - startIndex;

            return collectionToFilter.ToList().GetRange(startIndex, endIndex);
        }

        public static object GetNext(object character, IEnumerable<object> collection)
        {
            object retChar = null;
            var curIndex = collection.ToList().IndexOf(character);
            if (curIndex <= collection.Count() - 2)
                retChar = collection.ToList()[curIndex + 1];
            return retChar;
        }

    }
}
