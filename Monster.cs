namespace Monsters
{
    internal class Monster
    {
        static public (int, int, int)MonsterCreation()
        {
            int MonsterStrength = DiceThrower.Dice.Throw20();
            int MonsterDexterity = DiceThrower.Dice.Throw20();
            int MonsterLife = MonsterStrength * 5;
            var ret = (MonsterStrength, MonsterDexterity, MonsterLife);

            return ret;
        }
        
        static public void MonsterInjure()
        {

        }
    }
}