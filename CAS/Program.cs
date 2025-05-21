using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CAS.Blackjack;
using CAS.Poker;
namespace CAS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Welcome to CAS Games");
                Console.ResetColor();

                Console.WriteLine("\n Use the arrow keys to navigate and press \u001b[32mEnter/Return\u001b[0m key to select.");

                ConsoleKeyInfo key;
                int option = 0;
                bool isSelected = false;
                int left = Console.CursorLeft;
                int top = Console.CursorTop;

                string[] options = { "Blackjack", "Poker", "Cards" };

                while (!isSelected)
                {
                    Console.SetCursorPosition(left, top);

                    for (int i = 0; i < options.Length; i++) // Use 0-based index
                    {
                        if (i == option)
                        {
                            Console.WriteLine($"> \u001b[32m{options[i]}\u001b[0m <");
                        }
                        else
                        {
                            Console.WriteLine($"  {options[i]} ");
                        }
                    }

                    key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (option < options.Length - 1) option++;
                            break;
                        case ConsoleKey.UpArrow:
                            if (option > 0) option--;
                            break;
                        case ConsoleKey.Enter:
                            isSelected = true;
                            break;
                    }

                    Console.SetCursorPosition(left, top);
                    Console.Write(new string(' ', Console.WindowWidth * options.Length));
                    Console.SetCursorPosition(left, top);
                }

                Console.WriteLine($"\"You selected: {options[option]} ");

                switch (option)
                {
                    case 0:
                        Blackjack.Blackjack firstGame = new Blackjack.Blackjack();
                        firstGame.StartBlackJack();
                        break;
                    case 1:
                        Poker.Poker secondGame = new Poker.Poker();
                        secondGame.StartPoker();
                        break;
                    case 2:
                        Cards.Cards thirdGame = new Cards.Cards();
                        thirdGame.StartCards();
                        break;
                }

            }
        }
    }
}
