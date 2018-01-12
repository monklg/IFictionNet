using System;
using System.Text;

namespace IFCore
{
    public class ConsoleReader
    {
        public ConsoleReader()
        {
            Console.OutputEncoding = Encoding.UTF8;
        }
        public void Run(string text)
        {
            Console.WriteLine(text);
        }

        public void Run(IntroModel intro)
        {
            if (intro.AuthorInfo != null)
            {
                Console.WriteLine(intro.AuthorInfo.AuthorName);
                Console.WriteLine(string.Empty);
                Console.WriteLine(intro.AuthorInfo.Title);
                Console.WriteLine(intro.AuthorInfo.GameCreated);
                Console.WriteLine(intro.AuthorInfo.GenreDescription);
                Console.WriteLine(intro.AuthorInfo.AuthorWords);
                Console.WriteLine(string.Empty);
            }

            if (intro.StoryOpening != null)
            {
                Console.WriteLine(intro.StoryOpening.Text.Title);
                Console.WriteLine(string.Empty);
                Console.WriteLine(intro.StoryOpening.Text.Body);
            }

            Console.WriteLine(string.Empty);
        }
    }
}