using System.Collections.Generic;
using IFCore;

namespace ClassLibrary1
{
    public class StoryBuilder
    {
        private IList<Place> _places = new List<Place>();
        private Place _currentPlace;
        private Player _player;
        private StoryOpening _storyOpening = new StoryOpening();
        private StoryСhapter _currentStoryChapter;
        private StoryParts _storyParts = new StoryParts();


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

        public StoryBuilder CreateStoryOpeningTitle(string title)
        {
            _storyOpening.Text.Title = title;

            return this;
        }

        public StoryBuilder CreateStoryOpeningText(string text)
        {
            _storyOpening.Text.Body = text;

            return this;
        }

        public StoryBuilder CreateChapter()
        {
            _currentStoryChapter = new StoryСhapter();
            _currentStoryChapter.Places = _places;
            _storyParts.Add(_currentStoryChapter);

            return this;
        }

        public StoryBuilder CreateChapterOpeningTitle(string title)
        {
            _currentStoryChapter.StoryOpening.Text.Title = title;

            return this;
        }

        public StoryBuilder CreateChapterOpeningText(string text)
        {
            _currentStoryChapter.StoryOpening.Text.Body = text;

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

        public Story GenerateStory()
        {
            var story = new Story(_storyOpening, _storyParts, new StoryEnd());
            return story;
        }
    }
}
