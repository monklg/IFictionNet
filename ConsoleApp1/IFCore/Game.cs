using System.Collections.Generic;
using System.Linq;
using ClassLibrary1;

namespace IFCore
{
    public class Game
    {
        public Game(Story story, AuthorInfo authorInfo)
        {
            _story = story;
            _authorInfo = authorInfo;
        }

        private int _gameScore;
        private int _actionCount;
        private readonly Story _story;
        private readonly AuthorInfo _authorInfo;

        public AuthorInfo AuthorInfo
        {
            get { return _authorInfo; }
        }
        public StoryOpening StoryOpening
        {
            get { return _story.StoryOpening; }
        }

        public Story Story { get { return _story; } }

        public void Start(IEngine engine)
        {
            foreach (var storyPart in _story.Start())
            {
                storyPart.Start();
            }
        }
    }

    public interface IEngine
    {
    }

    public class GamePlayer : IEngine
    {
        private readonly Game _game;
        private readonly IParser _parser;

        public GamePlayer(Game game, IParser parser)
        {
            _game = game;
            _parser = parser;
        }


        public IEnumerable<StoryItem> Play()
        {
            return _game.Story.Start();
        }

        public IntroModel PlayIntro()
        {
            return new IntroModel
            {
                AuthorInfo = _game.AuthorInfo,
                StoryOpening = _game.StoryOpening
            };
        }

        public AuthorInfo GetAuthorInfo()
        {
            return _game.AuthorInfo;
        }

    }

    public class IntroModel
    {
        public AuthorInfo AuthorInfo { get; set; }
        public StoryOpening StoryOpening { get; set; }
    }
}
