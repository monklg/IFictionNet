using System.Collections;
using System.Collections.Generic;
using ClassLibrary1;

namespace IFCore
{
    public class Story
    {
        private StoryOpening _opening;
        private readonly StoryParts _parts;
        private StoryEnd _end;

        public Story(StoryOpening opening, StoryParts parts, StoryEnd end)
        {
            _opening = opening;
            _parts = parts;
            _end = end;
        }


        public IEnumerable<StoryItem> Start()
        {
            yield return _opening;

            foreach (var storyPart in _parts)
            {
                foreach (var storyPartItem in storyPart)
                {
                    yield return storyPartItem;
                }
            }

            yield return _end;
        }
    }

    public class StoryEnd : StoryItem
    {
    }

    public class StoryParts : IEnumerable<StoryСhapter>
    {
        
        public IEnumerator<StoryСhapter> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(StoryСhapter currentStoryChapter)
        {
            throw new System.NotImplementedException();
        }
    }

    public class StoryСhapter : StoryItem, IEnumerable<StoryItem>
    {
        public StoryOpening StoryOpening { get; set; }
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
