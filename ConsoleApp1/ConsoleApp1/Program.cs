using System;
using ClassLibrary1;
using IFCore;

namespace ConsoleApp1
{
    class Program
    {
        private static void Main(string[] args)
        {
            var player = new Player();

            var authorInfo = new AuthorInfo();
            authorInfo.AuthorName = "Колмаков Павел";
            authorInfo.GameCreated = DateTime.Today;
            authorInfo.GenreDescription = "Комедийная тестовая игра";
            authorInfo.AuthorWords = "Это первая игра на разрабатываемом движке";

            //var opening = new StoryOpening();
            //var openingText = new Description();
            //openingText.Title = "Работать так чтобы Сталин спасибо сказал!";
            //openingText.Body = "Хорошое сегодня утро! Пока ты ехал на работу, казалось, все тебе говорило об этом! Когда ты вошел в офисное здание, охрана поприветствовала тебя как буд-то ты старый знакомый. Двери открывались легко. Твое кресло удобное и свет экрана монитора сегодня не резал глаз.";
            //opening.Text = openingText;

            var newStory = new StoryBuilder(player)
                .CreateStoryOpeningTitle("Работать так чтобы Сталин спасибо сказал!")
                .CreateStoryOpeningText(
                    "Хорошое сегодня утро! Пока ты ехал на работу, казалось, все тебе говорило об этом! Когда ты вошел в офисное здание, охрана поприветствовала тебя как буд-то ты старый знакомый. Двери открывались легко. Твое кресло удобное и свет экрана монитора сегодня не резал глаз.")
                .CreateChapter()
                .CreateChapterOpeningTitle("На работе")
                .CreateChapterOpeningText("Ты удобно уселся за свой рабочий стол и готов работать")
                .CreatePlace("Твое рабочее место")
                .SetAsStartPoint()
                .AddStuff(new Stuff("Монитор"), DirectionType.North)
                .AddStuff(new Stuff("Клавиатура"), DirectionType.North)
                .AddStuff(new Stuff("Мышь"), DirectionType.North)
                .AddStuff(new Stuff("Кружка кофе"), DirectionType.North)
                .AddStuff(new Stuff("Стол"), DirectionType.North)
                .AddStuff(new Stuff("Блокнот"), DirectionType.North)
                .AddStuff(new Stuff("Ручка"), DirectionType.North)
                .AddStuff(new Wall(), DirectionType.South)
                .GenerateStory();

            var mortalJob = new Game(newStory, authorInfo);
            var consoleReader = new ConsoleReader();
            var gamePlayer = new GamePlayer(mortalJob, new Parser());

            var intro = gamePlayer.PlayIntro();

            consoleReader.Run(intro);
            foreach (var stroryItem in gamePlayer.Play())
            {
                
                    var chapter = stroryItem as StoryСhapter;
                    if (chapter != null)
                    {
                        consoleReader.Run(new IntroModel { StoryOpening = chapter.StoryOpening });
                        while (true)
                        {
                            
                            Console.ReadLine();

                        }

                }
            }
        }

    }

    }

