using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player
    {
        private string _name;
        private int _health;
        public int _baseDamage;
        private Item[] _inventory;
        private Item _currentWeapon;
        private Item _hands;
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
            _baseDamage = 10;
            _hands._name = "fists";
            _hands._statBoost = 0;
        }

        public Player(string nameVAl, int healthVal, int damageVAl, int inventorySize)
        {
            _name = nameVAl;
            _health = healthVal;
            _baseDamage = damageVAl;
            _inventory = new Item[inventorySize];
            _hands._name = "fists";
            _hands._statBoost = 0;
        }

        public void EquipItem(int itemIndex)
        {
            if (Contains(itemIndex))
            {
                _currentWeapon = _inventory[itemIndex];
            }
        }

        public void UnequipItem()
        {
<<<<<<< Updated upstream
            _currentWeapon = _hands;
        }
        public Item[] GetInv()
        {
            return _inventory;
        }

        public bool Contains(int itemIndex)
        {
            if(itemIndex > 0 && itemIndex < _inventory.Length)
            {
                return true;
            }
            return false;
        }
        public void AddItemToInv(Item item, int index)
        {
=======
>>>>>>> Stashed changes
            _inventory[index] = item;
        }

        public void PrintStats()
        {
            Console.WriteLine("[" + _name + "]");
            Console.WriteLine("health: " + _health);
            Console.WriteLine("Damage: " + _baseDamage);
        }
        public string GetName()
        {
            return _name;
        }

        public void Attack(Player enemy)
        {
            int totalDamage = _baseDamage + _currentWeapon._statBoost;
            enemy.TakeDamage(totalDamage);
        }

        

        public void PowerAttack(Player enemy)
        {
            _baseDamage += 10;
            enemy.TakeDamage(_baseDamage);
            _baseDamage -= 10;
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
