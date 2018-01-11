using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ClassLibrary1
{
    public class Passage
    {
        private readonly Place _placeFrom;
        private readonly Place _placeTo;

        public ICollection<Block> BlockedBy { get; set; }

        public Passage(Place placeFrom, Place placeTo, ICollection<Block> blockedBy = null)
        {
            this._placeFrom = placeFrom;
            this._placeTo = placeTo;
            this.BlockedBy = blockedBy;
        }

        public void Pass()
        {
            var placeFrom = this.GetPlaces().First(p => p.Player != null);
            var placeTo = this.GetPlaces().First(p => p.Player == null);
            placeTo.Player = placeFrom.Player;
            placeFrom.PlayerGone();
        }

        public bool Blocked
        {
            get
            {
                return BlockedBy != null && BlockedBy.All(bl => bl.IsBlocking);
            }
        }

        public Place GetPlaceTo()
        {
            return _placeTo;
        }

        public IEnumerable<Place> GetPlaces()
        {
            yield return _placeFrom;
            yield return _placeTo;
        } 
    }
}