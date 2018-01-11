using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1
{
    public class Place
    {
        private readonly IDictionary<DirectionType, PlaceDirection> _directions = new Dictionary<DirectionType, PlaceDirection>(4)
        {
            { DirectionType.North, new PlaceDirection(DirectionType.North,DirectionType.South) },
            { DirectionType.South, new PlaceDirection(DirectionType.South,DirectionType.North) },
            { DirectionType.West, new PlaceDirection(DirectionType.West,DirectionType.East) },
            { DirectionType.East, new PlaceDirection(DirectionType.East,DirectionType.West) }
        };

        public Place(string description)
        {
            this.Description = description;
        }

        public void AddStuffTo(DirectionType sideType, IEnumerable<IStuff> stuffs)
        {
            _directions[sideType].Stuff.Concat(stuffs);
        }

        public void AddStuff(IEnumerable<IStuff> stuffs)
        {
            this.stuffs.Concat(stuffs);
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

        public string Description { get; private set; }

        public Player Player { get; set; }

        public bool IsVisited { get; private set; }

        public IDictionary<DirectionType, PlaceDirection> Directions
        {
            get
            {
                return _directions;
            }
        }

        public void PlayerGone()
        {
            this.Player = null;
        }

        private IEnumerable<IStuff> stuffs = new List<IStuff>();
    }

    public class Player
    {

    }
}