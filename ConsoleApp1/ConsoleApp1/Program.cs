﻿using System.Collections.ObjectModel;
using ClassLibrary1;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var descript = "Моя спальня. Я тут сплю.";
            var wall = new Wall();

            var leftCornerBottom = new Place(descript);
            var leftCornerUp = new Place(descript);
            var coridor = new Place("коридор");
            var street = new Place("улица");
            var centalUp = new Place(descript);
            var rightCornerUp = new Place(descript);
            var rightCornerBottom = new Place(descript);
            var centralBottom = new Place(descript);

            leftCornerBottom.AddStuffToDirection(wall, DirectionType.West, DirectionType.South);
            leftCornerUp.AddStuffToDirection(wall, DirectionType.North);
            centalUp.AddStuffToDirection(wall, DirectionType.North);
            rightCornerUp.AddStuffToDirection(wall, DirectionType.North);
            rightCornerBottom.AddStuffToDirection(wall, DirectionType.East, DirectionType.South);

            new PlaceConnector().
                Connect(leftCornerBottom).
                With(leftCornerUp).
                SetDirection(DirectionType.North).
                Done().
                With(centralBottom).
                SetDirection(DirectionType.East).
                Done().
                Connect(leftCornerUp).
                With(coridor).
                SetDirection(DirectionType.West).
                PassageBlockedBy(new Collection<Block> { new Door() }).
                Done().
                With(rightCornerUp).
                SetDirection(DirectionType.East).
                Done().
                Connect(centalUp).
                With(rightCornerUp).
                SetDirection(DirectionType.East).
                Done().
                With(centralBottom).
                SetDirection(DirectionType.South).
                Done().
                Connect(rightCornerUp).
                With(street).
                SetDirection(DirectionType.East).
                PassageBlockedBy(new Collection<Block> { new Window() }).
                Done().
                With(rightCornerBottom).
                SetDirection(DirectionType.South).
                Done().
                Connect(rightCornerBottom).
                With(centralBottom).
                SetDirection(DirectionType.West).
                Done();

            rightCornerBottom.AddStuffToDirection(wall, DirectionType.South);
        }
    }
}
