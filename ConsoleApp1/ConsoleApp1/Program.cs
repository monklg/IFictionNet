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
            leftCornerBottom.AddPlaceConnectionTo(DirectionType.North,new PlaceConnection(leftCornerUp));
            leftCornerBottom.AddPlaceConnectionTo(DirectionType.East, new PlaceConnection(centralBottom));
            
            leftCornerUp.AddStuffToDirection(wall, DirectionType.North);
            leftCornerUp.AddPlaceConnectionTo(DirectionType.West, new PlaceConnection(coridor, new Collection<Block> { new Door()}));
            leftCornerUp.AddPlaceConnectionTo(DirectionType.East, new PlaceConnection(rightCornerUp));

            centalUp.AddStuffToDirection(wall, DirectionType.North);
            centalUp.AddPlaceConnectionTo(DirectionType.East, new PlaceConnection(rightCornerUp));
            centalUp.AddPlaceConnectionTo(DirectionType.South, new PlaceConnection(centralBottom));

            rightCornerUp.AddStuffToDirection(wall, DirectionType.North);
            rightCornerUp.AddPlaceConnectionTo(DirectionType.East, new PlaceConnection(street, new Collection<Block> { new Window() }));
            rightCornerUp.AddPlaceConnectionTo(DirectionType.South, new PlaceConnection(rightCornerBottom));

            rightCornerBottom.AddStuffToDirection(wall, DirectionType.East,DirectionType.South);
            rightCornerBottom.AddPlaceConnectionTo(DirectionType.West, new PlaceConnection(centralBottom));

            rightCornerBottom.AddStuffToDirection(wall, DirectionType.South);

        }
    }
}
