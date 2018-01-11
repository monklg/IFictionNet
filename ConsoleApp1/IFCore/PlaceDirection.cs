using System.Collections.Generic;

namespace ClassLibrary1
{
    public class PlaceDirection
    {
        private readonly DirectionType _direction;
        private readonly DirectionType _oppositeDirection;
        private readonly ICollection<IStuff> _stuff = new List<IStuff>();

        public PlaceDirection(DirectionType direction, DirectionType oppositeDirection)
        {
            _direction = direction;
            _oppositeDirection = oppositeDirection;
        }

        public ICollection<IStuff> Stuff { get { return (ICollection<IStuff>) _stuff; } }

        public Passage Passage { get; set; }

        public DirectionType Direction
        {
            get
            {
                return _direction;
            }
        }

        public DirectionType OppositeDirection
        {
            get
            {
                return _oppositeDirection;
            }
        }
    }
}