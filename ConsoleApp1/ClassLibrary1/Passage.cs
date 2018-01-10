using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1
{
    public class Passage
    {

        private readonly IList<Place> _places = new List<Place>(2);
        public ICollection<Block> BlockedBy { get; set; }

        public Passage(Place placeFrom, Place placeTo, ICollection<Block> blockedBy = null)
        {
            this._places.Add(placeFrom);
            this._places.Add(placeTo);
            this.BlockedBy = blockedBy;
        }

        public void Pass()
        {
            if (BlockedBy != null && BlockedBy.All(bl=>bl.IsBlocking))
            {
              //Can't pass message   
            }

            var placeFrom = this._places.First(p => p.Player != null);
            var placeTo = this._places.First(p => p.Player == null);
            placeTo.Player = placeFrom.Player;
            placeFrom.PlayerGone();
        }

        public Place GetPlaceTo()
        {
            return this._places.First(p => p.Player == null);
        }
    }
}