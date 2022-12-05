using static DiceThrower.Dice;
namespace CharacterCreation
{
    internal class CharacterFactory
    {
        // The place where the game will roll and create the players stats and store them into the character class
        static public (int, int, int) Generate()
        {
            int strength = DiceThrower.Dice.Throw20();
            int dexterity = DiceThrower.Dice.Throw20();
            int maxLife = strength * 5;
            var ret = (strength, dexterity, maxLife);

            return ret;
        }

        // Method for getting the players username atleast 3 characters long.
        public static string getUsername()
        {
            Console.WriteLine("Please enter your username.");
            while (true)
            {
                try
                {
                    string? username = Console.ReadLine();
                    if (username.Length < 3)
                    {
                        Console.WriteLine("Please enter a username with more than 3 characters.");
                    }
                    else
                    {
                        return username;
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter a valid username");
                }
            }
        }
    }
}