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
        private Story _story;
        private AuthorInfo _authorInfo;

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

        public string Play(string input)
        {
            _game.Start(this);
            return null;
        }
    }
}
