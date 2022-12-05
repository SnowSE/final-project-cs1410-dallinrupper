namespace TestProject;
using Monsters;
using DiceThrower;
using CharacterCreation;


public class Tests
{
    [SetUp]
    public void Setup()
    {
    }


    [Test]

    public void MonsterInjureTestTrue()
    {
        var MonsterHealth = 10;
        var damage = 1;

        Monster.MonsterInjure(damage, ref MonsterHealth);
        var expected = 9;

        Assert.AreEqual(MonsterHealth, expected);
    }

    [Test]
        public void MonsterInjureTestFalse()
    {
        var MonsterHealth = 10;
        var damage = 1;

        Monster.MonsterInjure(damage, ref MonsterHealth);
        var notExpected = 10;

        Assert.AreNotEqual(MonsterHealth, notExpected);
    }

    [Test]
    public void DamageModifiedTestTrue()
    {
        var strength = 3;
        Items item = Items.Sword;


        var damage = Character.DamageModified(strength, item);
        var expected = 9;

        Assert.AreEqual(damage,expected);
    }

     [Test]
    public void DamageModifiedTestFalse()
    {
        var strength = 3;
        Items item = Items.Sword;


        var damage = Character.DamageModified(strength, item);
        var expected = 10;

        Assert.AreNotEqual(damage,expected);
    }

    [Test]
    public void InjureTestmaxLifeEqual()
    {
        var strength = 3;
        var maxLife = 100;
        var isAlive = true;


        Character.Injure(strength, ref maxLife, isAlive);
        var expected = 97;

        Assert.AreEqual(maxLife,expected);
    }

    [Test]
    public void InjureTestmaxLifeNotEqual()
    {
        var strength = 3;
        var maxLife = 100;
        var isAlive = true;


        Character.Injure(strength, ref maxLife, isAlive);
        var expected = 100;

        Assert.AreNotEqual(maxLife,expected);
    }

    [Test]
    public void ObserveTestTrue()
    {
        var strength = 3;
        var maxLife = 100;
        var dexterity = 5;
        var isAlive = true;


        Character.Observe(isAlive, strength, dexterity, maxLife);

        Assert.Pass();
    }

    [Test]
    public void ObserveTestFalse()
    {
        var strength = 3;
        var maxLife = 100;
        var dexterity = 5;
        var isAlive = false;


        Character.Observe(isAlive, strength, dexterity, maxLife);

        Assert.Pass();
    }
}