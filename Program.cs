using System;
namespace GameOfNims
{
    public class MainClass
    {
        public static void Main(string[] args) 
        {
            int stones = 100;
            int bStones = 0;
            Console.WriteLine("Welcome to the Game of Nims!");
            Console.WriteLine("The goal is to not be the person who takes the last stone out of 100.");
            Console.WriteLine("You must take at least one stone, and not more than half the pile.");
            Console.WriteLine("What difficulty would you like?");
            Console.WriteLine("[Easy] \t [Hard]");
            string input = Console.ReadLine();

            Random random = new Random();
            int randomNumber = random.Next();
            bool playerMoves = false;
            //easy difficulty starts here
            if (input == "easy" || input == "Easy")
            {
                Console.WriteLine("The game starts with 100 stones");
                //random number generated to determine who moves first
                if (randomNumber % 2 == 0)
                {
                    playerMoves = true;
                }
                if (playerMoves == true)
                {
                    //player moves first here
                    while (stones > 0 && stones <= 100)
                    {
                        if (stones == 1)
                        {
                            Console.WriteLine("You have to take the last stone. You lost.");
                            break;
                        }
                        while (playerMoves == true)
                        {
                            Console.WriteLine("How many stones do you take?");
                            stones = askInput(stones);
                            Console.WriteLine("There are " + stones + " stones left.");
                            playerMoves = false;
                        }
                        bStones = EasyBot(stones);
                        stones -= bStones;
                        if (stones == 0)
                        {
                            Console.WriteLine("The bot has taken the last stone. You WIN!");
                            break;
                        }
                        playerMoves = true;
                        Console.WriteLine("Bot takes " + bStones + " stones.");
                        Console.WriteLine("There are " + stones + " left.");

                    }
                }
                else
                {
                    //bot moves first here
                    Console.WriteLine("Starting with bot from here");
                    while (stones > 0 && stones <= 100)
                    {
                        bStones = EasyBot(stones);
                        stones -= bStones;
                        if (stones == 0)
                        {
                            Console.WriteLine("The bot has taken the last stone. You WIN!");
                            break;
                        }
                        playerMoves = true;
                        Console.WriteLine("Bot takes " + bStones + " stones.");
                        Console.WriteLine("There are " + stones + " left.");
                        if (stones == 1)
                        {
                            Console.WriteLine("You have to take the last stone. You lost.");
                            break;
                        }
                        while (playerMoves == true)
                        {
                            Console.WriteLine("How many stones do you take?");
                            stones = askInput(stones);
                            Console.WriteLine("There are " + stones + " stones left.");
                            playerMoves = false;
                        }

                    }
                }
            }
            //Hard difficulty starts here
            Console.WriteLine("The game starts with 100 stones");
            //random number generated to determine who moves first
            if (randomNumber % 2 == 0)
            {
                playerMoves = true;
            }
            if (playerMoves == true)
            {
                //player moves first here
                while (stones > 0 && stones <= 100)
                {
                    if (stones == 1)
                    {
                        Console.WriteLine("You have to take the last stone. You lost.");
                        break;
                    }
                    while (playerMoves == true)
                    {
                        Console.WriteLine("How many stones do you take?");
                        stones = askInput(stones);
                        Console.WriteLine("There are " + stones + " stones left.");
                        playerMoves = false;
                    }
                    bStones = hardBot(stones);
                    stones -= bStones;
                    if (stones == 0)
                    {
                        Console.WriteLine("The bot has taken the last stone. You WIN!");
                        break;
                    }
                    playerMoves = true;
                    Console.WriteLine("Bot takes " + bStones + " stones.");
                    Console.WriteLine("There are " + stones + " left.");

                }
            }
            else
            {
                //Bot moves first here
                while (stones > 0 && stones <= 100)
                {
                    if (stones == 1)
                    {
                        Console.WriteLine("The bot has to take the last stone. You WIN!");
                        break;
                    }
                    bStones = hardBot(stones);
                    stones -= bStones;
                    playerMoves = true;
                    Console.WriteLine("Bot takes " + bStones + " stones.");
                    Console.WriteLine("There are " + stones + " left.");
                    if (stones == 1)
                    {
                        Console.WriteLine("You have to take the last stone. You lost.");
                        break;
                    }
                    while (playerMoves == true)
                    {
                        Console.WriteLine("How many stones do you take?");
                        stones = askInput(stones);
                        Console.WriteLine("There are " + stones + " stones left.");
                        playerMoves = false;
                    }

                }
            }
            Console.WriteLine("Press any button to end program.");
            string finisher = Console.ReadLine();
        }

        public static int askInput(int inputStones)
        {
            //recieves input of game's total stones left, queries player for stones to remove, returns total stones left in game
            int stones = inputStones;
            string input;
            int pStones;
            while (true)
            {
                input = Console.ReadLine();
                pStones = int.Parse(input);
                if (pStones == 0 || pStones > (stones / 2))
                {
                    Console.WriteLine("Please enter a valid number");
                }
                else
                {
                    stones -= pStones;
                    return stones;
                }
            }
        }

        public static int EasyBot(int inputStones)
        {
            //receives total stones input, returns random number between 1 and stones/2
            if (inputStones == 1)
            {
                return 1;
            }
            int stones = inputStones;
            int bStones;
            Random random = new Random();
            bStones = random.Next(1, stones / 2);
            return bStones;
        }

        public static int hardBot(int inputStones)
        {
            //recieves total amount of stones in game, determines half of stones, finds max number in winning pattern to use
            if (inputStones == 1)
            {
                return 1;
            }
            int bStones;
            int halfStones = (inputStones) / 2;
            int n = 1;
            while (true)
            {
                bStones = (int)Math.Pow(2, n) - 1;
                if (bStones >= halfStones)
                {
                    break;
                }
                n++;
            }
            inputStones -= bStones;
            if (inputStones > halfStones)
            {
                inputStones -= EasyBot(inputStones);
            }

            return inputStones;
        }    
    }
}