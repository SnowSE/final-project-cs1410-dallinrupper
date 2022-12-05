using static DiceThrower.Dice;
using System;
using static CharacterCreation.CharacterFactory;
using static CharacterCreation.Character;
using CharacterCreation;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Set up for game
            var watch = new System.Diagnostics.Stopwatch();
            Console.Clear();
            string username = getUsername();
            Console.WriteLine($"Welcome {username} please create your character by pressing 'r' to roll.");
            (int strength, int dexterity, int maxLife) = rollForCharacter();
            int heal = maxLife;
            watch.Start();
            bool isAlive = true;
            Observe(isAlive, strength, dexterity, maxLife);

            // Start of game and first choice
            Console.WriteLine("You have woken up in The Labyrinth of the Black Desert.");
            Console.WriteLine("You see two doors which door do you choose?");
            Console.WriteLine("Left or Right?");

            while (true)
            {
                try
                {
                    string? choice = Console.ReadLine();
                    string? fixChoice = choice.ToLower();

                    if (fixChoice == "left")
                    {
                        Console.WriteLine("You fall into a pit of lava and are burned alive");
                        return;
                    }
                    else if (fixChoice == "right")
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
            Console.WriteLine("Please press 'r' to roll to see if your attack hits or press 'o' to see your stats.");

            while (Monster1Life > 0)
            {

                bool attackChance = rollForAttackEasy(isAlive, strength, dexterity, maxLife);
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
                        Console.WriteLine("Please press 'r' to roll to see if your attack hits or press 'o' to see your stats.");
                    }
                }
                else
                {
                    Console.WriteLine("You failed your attack and the monster attacks you.");
                    isAlive = Injure(Monster1Strength, ref maxLife, isAlive);
                    if (isAlive == false)
                    {
                        Console.Clear();
                        Console.WriteLine("You are dead.");
                        Environment.Exit(1);
                    }
                }
            }

            // Second choice
            Console.Clear();
            Console.WriteLine("You have defeted your first monster.");
            Console.WriteLine("You see two holes in the wall which hole do you choose?");
            Console.WriteLine("Left or Right?");

            while (true)
            {
                try
                {
                    string? choice = Console.ReadLine();
                    string? fixChoice = choice.ToLower();

                    if (fixChoice == "left")
                    {
                        Console.WriteLine("You found an exit to the cave and can't go back now.");
                        return;
                    }
                    else if (fixChoice == "right")
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

            // first boss encounter
            Console.Clear();
            Console.WriteLine("This monster is the boss of the floor goodluck.");
            (int boss1Strength, int boss1Dexterity, int boss1Life) = Monsters.Monster.FirstBossMonsterCreation();
            Console.WriteLine("Please press 'r' to roll to see if your attack hits or press 'o' to see your stats.");

            while (boss1Life > 0)
            {

                bool attackChance = rollForAttackEasy(isAlive, strength, dexterity, maxLife);
                if (attackChance == true)
                {
                    Console.WriteLine("Your attack suceeded.");
                    Monsters.Monster.MonsterInjure(strength, ref boss1Life);
                    if (boss1Life <= 0)
                    {
                        Console.WriteLine("You defeated the monster and it dropped an item.");
                    }
                    else
                    {
                        Console.WriteLine($"The monster is still alive: {boss1Life} hp left");
                        Console.WriteLine("Please press 'r' to roll to see if your attack hits or press 'o' to see your stats.");
                    }
                }
                else
                {
                    Console.WriteLine("You failed your attack and the monster attacks you.");
                    isAlive = Injure(boss1Strength, ref maxLife, isAlive);
                    if (isAlive == false)
                    {
                        Console.Clear();
                        Console.WriteLine("You are dead.");
                        Environment.Exit(1);
                    }
                }
            }

            // Player recives random item from the boss
            Random rnd = new Random();
            Items item = (Items)(new Random()).Next(1, 6);
            int damageModified = DamageModified(strength, item);// Players damage gets multiplied by the item they receive
            maxLife = heal;// this set maxLife back to it original value.

            // Third Choice
            Console.Clear();
            Console.WriteLine($"You defeted a floor boss and recived an item it is a {item}. It has also healed you.");
            Console.WriteLine("You come to a spiral stair case with a way going up and a way going down witch way do you choose?");
            while (true)
            {
                try
                {
                    string? choice = Console.ReadLine();
                    string? fixChoice = choice.ToLower();
                    //Easier Final Boss battle, last battle.
                    if (fixChoice == "up")
                    {
                        Console.WriteLine("You ran into the dungeon boss this will be hard.");
                        Console.WriteLine("This monster is the boss of the floor goodluck.");
                        (int boss2Strength, int boss2Dexterity, int boss2Life) = Monsters.Monster.FinalBossMonsterCreation();
                        Console.WriteLine("Please press 'r' to roll to see if your attack hits or press 'o' to see your stats.");
                        while (boss2Life > 0)
                        {

                            bool attackChance = rollForAttackEasy(isAlive, strength, dexterity, maxLife);
                            if (attackChance == true)
                            {
                                Console.WriteLine("Your attack suceeded.");
                                Monsters.Monster.MonsterInjure(damageModified, ref boss2Life);
                                if (boss2Life <= 0)
                                {
                                    Console.WriteLine("You defeated the monster and it dropped an item.");
                                }
                                else
                                {
                                    Console.WriteLine($"The monster is still alive: {boss2Life} hp left");
                                    Console.WriteLine("Please press 'r' to roll to see if your attack hits or press 'o' to see your stats.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("You failed your attack and the monster attacks you.");
                                isAlive = Injure(boss2Strength, ref maxLife, isAlive);
                                if (isAlive == false)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You are dead.");
                                    Environment.Exit(1);
                                }
                            }
                        }
                        break;
                    }
                    //Harder final boss battle, last battle.
                    else if (fixChoice == "down")
                    {
                        Console.WriteLine("You go down that stairs and the stairs start to disappear from behind you.");
                        Console.WriteLine("The Demon King appears infront of you. What will you do.");
                        (int boss3Strength, int boss3Dexterity, int boss3Life) = Monsters.Monster.DemonKingMonsterCreation();
                        Console.WriteLine("Please press 'r' to roll to see if your attack hits or press 'o' to see your stats.");
                        while (boss3Life > 0)
                        {

                            bool attackChance = rollForAttackEasy(isAlive, strength, dexterity, maxLife);
                            if (attackChance == true)
                            {
                                Console.WriteLine("Your attack suceeded.");
                                Monsters.Monster.MonsterInjure(damageModified, ref boss3Life);
                                if (boss3Life <= 0)
                                {
                                    Console.WriteLine("You defeated the monster and the game.");
                                }
                                else
                                {
                                    Console.WriteLine($"The monster is still alive: {boss3Life} hp left");
                                    Console.WriteLine("Please press 'r' to roll to see if your attack hits or press 'o' to see your stats.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("You failed your attack and the monster attacks you.");
                                isAlive = Injure(boss3Strength, ref maxLife, isAlive);
                                if (isAlive == false)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You are dead.");
                                    Environment.Exit(1);
                                }
                            }
                        }
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

            watch.Stop();

            // Write to HighScore file and tell user how long they played for.
            File.AppendAllText("HighScores.txt", $"{username}, {watch.Elapsed}\n");
            
            string[] Scores = File.ReadAllLines("HighScores.txt");
            foreach(var Score in Scores)
            {
                Console.WriteLine(Score);
            }
        }



    }
}



