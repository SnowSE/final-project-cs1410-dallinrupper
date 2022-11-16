using static DiceThrower.Dice;
using System;
using static CharacterCreation.CharacterFactory;
using static CharacterCreation.Character;


namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome player please create your character by pressing 'r' to roll.");
            rollForCharacter();
            // CharacterCreation.Character.Observe();


            Console.WriteLine("You have woken up in The Labyrinth of the Black Desert.");

        }
        public static void rollForCharacter()
        {
            while (true)
            {

                var roll = Console.ReadLine();
                if (roll == "r")
                {
                    var character = CharacterCreation.CharacterFactory.Generate();
                    break;
                    //return character;
                }
                else
                {
                    Console.WriteLine("Please enter r to roll.");
                }
            }

        }
    }
}



