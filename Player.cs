using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player
    {
        private string _name;
        private int _health;
        private int _damage;

        public bool GetIsAlive()
        {
            return _health > 0;
        }

        public Player()
        {
            _health = 100;
            _damage = 10;
        }

        public Player(string nameVAl, int healthVal, int damageVAl)
        {
            _name = nameVAl;
            _health = healthVal;
            _damage = damageVAl;
        }

        public void EquipItem(Item weapon)
        {
            _damage += weapon.statBoost;
        }

        public void PrintStats()
        {
            Console.WriteLine("[" + _name + "]");
            Console.WriteLine("health: " + _health);
            Console.WriteLine("Damage: " + _damage);
        }
        public string GetName()
        {
            return _name;
        }

        public void Attack(Player enemy)
        {
            enemy.TakeDamage(_damage);
        }
       
        private void TakeDamage(int damageVal)
        {
            if(_health > 0)
            {
                _health -= damageVal;
            }
            Console.WriteLine(_name + " took " + damageVal + " damage!!!!");
        }

    }
}
