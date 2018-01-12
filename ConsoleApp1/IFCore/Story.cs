using System.Collections;
using System.Collections.Generic;
using ClassLibrary1;

namespace IFCore
{
    public class Story
    {
        private readonly StoryOpening _opening;
        private readonly StoryParts _parts;
        private StoryEnd _end;
        private StoryOpening _storyOpening;

        public Story(StoryOpening opening, StoryParts parts, StoryEnd end)
        {
            _opening = opening;
            _parts = parts;
            _end = end;
        }

        public IEnumerable<StoryItem> Start()
        {
            foreach (var storyPart in _parts)
            {
                yield return storyPart;
            }

            yield return _end;
        }

        public StoryOpening StoryOpening
        {
            get { return _storyOpening; }
        }
    }

    public class StoryEnd : StoryItem
    {
    }

    public class StoryParts : IEnumerable<StoryСhapter>
    {
        private readonly IList<StoryСhapter> _chapters =new List<StoryСhapter>();
        
        public IEnumerator<StoryСhapter> GetEnumerator()
        {
            return _chapters.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _chapters.GetEnumerator();
        }

        public void Add(StoryСhapter currentStoryChapter)
        {
            _chapters.Add(currentStoryChapter);
        }
    }

    public class StoryСhapter : StoryItem, IEnumerable<StoryItem>
    {
        private StoryOpening _storyOpening=new StoryOpening();

        public StoryOpening StoryOpening
        {
            get { return _storyOpening; }
            set { _storyOpening = value; }
        }

        public IList<Place> Places { get; set; }

        public IEnumerator<StoryItem> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class StoryOpening : StoryItem
    {
        private Description _text=new Description();

        public void Start()
        {
            
        }

        public Description Text
        {
            get { return _text; }
            set { _text = value; }
        }
    }

    public class Description
    {
        public string Title { get; set; }
        public string Body { get; set; }
    }

    public class StoryItem
    {
        public void Start()
        {
            
        }
    }
}
