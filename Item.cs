using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Item
    {
        private string _name;
        private int _statBoost;


        public Item()
        {
            _statBoost = 25;
        }

        public Item(string nameVal, int statBoost)
        {
            _name = nameVal;
            _statBoost = statBoost;
        }

        public void ItemDurability(Item weapon)
        {
            for(int i = 0; i < 5 ; i++)
            {
                char input = ' ';
                if (input == '2')
                {
                    Console.WriteLine("you've repaired your weapon");
                    i = 0;
                }

                _statBoost -= 5;
                if(i==0)
                {
                    _statBoost = weapon._statBoost;
                }

                if(i==3)
                {
                    Console.WriteLine("your weapong is starting to crack");
                }
                else if(i==5)
                {
                    _statBoost = 0;
                    Console.WriteLine("your weapon broke you must fix it");
                }


                
            }
        }

        public int GetStatBoost()
        {
            return _statBoost;
        }
    }
}
