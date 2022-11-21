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
            Console.Clear();
            Console.WriteLine("Welcome player please create your character by pressing 'r' to roll.");
            (int strength, int dexterity, int maxLife) = rollForCharacter();
            Observe(true, strength, dexterity, maxLife);

            Console.WriteLine("You have woken up in The Labyrinth of the Black Desert.");
            Console.WriteLine("You see two doors which door do you choose?");
            Console.WriteLine("Left or Right?");
            while (true)
            {
                try
                {
                    var second = Console.ReadLine();

                    if (second == "Left")
                    {
                        Console.WriteLine("You fall into a pit of lava and are burned alive");
                        return;
                    }
                    else if (second == "Right")
                    {
                        Console.WriteLine("You open the door and see an enemy.");
                        break;

                    }
                    else
                    {
                        Console.WriteLine("Please enther Left or Right.");
                    }
                }
                catch
                {
                    Console.WriteLine("Please enther Left or Right.");
                }
            }

            Console.Clear();
            Console.WriteLine("You encounter your first Monster. Time to start combat.");
            int damage = Damage(strength);
            Console.WriteLine("Please press 'r' to roll to see if your attack hits.");
            bool attackChance = rollForAttack();
            if (attackChance == true)
            {

            }
            else
            {

            }












        }







        public static (int, int, int) rollForCharacter()
        {
            while (true)
            {

                var roll = Console.ReadLine();
                if (roll == "r")
                {
                    var character = CharacterCreation.CharacterFactory.Generate();
                    return character;
                }
                else
                {
                    Console.WriteLine("Please enter r to roll.");
                }
            }

        }
        public static bool rollForAttack()
        {
            while (true)
            {

                var roll = Console.ReadLine();
                if (roll == "r")
                {
                    int attackChance = Throw100();
                    if (attackChance < 25)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                }
                else
                {
                    Console.WriteLine("Please enter r to roll.");
                }
            }

        }
    }
}



