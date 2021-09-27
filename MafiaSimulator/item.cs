namespace MafiaSimulator
{
    public class item
    {
        public item(string name, int type, int level)
        {
            myName = name;
            myType = type;
            myLevel = level;
        }

        private string myName;
        public string AccessName {get => myName;}

        private int myType;
        public int AccessType {get => myType;}

        private int myLevel;
        public int AccessLevel {get => myLevel;}
    }
}