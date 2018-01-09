using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
    }

    public enum SideType
    {
        North,
        South,
        East,
        West
    }

    public class PlaceDirection
    {
        private readonly IEnumerable<Stuff> stuff = new List<Stuff>();
        
        public IEnumerable<Stuff> Stuff { get; set; }

        public PlaceConnection PlaceConnection { get; set; }
    }

    public class Stuff
    {

        public Stuff(string description)
        {
            this.Description = description;
        }

        public string Description { get; set; }
    }

    public class PlaceConnection 
    {
        private readonly Place space;
        private readonly IEnumerable<Block> blockedBy;

        public PlaceConnection(Place space, IEnumerable<Block> blockedBy)
        {
            this.space = space;
            this.blockedBy = blockedBy;
        }
    }

    public class Door : Block
    {
        public Door()
        {
            Description = "Это обычная дверь";
        }
    }

    public class Wall : Block
    {
        public Wall()
        {
            Description = "Обыкновенная стена";
        }

    }

    public class Place
    {
        private IDictionary<SideType, PlaceDirection> sides = new Dictionary<SideType, PlaceDirection>(4)
        {
            { SideType.North, new PlaceDirection() },
            { SideType.South, new PlaceDirection() },
            { SideType.West, new PlaceDirection() },
            { SideType.East, new PlaceDirection() }
        };

        public string Description { get; private set; }
        private IEnumerable<Stuff> stuffs = new List<Stuff>();

        public Place(string description)
        {
            this.Description = description;
        }

        public void AddStuffTo(SideType sideType, IEnumerable<Stuff> stuffs)
        {
            sides[sideType].Stuff.Concat(stuffs);
        }

        public void AddStuff(IEnumerable<Stuff> stuffs)
        {
            this.stuffs.Concat(stuffs);
        }

        public void AddPlaceConnectionTo(SideType sideType, PlaceConnection placeConnection)
        {
            sides[sideType].PlaceConnection = placeConnection;
        }

        public void Go()
        {
        }

        public void See()
        {

        }

        public void Observe()
        {

        }

    }

}
