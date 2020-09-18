using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Item
    {
        public string _name;
        public int _statBoost;
        private Item _longSword;
        private Item _dagger;
        private Item _bow;
        private Item _crossBow;
        private Item _bomb;
        private Item _claymore;

        public Item()
        {
            _statBoost = 25;
        }

        public Item(string nameVal, int statBoost)
        {
            _name = nameVal;
            _statBoost = statBoost;
        }

        public void IntialItems()
        {
            _longSword._name = "longsword";
            _longSword._statBoost = 15;
            _dagger._name = "dagger";
            _dagger._statBoost = 10;
            _bow._name = "bow";
            _bow._statBoost = 20;
            _crossBow._name = "CrossBow";
            _crossBow._statBoost = 10;
            _bomb._name = "Bomb";
            _bomb._statBoost = 10;
            _claymore._name = "Claymore";
            _claymore._statBoost = 10;
        }
        public void GetInput(out char input, string option1, string option2, string query)
        {
            input = ' ';
            //prints out the question
            Console.WriteLine(query);
            //prints out the option
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine(">");

            while (input != '1' && input != '2')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2')
                {
                    Console.WriteLine("invalid input");
                }
            }
        }

        public void SelectLoadout(Player player)
        {
            Console.WriteLine("Loadout 1: ");
            Console.WriteLine(_longSword._name);
            Console.WriteLine(_dagger._name);
            Console.WriteLine(_bow._name);
            Console.WriteLine("\nLoadout 2: ");
            Console.WriteLine(_crossBow._name);
            Console.WriteLine(_bomb._name);
            Console.WriteLine(_claymore._name);

            char input;
            GetInput(out input, "Loadout 1", "Loadout 2", "pick a weapon");
            {
                if(input == '1')
                {
                    player.AddItemToInv(_longSword, 0);
                    player.AddItemToInv(_dagger, 1);
                    player.AddItemToInv(_bow, 2);
                }
                else if(input == '2')
                {
                    player.AddItemToInv(_crossBow, 0);
                    player.AddItemToInv(_bomb, 1);
                    player.AddItemToInv(_claymore, 2);
                }
            }
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
