﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{

    class Game
    {
        private bool _gameOver = false;
        private Player _player1;
        private Player _player2;
        private Item _longSword;
        private Item _dagger;
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
                _player2.AddItemToInv(_dagger, 0);
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

        public void startBattle()
        {
            Console.WriteLine("BATTLE");
            while(_player1.GetIsAlive() && _player2.GetIsAlive())
            {
                _player1.PrintStats();

                
                _player2.PrintStats();

                char input;
                GetInput(out input, "Attack", "Repair weapon", "\nPlayer1's turn");
                if(input == '1')
                {
                    Console.Clear();
                    _player1.Attack(_player2);
                }
                else if(input == '2')
                {
                    Console.Clear();
                    Console.WriteLine("\nPlayer1 did a funny scream");
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
                    _player2.Attack(_player1);
                }
                else if (input == '2')
                {
                    Console.Clear();
                    Console.WriteLine("\nPlayer2 did a funny scream");
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
