using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var myRoom = new Space("Моя спальня. Я тут сплю.");
            myRoom.AddStuff(new List<Stuff>() { new Stuff("Это мой диван") });
            myRoom.AddStuffTo(SideType.East,new List<Stuff>() { new Stuff("Светильник в виде луны висит на стене") });
            var coridor = new Space("Это коридор");
            myRoom.AddSpaceConnectionTo(SideType.East, new SpaceConnection(coridor, new List<Block>() { new Door(), new Wall() }));
        }
    }
}
