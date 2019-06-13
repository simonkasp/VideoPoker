using System;

namespace VideoPoker
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new PlayerHand();
            var index = 0;
            var message = new Message();
            var play = true;

            game.StartGame();

            while (play)
            {
                var input = " ";

                var messageLine = message.GetMenuMessage(index);

                while (!input.Equals("1") && !input.Equals("2") && !input.Equals("3"))
                {
                    Console.WriteLine(messageLine);                 
                    input = Console.ReadLine();

                    if (input.Equals("1"))
                    {
                        index = 0;
                        play = true;
                        game.StartGame();
                    }

                    else if (input.Equals("2") && index != 1)
                    {
                        index = 1;
                        game.ContinueGame();
                    }

                    else if (input.Equals("0"))
                    {
                        play = false;
                        Console.WriteLine("App is closing");
                        Environment.Exit(0);
                    }
                    else
                        Console.WriteLine("Wrong input, try again.");
                }
            }
        }
    }
}
