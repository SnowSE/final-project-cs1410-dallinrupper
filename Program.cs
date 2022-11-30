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
            // Set up for game
            var watch = new System.Diagnostics.Stopwatch();
            Console.Clear();
            Console.WriteLine("Welcome player please create your character by pressing 'r' to roll.");
            (int strength, int dexterity, int maxLife) = rollForCharacter();
            watch.Start();
            Observe(true, strength, dexterity, maxLife);
            bool isAlive = true;

            // Start of game and first choice
            Console.WriteLine("You have woken up in The Labyrinth of the Black Desert.");
            Console.WriteLine("You see two doors which door do you choose?");
            Console.WriteLine("Left or Right?");
            while (true)
            {
                try
                {
                    string? second = Console.ReadLine();
                    string? fixSecond = second.ToLower();

                    if (fixSecond == "left")
                    {
                        Console.WriteLine("You fall into a pit of lava and are burned alive");
                        return;
                    }
                    else if (fixSecond == "right")
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

            // First monster encounter
            Console.Clear();
            (int Monster1Strength, int Monster1Dexterity, int Monster1Life) = Monsters.Monster.BasicMonsterCreation();
            Console.WriteLine("You encounter your first Monster. Time to start combat.");

            Console.WriteLine("Please press 'r' to roll to see if your attack hits.");
            while (Monster1Life > 0)
            {

                bool attackChance = rollForAttackEasy();
                if (attackChance == true)
                {
                    Console.WriteLine("Your attack suceeded.");
                    Monsters.Monster.MonsterInjure(strength, ref Monster1Life);
                    if (Monster1Life <= 0)
                    {
                        Console.WriteLine("You defeated the monster");
                    }
                    else
                    {
                        Console.WriteLine($"The monster is still alive: {Monster1Life} hp left");
                    }
                }
                else
                {
                    Console.WriteLine("You failed your attack and the monster attacks you.");
                    isAlive = Injure(Monster1Strength, ref maxLife, ref isAlive);
                    if (isAlive == false)
                    {
                        Console.WriteLine("You are dead.");
                        Environment.Exit(1);
                    }
                }
            }

            // Second choice
            Console.WriteLine("You have defeted your first monster. It has dropped nothing however it healed you.");
            Console.WriteLine("You see two holes in the wall which hole do you choose?");
            Console.WriteLine("Left or Right?");
            while (true)
            {
                try
                {
                    string? second = Console.ReadLine();
                    string? fixSecond = second.ToLower();

                    if (fixSecond == "left")
                    {
                        Console.WriteLine("You found an exit to the cave and can't go back now.");
                        return;
                    }
                    else if (fixSecond == "right")
                    {
                        Console.WriteLine("You go through the hole and it closes behind you. You see a monster that is much bigger than before.");
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

            // first boss encounter, need to create heal feature.
            Console.Clear();
            Console.WriteLine("This monster is the boss of the floor goodluck.");
            (int boss1Strength, int boss1Dexterity, int boss1Life) = Monsters.Monster.FirstBossMonsterCreation();
            Console.WriteLine("Please press 'r' to roll to see if your attack hits.");
            while (boss1Life > 0)
            {

                bool attackChance = rollForAttackEasy();
                if (attackChance == true)
                {
                    Console.WriteLine("Your attack suceeded.");
                    Monsters.Monster.MonsterInjure(strength, ref boss1Life);
                    if (boss1Life <= 0)
                    {
                        Console.WriteLine("You defeated the monster");
                    }
                    else
                    {
                        Console.WriteLine($"The monster is still alive: {boss1Life} hp left");
                    }
                }
                else
                {
                    Console.WriteLine("You failed your attack and the monster attacks you.");
                    isAlive = Injure(boss1Strength, ref maxLife, ref isAlive);
                    if (isAlive == false)
                    {
                        Console.WriteLine("You are dead.");
                        break;
                    }
                }
            }
            watch.Stop();
            
            //File.WriteAllText("Scores.txt", watch.Elapsed);
            Console.WriteLine($"Time played: {watch.Elapsed}");
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
                // else if (roll == "o")
                // {
                //     Observe(true, strength, dexterity, maxLife);
                // }
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



