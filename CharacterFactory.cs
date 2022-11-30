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
    }
}