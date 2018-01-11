using System.Collections.Generic;
namespace ClassLibrary1
{
    public class StoryBuilder
    {
        private IList<Place> _places = new List<Place>();
        private Place _currentPlace;
        private Player _player;


        public StoryBuilder(Player player)
        {
            _player = player;
        }

        public StoryBuilder CreatePlace(string description)
        {
            _currentPlace = new Place(description);
            _places.Add(_currentPlace);

            return this;
        }

        public StoryBuilder SetAsStartPoint()
        {
            _currentPlace.Player = _player;

            return this;
        }

        public StoryBuilder MoveTo(DirectionType deDirectionType)
        {
            _currentPlace = _currentPlace.Directions[deDirectionType].Passage.GetPlaceTo();

            return this;
        }

        public StoryBuilder ConnectWith(Place place, DirectionType directionType, List<Block> bloks = null )
        {
            new PlaceConnector(directionType).Connect(_currentPlace).With(place).PassageBlockedBy(bloks).Done();
            return this;
        }

        public StoryBuilder AddStuff(IStuff stuff, params DirectionType[] directionType)
        {
            foreach (var dirType in directionType)
            {
                this._currentPlace.Directions[dirType].Stuff.Add(stuff);
            }

            return this;
        }
    }
}
