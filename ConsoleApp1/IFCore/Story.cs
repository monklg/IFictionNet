using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace IFCore
{
    public class Story
    {
        private StoryIntro _intro;
        private readonly StoryParts _parts;
        private StoryEnd _end;

        public Story(StoryIntro intro, StoryParts parts, StoryEnd end)
        {
            _intro = intro;
            _parts = parts;
            _end = end;
        }


        public IEnumerable<StoryItem> Start()
        {
            yield return _intro;

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

    public class StoryParts : IEnumerable<StoryPart>
    {
        public IEnumerator<StoryPart> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class StoryPart : IEnumerable<StoryItem>
    {
        public IEnumerator<StoryItem> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class StoryIntro : StoryItem
    {
    }

    public class StoryItem
    {
        public void Start()
        {
            
        }
    }
}
