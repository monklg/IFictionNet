using System.Collections.Generic;

namespace ClassLibrary1
{
    public class PlaceConnector
    {
        private Place _placeFrom;
        private Place _placeTo;
        private readonly DirectionType _directionType;
        private ICollection<Block> _blocks;

        public PlaceConnector(DirectionType directionType)
        {
            this._directionType = directionType;
        }

        public PlaceConnector Connect(Place place)
        {
            this._placeFrom = place;
            return this;
        }

        public PlaceConnector With(Place place)
        {
            this._placeTo = place;
            return this;
        }

        public PlaceConnector PassageBlockedBy(ICollection<Block> blocks)
        {
            this._blocks = blocks;
            return this;

        }

        public PlaceConnector Done()
        {
            var passage = new Passage(_placeFrom, _placeTo, _blocks);
            var direction = _placeFrom.Directions[_directionType];
            direction.Passage = passage;
            var placeTo = passage.GetPlaceTo();
            var directionTo = placeTo.Directions[direction.OppositeDirection];
            directionTo.Passage = passage;
            _blocks = null;

            return this;
        }
    }
}
