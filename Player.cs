using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player
    {
        private string _name;
        private int _health;
        public int _damage;
        private Item[] _inventory;
        public bool GetIsAlive()
        {
            return _health > 0;
        }

        public bool GetIsAlive(bool Alive = false)
        {
            return _health <= 0;
        }

        public Player()
        {
            _inventory = new Item[3];
            _health = 400;
            _damage = 10;
        }

        public Player(string nameVAl, int healthVal, int damageVAl, int inventorySize)
        {
            _name = nameVAl;
            _health = healthVal;
            _damage = damageVAl;
            _inventory = new Item[inventorySize];
        }

        public void EquipItem(int itemIndex)
        {
           
            _damage = _inventory[itemIndex].GetStatBoost();
        }

        public void AddItemToInv(Item item, int index)
        {

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

        public void PowerAttack(Player enemy)
        {
            _damage += 10;
            enemy.TakeDamage(_damage);
            _damage -= 10;
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
