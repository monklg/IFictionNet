using System.Collections.ObjectModel;
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
            leftCornerBottom.AddPassageTo(DirectionType.North, new Passage(leftCornerBottom,leftCornerUp));
            leftCornerBottom.AddPassageTo(DirectionType.East, new Passage(leftCornerBottom, centralBottom));
            
            leftCornerUp.AddStuffToDirection(wall, DirectionType.North);
            leftCornerUp.AddPassageTo(DirectionType.West, new Passage(leftCornerUp,coridor, new Collection<Block> { new Door() }));
            leftCornerUp.AddPassageTo(DirectionType.East, new Passage(leftCornerUp,rightCornerUp));

            centalUp.AddStuffToDirection(wall, DirectionType.North);
            centalUp.AddPassageTo(DirectionType.East, new Passage(centalUp,rightCornerUp));
            centalUp.AddPassageTo(DirectionType.South, new Passage(centalUp,centralBottom));

            rightCornerUp.AddStuffToDirection(wall, DirectionType.North);
            rightCornerUp.AddPassageTo(DirectionType.East, new Passage(rightCornerUp,street, new Collection<Block> { new Window() }));
            rightCornerUp.AddPassageTo(DirectionType.South, new Passage(rightCornerUp,rightCornerBottom));

            rightCornerBottom.AddStuffToDirection(wall, DirectionType.East,DirectionType.South);
            rightCornerBottom.AddPassageTo(DirectionType.West, new Passage(rightCornerBottom,centralBottom));

            rightCornerBottom.AddStuffToDirection(wall, DirectionType.South);

        }
    }
}
