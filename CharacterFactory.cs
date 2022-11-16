using static DiceThrower.Dice;
namespace CharacterCreation
{
    internal class CharacterFactory
    {
        // The place where the game will roll and create the players stats and store them into the character class
        static public Character Generate()
        {
            int strength = DiceThrower.Dice.Throw();
            int dexterity = DiceThrower.Dice.Throw();
            int maxLife = strength * 5;
            var ret = new Character(strength, dexterity, maxLife);

            return ret;
        }
    }
}