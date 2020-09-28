using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HelloWorld
{

    class Game
    {
        private bool _gameOver = false;
        private Player _player1;
        private Player _player2;
        private Character _player1Partner;
        private Character _player2Partner;
        private Item _longSword;
        private Item _dagger;
        private Item _bow;
        private Item _crossBow;
        private Item _bomb;
        private Item _claymore;

        //Run the game
        public void Run()
        {
            Start();

            while(_gameOver == false)
            {
                Update();
            }
            End();
        }


        //void for input
        public void GetInput(out char input, string option1, string option2, string query)
        {
            input = ' ';
            //prints out the question
            Console.WriteLine(query);
            //prints out the option
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine(">");

            while(input != '1' && input != '2')
            {
                input = Console.ReadKey().KeyChar;
                if(input != '1' && input != '2')
                {
                    Console.WriteLine("invalid input");
                }
            }
        }

        public void GetInput(out char input, string option1, string option2, string option3, string query)
        {
            input = ' ';
            //prints out the question
            Console.WriteLine(query);
            //prints out the option
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine("3. " + option3);
            Console.WriteLine(">");

            while (input != '1' && input != '2' && input != '3')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2' && input != '3')
                {
                    Console.WriteLine("invalid input");
                }
            }
        }

        public void Save()
        {
            //Create a new stream writer
            StreamWriter writer = new StreamWriter("SaveData.txt");
            //Call save for both instances for players
            _player1.Save(writer);
            _player2.Save(writer);
            //close
            writer.Close();
        }

        public void OpenMainMenu()
        {
            char input;
            GetInput(out input, "create character", "load character", "what do you want to do?"
            if(input == '2')
            {
                _player1 = new Player();
                _player2 = new Player();
                Load();
                return;
            }
            CreateCharacter(ref _player1);
            CreateCharacter(ref _player2);
        }
        public void Load()
        {
            //create a new stream reader
            StreamReader reader = new StreamReader("SaveData.txt");
            //Call load for each instance of player to load data
            _player1.Load(reader);
            _player2.Load(reader);
            //close reader
            reader.Close();
        }

        
        //equips items to the player
        public void EquipItem()
        {
            GetInput(out char input, "LongSword", "Dagger", "\nchoose your weapon, player 1");
            
            if (input == '1')
            {
                _player1.AddItemToInv(_longSword, 0);
            }
            else if (input == '2')
            {
                _player1.AddItemToInv(_dagger, 0);
            }
            else
            {
                Console.WriteLine("invalid input");
            }

            GetInput(out input, "LongSword", "Dagger", "choose your weapon, player 2");

            if (input == '1')
            {
                _player2.AddItemToInv(_longSword, 0);
            }
            else if (input == '2')
            {
                _player2.AddItemToInv(_dagger, 0);
            }

            Console.WriteLine("\nPlayer1 stats");
            _player1.PrintStats();

            Console.WriteLine("\nPlayer2 stats");
            _player2.PrintStats();
            Console.ReadKey();
            Console.Clear();
        }

        public void CreateCharacter(ref Player player)
        {
            Console.WriteLine("what is your name?");
            string name = Console.ReadLine();
            player = new Player(name, 100, 10, 5);
        }

        public void SwitchWeapons(Player player)
        {
            Item[] inventory = player.GetInv();

            char input= ' ';
            for(int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine((i+1) + ". " + inventory[i]._name + " \n Damage: " + inventory[i]._statBoost);
            }
            Console.WriteLine(">");
            input = Console.ReadKey().KeyChar;
            switch (input)
            {
                case '1':
                    {
                        player.EquipItem(0);
                        Console.WriteLine("you equipped " + inventory[0]._name);
                        Console.WriteLine("Base damage increased by: " + inventory[0]._statBoost);
                        break;
                    }
                case '2':
                    {
                        player.EquipItem(1);
                        Console.WriteLine("you equipped " + inventory[1]._name);
                        Console.WriteLine("Base damage increased by: " + inventory[1]._statBoost);
                        break;
                    }
                case '3':
                    {
                        player.EquipItem(2);
                        Console.WriteLine("you equipped " + inventory[2]._name);
                        Console.WriteLine("Base damage increased by: " + inventory[2]._statBoost);
                        break;                                                                        
                    }
                default:
                    {
                        player.UnequipItem();
                        Console.WriteLine("You dropped your weapons good luck :)");
                        break;
                    }
            
            }

            
        }



        public void startBattle()
        {
            Console.WriteLine("BATTLE");
            while(_player1.GetIsAlive() && _player2.GetIsAlive())
            {
                _player1.PrintStats();

                
                _player2.PrintStats();

                char input;
                GetInput(out input, "Attack", "Change weapon", "\nPlayer1's turn");
                if(input == '1')
                {
                    Console.Clear();
                    float damageTaken = _player1.Attack(_player2);
                    Console.WriteLine(_player1.GetName() + " did " + damageTaken + " damage.");
                    damageTaken = _player1Partner.Attack(_player2);
                    Console.WriteLine(_player1Partner.GetName() + " did " + damageTaken + " damage.");
                }
                else if(input == '2')
                {
                    Console.Clear();
                    SwitchWeapons(_player1);
                }

                if(_player2.GetIsAlive(false))
                {
                    Console.WriteLine(_player2.GetName() + " has been killed");
                    Console.WriteLine("Press any button to continue");
                    Console.WriteLine(">");
                    Console.ReadKey();
                    _gameOver = true;
                    return;
                }
                Console.WriteLine("\n[Player1 stats]");
                _player1.PrintStats();

                Console.WriteLine("\n[Player2 stats]");
                _player2.PrintStats();


                GetInput(out input, "attack", "Scream", "\nPlayer2's turn");
                if (input == '1')
                {
                    Console.Clear();
                    float damageTaken  = _player2.Attack(_player1);
                    Console.WriteLine(_player2.GetName() + " did " + damageTaken + " damage.");
                    damageTaken = _player2Partner.Attack(_player2);
                    Console.WriteLine(_player2Partner.GetName() + " did " + damageTaken + " damage.");
                }
                else if (input == '2')
                {
                    Console.Clear();
                    SwitchWeapons(_player2);
                }

            }
        }

        //Performed once when the game begins
        public void Start()
        {
            _longSword = new Item("longSword", 40);
            _dagger = new Item("dagger", 20);
            CreateCharacter(ref _player1);
            CreateCharacter(ref _player2);
            _player1Partner = new Wizard(120, "Wizard Lizard", 20, 100);
            _player2Partner = new Wizard(120, "Harry 101", 20, 100);
        }

        //Repeated until the game ends
        public void Update()
        {
            EquipItem();
            startBattle();
        }

        //Performed once when the game ends
        public void End()
        {
            Console.WriteLine("game over");
        }


    }
}
