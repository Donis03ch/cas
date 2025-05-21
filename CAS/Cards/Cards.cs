using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.Cards
{
    internal class Cards
    {
        public void StartCards()
        {
            Console.WriteLine("Welcome to the Card Game!");

            // Initialize the deck
            List<string> deck = CreateDeck();
            ShuffleDeck(deck);

            // Initialize players
            List<Player> players = new List<Player>
            {
                new Player("Player 1"),
                new Player("Player 2")
            };

            // Deal cards to players
            DealCards(players, deck, 7);

            // Initialize the middle cards
            List<string> middleCards = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                middleCards.Add(deck[0]);
                deck.RemoveAt(0);
            }

            // Game loop
            bool gameOver = false;
            while (!gameOver)
            {
                foreach (var player in players)
                {
                    Console.WriteLine($"{player.Name}'s turn!");
                    Console.WriteLine($"Middle cards: {string.Join(", ", middleCards)}");
                    Console.WriteLine($"Your cards: {string.Join(", ", player.Cards)}");

                    // Player plays a card
                    Console.Write("Enter the index of the card you want to play: ");
                    int cardIndex = int.Parse(Console.ReadLine());

                    string playedCard = player.Cards[cardIndex];
                    player.Cards.RemoveAt(cardIndex);

                    Console.WriteLine($"{player.Name} played {playedCard}");

                    // Check if the played card matches the top card in the middle
                    if (playedCard == middleCards.Last())
                    {
                        Console.WriteLine($"{player.Name} collects the middle cards!");
                        player.CollectedCards.AddRange(middleCards);
                        middleCards.Clear();
                    }
                    else
                    {
                        middleCards.Add(playedCard);
                    }

                    // Check if the player has no cards left
                    if (player.Cards.Count == 0)
                    {
                        gameOver = true;
                        break;
                    }
                }
            }

            // Calculate scores and determine the winner
            Console.WriteLine("Game Over!");
            foreach (var player in players)
            {
                player.Score = CalculateScore(player.CollectedCards);
                Console.WriteLine($"{player.Name} scored {player.Score} points!");
            }

            var winner = players.OrderByDescending(p => p.Score).First();
            Console.WriteLine($"{winner.Name} wins with {winner.Score} points!");
        }

        static List<string> CreateDeck()
        {
            List<string> deck = new List<string>();
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    deck.Add($"{rank} of {suit}");
                }
            }

            // Add Jokers
            deck.Add("Joker");
            deck.Add("Joker");

            return deck;
        }

        static void ShuffleDeck(List<string> deck)
        {
            Random rng = new Random();
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = deck[k];
                deck[k] = deck[n];
                deck[n] = value;
            }
        }

        static void DealCards(List<Player> players, List<string> deck, int numberOfCards)
        {
            foreach (var player in players)
            {
                for (int i = 0; i < numberOfCards; i++)
                {
                    player.Cards.Add(deck[0]);
                    deck.RemoveAt(0);
                }
            }
        }

        static int CalculateScore(List<string> collectedCards)
        {
            int score = 0;
            foreach (var card in collectedCards)
            {
                if (card.Contains("Ace"))
                {
                    score += 4;
                }
                else if (card.Contains("King"))
                {
                    score += 3;
                }
                else if (card.Contains("Queen"))
                {
                    score += 2;
                }
                else if (card.Contains("Jack"))
                {
                    score += 1;
                }
                else if (card.Contains("Joker"))
                {
                    score += 5;
                }
                else
                {
                    score += 0;
                }
            }
            return score;
        }
    }

    class Player
    {
        public string Name { get; }
        public List<string> Cards { get; }
        public List<string> CollectedCards { get; }
        public int Score { get; set; }

        public Player(string name)
        {
            Name = name;
            Cards = new List<string>();
            CollectedCards = new List<string>();
            Score = 0;
        }
    }
}
