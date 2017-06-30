using System.Collections.Generic;
using System.Linq;

namespace EventsModule
{
    public class EventColumnListManager
    {
        #region Contructors

        public EventColumnListManager(IList<EventTextBlock> sourceList, IList<EventTextBlock> destinationList) 
        {

            //save reference to local variables

            _sourceList = sourceList;

            _destinationList = destinationList;

 

            //iterate the destination list to see what has already been added to it from the source

            foreach (var lookup in _destinationList)

            {

                //find the associated lookup object in the source and remove it

                var lku = FindLookupInList(_sourceList, lookup.Text);

                if (lku != null)

                {

                    _sourceList.Remove(lku);

                }

            }

        }

 

        #endregion

        #region Private Members

        private IList<EventTextBlock> _sourceList = new List<EventTextBlock>();

        private IList<EventTextBlock> _destinationList = new List<EventTextBlock>();

 

        private EventTextBlock FindLookupInList(IList<EventTextBlock> list, string valueMember)

        {

            return list.FirstOrDefault(l => l.Text.Equals(valueMember));

        }

 

        #endregion

        #region Methods to move lookup objects from one List to the other List

        /// <summary>

        /// Move a lookup object from the source list to the destination list.

        /// </summary>

        /// <param name="lookup">The lookup object to be moved.</param>

        public void MoveFromSource(EventTextBlock lookup)

        {

            _sourceList.Remove(lookup);

            _destinationList.Add(lookup);

        }

        

        /// <summary>

        /// Move a lookup object from the source list to the destination list.

        /// </summary>

        /// <param name="valueMember">The valueMember of the lookup object to be moved.</param>

        public void MoveFromSource(string valueMember)

        {

            var lku = FindLookupInList(_sourceList, valueMember);

            if (lku != null)

            {

                MoveFromSource(lku);

            }

        }

 

        /// <summary>

        /// Move a lookup object from the destination list to the source list.

        /// </summary>

        /// <param name="lookup">The lookup object to be moved.</param>

        public void MoveToSource(EventTextBlock lookup)

        {

            _destinationList.Remove(lookup);

            _sourceList.Add(lookup);

        }

 

        /// <summary>

        /// Move a lookup object from the destination list to the source list.

        /// </summary>

        /// <param name="valueMember">The valueMember of the lookup object to be moved.</param>

        public void MoveToSource(string valueMember)

        {

            var lku = FindLookupInList(_destinationList, valueMember);

            if (lku != null)

            {

                MoveToSource(lku);

            }

        }

        #endregion
    }


}
