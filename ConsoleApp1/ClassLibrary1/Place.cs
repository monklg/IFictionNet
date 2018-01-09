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

        public void AddStuffTo(DirectionType sideType, IEnumerable<Stuff> stuffs)
        {
            _directions[sideType].Stuff.Concat(stuffs);
        }

        public void AddStuff(IEnumerable<Stuff> stuffs)
        {
            this.stuffs.Concat(stuffs);
        }

        public void AddPlaceConnectionTo(DirectionType sideType, PlaceConnection placeConnection)
        {
            _directions[sideType].PlaceConnection = placeConnection;
            placeConnection.Place.AddPlaceConnectionTo(_directions[sideType].OppositeDirection,placeConnection);
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

        private IEnumerable<Stuff> stuffs = new List<Stuff>();

        public void AddStuffToDirection( Wall wall, params DirectionType[] directionType)
        {
            foreach (var dirType in directionType)
            {
                _directions[dirType].Stuff.Add(wall);
            }
        }
    }
}