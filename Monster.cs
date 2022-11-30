namespace Monsters
{
    internal class Monster
    {
        static public (int, int, int) BasicMonsterCreation()
        {
            int MonsterStrength = DiceThrower.Dice.Throw20();
            int MonsterDexterity = DiceThrower.Dice.Throw20();
            int MonsterLife = MonsterStrength * 5;
            var ret = (MonsterStrength, MonsterDexterity, MonsterLife);
            return ret;
        }

        static public (int, int, int) FirstBossMonsterCreation()
        {
            int bossStrength = DiceThrower.Dice.Throw50();
            int bossDexterity = DiceThrower.Dice.Throw100();
            int bossLife = bossStrength * 3;
            var ret = (bossStrength, bossDexterity, bossLife);
            return ret;
        }

        static public (int, int, int) FinalBossMonsterCreation()
        {
            int bossStrength = DiceThrower.Dice.Throw50();
            int bossDexterity = DiceThrower.Dice.Throw100();
            int bossLife = bossStrength * 3;
            var ret = (bossStrength, bossDexterity, bossLife);
            return ret;
        }

        static public int MonsterInjure(int damage, ref int MonsterLife)
        {
            MonsterLife -= damage;
            return MonsterLife;
        }
    }
}