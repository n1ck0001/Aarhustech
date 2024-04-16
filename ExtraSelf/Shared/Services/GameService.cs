using Shared.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services
{
    public class GameService
    {
       
       


      
        public Player GetAStartingHandAsync(Player player)
        {
            int count = 0;
            while (count < 7)
            {
                var newCard = new Card { Color = "Placeholder", Value = 1, };
                Random random = new Random();
                int num = random.Next(0, 5);
                if (num == 1)
                {
                    newCard.Color = "Red";
                }
                if (num == 2)
                {
                    newCard.Color = "Yellow";
                }
                if (num == 3)
                {
                    newCard.Color = "Blue";
                }
                if (num == 4)
                {
                    newCard.Color = "Green";
                }

                Random randomValue = new Random();
                var num2 = randomValue.Next(-1, 10);

                if (num2 == 0)
                {
                    newCard.Value = 0;
                }
                if (num2 == 1)
                {
                    newCard.Value = 1;
                }
                if (num2 == 2)
                {
                    newCard.Value = 2;
                }
                if (num2 == 3)
                {
                    newCard.Value = 3;
                }
                if (num2 == 4)
                {
                    newCard.Value = 4;
                }
                if (num2 == 5)
                {
                    newCard.Value = 5;
                }
                if (num2 == 6)
                {
                    newCard.Value = 6;
                }
                if (num2 == 7)
                {
                    newCard.Value = 7;
                }
                if (num2 == 8)
                {
                    newCard.Value = 8;
                }
                if (num2 == 9)
                {
                    newCard.Value = 9;
                }
                count++;
                player.Cards.Add(newCard);

            }
            return player;
        }
    }
}
