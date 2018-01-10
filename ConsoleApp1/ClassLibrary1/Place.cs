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

        public void AddPassageTo(DirectionType sideType, Passage passage)
        {
            var direction = _directions[sideType];
            direction.Passage = passage;
            var placeTo = passage.GetPlaceTo();
            placeTo.AddPassageTo(direction.OppositeDirection, passage);
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

        public void AddStuffToDirection( Wall wall, params DirectionType[] directionType)
        {
            foreach (var dirType in directionType)
            {
                _directions[dirType].Stuff.Add(wall);
            }
        }

        public void PlayerGone()
        {
            this.Player = null;
        }

        private IEnumerable<Stuff> stuffs = new List<Stuff>();
    }

    public class Player

    {
    }
}