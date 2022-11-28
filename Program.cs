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
            bool isAlive = true;

            Console.WriteLine("You have woken up in The Labyrinth of the Black Desert.");
            Console.WriteLine("You see two doors which door do you choose?");
            Console.WriteLine("Left or Right?");
            while (true)
            {
                try
                {
                    string? second = Console.ReadLine();
                    string? fixSecond = second.ToLower();

                    if (second == "left")
                    {
                        Console.WriteLine("You fall into a pit of lava and are burned alive");
                        return;
                    }
                    else if (second == "right")
                    {
                        Console.WriteLine("You open the door and see an enemy.");
                        break;

                    }
                    else
                    {
                        Console.WriteLine("Please enter Left or Right.");
                    }
                }
                catch
                {
                    Console.WriteLine("Please enther Left or Right.");
                }
            }

            Console.Clear();
            (int Monster1Strength, int Monster1Dexterity, int Monster1Life) = Monsters.Monster.MonsterCreation();
            Console.WriteLine("You encounter your first Monster. Time to start combat.");
            int damage = Damage(strength);

            Console.WriteLine("Please press 'r' to roll to see if your attack hits.");
            while (Monster1Life > 0)
            {

                bool attackChance = rollForAttackEasy();
                if (attackChance == true)
                {
                    Console.WriteLine("Your attack suceeded.");
                    int alive = Monsters.Monster.MonsterInjure(damage, ref Monster1Life);
                    if (alive <= 0)
                    {
                        Console.WriteLine("You defeated the monster");
                    }
                    else
                    {
                        Console.WriteLine("The monster is still alive");
                    }
                }
                else
                {
                    Console.WriteLine("You failed your attack and the monster attacks you.");
                    isAlive = Injure(Monster1Strength, ref maxLife, ref isAlive);
                    if(isAlive == false)
                    {
                        Console.WriteLine("You are dead.");
                        break;
                    }
                }
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
        public static bool rollForAttackEasy()
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



