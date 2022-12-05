using System;
namespace DiceThrower
{

    public class Dice
    {
        // The method for a D20 dice
        public static int Throw20()
        {
            Random rnd = new Random();
            return rnd.Next(0, 20);
        }

        // Method for using a D50
        public static int Throw50()
        {
            Random rnd = new Random();
            return rnd.Next(0, 50);
        }

        // Method for D100 dice
        public static int Throw100()
        {
            Random rnd = new Random();
            return rnd.Next(0, 100);
        }

        public static int Throw1000()
        {
            Random rnd = new Random();
            return rnd.Next(50, 1000);
        }
    }
}