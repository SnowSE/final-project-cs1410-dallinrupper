using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
namespace CharacterCreation
{
    public class Character
    {
        int _strength;
        int _dexterity;
        int _life;
        bool _isAlive;
        // the players stats will be put into this method.
        public Character(int strength, int dexterity, int maxLife)
        {
            _strength = strength;
            _dexterity = dexterity;
            _life = maxLife;
            _isAlive = true;
        }
        // the method for showing that the player was hit and seeing if they are still alive
        public void Injure(int damage)
        {
            Console.Write("Direct hit!");
            _life -= damage;
            if (_life <= 0)
            {
                Console.Write("Death");
                _isAlive = false;
            }
        }
        // the method for getting how much damage the player will do
        public int Damage()
        {
            int damage = _strength;
            return damage;
        }
        // the mthod to show the players stats throughout the game.
        public string Observe()
        {
            var description = new StringBuilder();

            if (_isAlive)
            {

                description.AppendLine($"Strength: {this._strength}");
                description.AppendLine($"Dexterity: {this._dexterity}");
                description.AppendLine($"Life: {this._life}");

            }
            else
            {
                description.AppendLine("Dead body");
            }

            return description.ToString();
        }
    }
}