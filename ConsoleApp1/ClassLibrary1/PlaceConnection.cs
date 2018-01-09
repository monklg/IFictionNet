using System.Collections.Generic;

namespace ClassLibrary1
{
    public class PlaceConnection 
    {
        public  Place Place { get; private set; }
        public ICollection<Block> BlockedBy { get; set; }

        public PlaceConnection(Place place, ICollection<Block> blockedBy = null)
        {
            this.Place = place;
            this.BlockedBy = blockedBy;
        }
    }
}