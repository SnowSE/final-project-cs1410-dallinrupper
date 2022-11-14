using System;
namespace DiceThrower
{

    internal class Dice
    {
        // The method for a D20 dice
        public static int Throw()
        {
            Random rnd = new Random();
            return rnd.Next(0, 20);
        }
        // Method for using a D20 dice with your item
        public static int Throw(int modifier)
        {
            Random rnd = new Random();
            return rnd.Next(0, 20) + modifier;
        }
        enum Items { Sword, Knife, Gun, Sheild, Rifle }


    }
}