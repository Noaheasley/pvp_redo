using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    struct Player
    {
        public int health;
        public int damage;
    }
    struct Item
    {
        public int statBoost;
    }

    class Game
    {
        bool _gameOver = false;
        Player _player1;
        Player _player2;
        Item longSword;
        Item dagger;
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

        //initalizes the players stats
        public void InitalizePlayer()
        {
            _player1.health = 100;
            _player1.damage = 5;

            _player2.health = 100;
            _player2.damage = 5;
        }

        //initalizes the item stats
        public void InitalizeItems()
        {
            longSword.statBoost = 15;
            dagger.statBoost = 10;
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

        //equips items to the player
        public void EquipItem()
        {
            GetInput(out char input, "LongSword", "Dagger", "\nchoose your weapon, Player1");
            
            if (input == '1')
            {
                _player1.damage += longSword.statBoost;
            }
            else if (input == '2')
            {
                _player1.damage += dagger.statBoost;
            }
            else
            {
                Console.WriteLine("invalid input");
            }

            GetInput(out input, "LongSword", "Dagger", "choose your weapon, Player2");

            if (input == '1')
            {
                _player2.damage += longSword.statBoost;
            }
            else if (input == '2')
            {
                _player2.damage += dagger.statBoost;
            }

            Console.WriteLine("\nPlayer1 stats");
            ViewStats(_player1);

            Console.WriteLine("\nPlayer2 stats");
            ViewStats(_player2);
            Console.ReadKey();
            Console.Clear();
        }

        public void ViewStats(Player player)
        {
            Console.WriteLine("Health: " + player.health);
            Console.WriteLine("Damage: " + player.damage);
        }

        public void startBattle()
        {
            Console.WriteLine("BATTLE");
            while(_player1.health > 0 && _player2.health > 0)
            {
                Console.WriteLine("\n[Player1 stats]");
                ViewStats(_player1);

                Console.WriteLine("\n[Player2 stats]");
                ViewStats(_player2);

                char input;
                GetInput(out input, "attack", "Scream", "\nPlayer1's turn");
                if(input == '1')
                {
                    Console.Clear();
                    _player2.health -= _player1.damage;
                    Console.WriteLine("\nPlayer1 dealt " + _player1.damage);
                    Console.WriteLine("Player2 has " + _player2.health + " health remainging");
                }
                else if(input == '2')
                {
                    Console.Clear();
                    Console.WriteLine("\nPlayer1 did a funny scream");
                }

                if(_player2.health <= 0)
                {
                    Console.WriteLine("Player2 has been defeated");
                    Console.ReadKey();
                    _gameOver = true;
                    Console.Clear();
                    return;
                }

                Console.WriteLine("\n[Player1 stats]");
                ViewStats(_player1);

                Console.WriteLine("\n[Player2 stats]");
                ViewStats(_player2);


                GetInput(out input, "attack", "Scream", "\nPlayer2's turn");
                if (input == '1')
                {
                    Console.Clear();
                    _player1.health -= _player2.damage;
                    Console.WriteLine("\nPlayer2  has dealt " + _player2.damage);
                    Console.WriteLine("Player1 has " + _player1.health + " health remaining");
                }
                else if (input == '2')
                {
                    Console.Clear();
                    Console.WriteLine("\nPlayer2 did a funny scream");
                }
                if (_player1.health <= 0)
                {
                    Console.WriteLine("Player1 has been defeated");
                    Console.ReadKey();
                    _gameOver = true;
                    Console.Clear();
                    return;
                }
            }
        }

        //Performed once when the game begins
        public void Start()
        {
            InitalizePlayer();
            InitalizeItems();
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
            if (_player1.health <= 0)
            {
                Console.WriteLine("Player1 lost, press any key to end the game.");

            }
            else if(_player2.health <= 0)
            {
                Console.WriteLine("Player2 lost, press any key to end the game.");
            }
        }
    }
}
