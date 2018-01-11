namespace ClassLibrary1
{
    public class Stuff:IStuff
    {

        public Stuff(string description)
        {
            this.Description = description;
        }

        public string Description { get; set; }
    }
}