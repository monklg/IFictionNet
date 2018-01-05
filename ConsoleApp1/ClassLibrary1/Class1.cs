using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
    }

    public enum SideType
    {
        North,
        South,
        East,
        West
    }

    public class Side
    {
        private readonly SideType sideType;
        private readonly SpaceConnection space;
        private readonly IEnumerable<Stuff> stuff = new List<Stuff>();

        public Side(SideType sideType)
        {
            this.sideType = sideType;
        }

        public SpaceConnection Space { get; set; }

        public IEnumerable<Stuff> Stuff => stuff;
    }

    public class Stuff
    {

        public Stuff(string description)
        {
            this.Description = description;
        }

        public string Description { get; set; }
    }

    public class SpaceConnection
    {
        private readonly Space space;
        private readonly IEnumerable<Block> blockedBy;

        public SpaceConnection(Space space, IEnumerable<Block> blockedBy)
        {
            this.space = space;
            this.blockedBy = blockedBy;
        }
    }

    public class Door : Block
    {
        public Door()
        {
            Description = "Это обычная дверь";
        }
    }

    public class Wall : Block
    {
        public Wall()
        {
            Description = "Обыкновенная стена";
        }

    }

    public class Space
    {
        private IDictionary<SideType, Side> sides = new Dictionary<SideType, Side>(4)
        {
            { SideType.North, new Side(SideType.North) },
            { SideType.South, new Side(SideType.South) },
            { SideType.West, new Side(SideType.West) },
            { SideType.East, new Side(SideType.East) }
        };

        public string Description { get; }
        private IEnumerable<Stuff> stuffs = new List<Stuff>();

        public Space(string description)
        {
            this.Description = description;
        }

        public void AddStuffTo(SideType sideType, IEnumerable<Stuff> stuffs)
        {
            sides[sideType].Stuff.Concat(stuffs);
        }

        public void AddStuff(IEnumerable<Stuff> stuffs)
        {
            this.stuffs.Concat(stuffs);
        }

        public void AddSpaceConnectionTo(SideType sideType, SpaceConnection spaceConnection)
        {
            sides[sideType].Space = spaceConnection;
        }

        public void Go()
        {
        }

        public void See()
        {

        }

        public void Observe()
        {

        }

    }

}
