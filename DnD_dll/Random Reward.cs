using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD.Equipment;

namespace DnD
{
    public static class RandomReward
    {
        public static Tuple<List<Item>, List<Coin>> GenerateTreasure(int SW)
        {
#warning bieda funkcja
            List<Item> items = new List<Item>();
            List<Coin> coins = new List<Coin>();

            int roll;
            switch(SW)
            {

                case 1:
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 15) ;
                    else if (roll < 30) coins.Add(new Coin(CoinType.Copper, Dice.Roll(Dice.Type.k6) * 1000));
                    else if (roll < 53) coins.Add(new Coin(CoinType.Silver, Dice.Roll(Dice.Type.k8) * 100)); 
                    else if (roll < 96) coins.Add(new Coin(CoinType.Gold,   Dice.Roll(Dice.Type.k8, 2) * 10)); 
                    else                coins.Add(new Coin(CoinType.Platinium, Dice.Roll(Dice.Type.k4) * 10));
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 91) ;
                    else if (roll < 96) items.Add(new Item("Klejnot"));
                    else                items.Add(new Item("Dzieło sztuki"));
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 72) ;
                    else if (roll < 96) items.Add(new Item("Zwykły przedmiot"));
                    else                items.Add(new Item("Słaby przedmiot magiczny"));
                    break;
                case 2:
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 14) ;
                    else if (roll < 24) coins.Add(new Coin(CoinType.Copper, Dice.Roll(Dice.Type.k10) * 1000));
                    else if (roll < 44) coins.Add(new Coin(CoinType.Silver, Dice.Roll(Dice.Type.k10, 2) * 100));
                    else if (roll < 96) coins.Add(new Coin(CoinType.Gold,   Dice.Roll(Dice.Type.k10, 4) * 10));
                    else                coins.Add(new Coin(CoinType.Platinium, Dice.Roll(Dice.Type.k8, 2) * 10));
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 82) ;
                    else if (roll < 96) { roll = Dice.Roll(Dice.Type.k3); for (int i = 0; i < roll; i++) items.Add(new Item("Klejnot")); }
                    else                { roll = Dice.Roll(Dice.Type.k3); for (int i = 0; i < roll; i++) items.Add(new Item("Dzieło sztuki")); }
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 50) ;
                    else if (roll < 86) items.Add(new Item("Zwykły przedmiot"));
                    else                items.Add(new Item("Słaby przedmiot magiczny"));
                    break;
                case 3:
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 12) ;
                    else if (roll < 22) coins.Add(new Coin(CoinType.Copper, Dice.Roll(Dice.Type.k10, 2) * 1000));
                    else if (roll < 42) coins.Add(new Coin(CoinType.Silver, Dice.Roll(Dice.Type.k8, 4) * 100));
                    else if (roll < 96) coins.Add(new Coin(CoinType.Gold,   Dice.Roll(Dice.Type.k4, 1) * 100));
                    else                coins.Add(new Coin(CoinType.Platinium, Dice.Roll(Dice.Type.k10, 1) * 10));
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 78) ;
                    else if (roll < 96) { roll = Dice.Roll(Dice.Type.k3); for (int i = 0; i < roll; i++) items.Add(new Item("Klejnot")); }
                    else                { roll = Dice.Roll(Dice.Type.k3); for (int i = 0; i < roll; i++) items.Add(new Item("Dzieło sztuki")); }
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 50) ;
                    else if (roll < 80) { roll = Dice.Roll(Dice.Type.k3); for (int i = 0; i < roll; i++) items.Add(new Item("Zwykły przedmiot")); }
                    else                items.Add(new Item("Słaby przedmiot magiczny"));
                    break;
                case 4:
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 12) ;
                    else if (roll < 22) coins.Add(new Coin(CoinType.Copper, Dice.Roll(Dice.Type.k10, 3) * 1000));
                    else if (roll < 42) coins.Add(new Coin(CoinType.Silver, Dice.Roll(Dice.Type.k12, 4) * 100));
                    else if (roll < 96) coins.Add(new Coin(CoinType.Gold,   Dice.Roll(Dice.Type.k6, 1) * 100));
                    else                coins.Add(new Coin(CoinType.Platinium, Dice.Roll(Dice.Type.k8, 1) * 10));
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 71) ;
                    else if (roll < 96) { roll = Dice.Roll(Dice.Type.k4); for (int i = 0; i < roll; i++) items.Add(new Item("Klejnot")); }
                    else                { roll = Dice.Roll(Dice.Type.k3); for (int i = 0; i < roll; i++) items.Add(new Item("Dzieło sztuki")); }
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 43) ;
                    else if (roll < 63) { roll = Dice.Roll(Dice.Type.k4); for (int i = 0; i < roll; i++) items.Add(new Item("Zwykły przedmiot")); }
                    else                items.Add(new Item("Słaby przedmiot magiczny"));
                    break;
                case 5:
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 11) ;
                    else if (roll < 20) coins.Add(new Coin(CoinType.Copper, Dice.Roll(Dice.Type.k4, 1) * 10000));
                    else if (roll < 39) coins.Add(new Coin(CoinType.Silver, Dice.Roll(Dice.Type.k6, 1) * 1000));
                    else if (roll < 96) coins.Add(new Coin(CoinType.Gold, Dice.Roll(Dice.Type.k8, 1) * 100));
                    else coins.Add(new Coin(CoinType.Platinium, Dice.Roll(Dice.Type.k10, 1) * 10));
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 61) ;
                    else if (roll < 96) { roll = Dice.Roll(Dice.Type.k4); for (int i = 0; i < roll; i++) items.Add(new Item("Klejnot")); }
                    else                { roll = Dice.Roll(Dice.Type.k4); for (int i = 0; i < roll; i++) items.Add(new Item("Dzieło sztuki")); }
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 58) ;
                    else if (roll < 68) { roll = Dice.Roll(Dice.Type.k4); for (int i = 0; i < roll; i++) items.Add(new Item("Zwykły przedmiot")); }
                    else                { roll = Dice.Roll(Dice.Type.k3); for (int i = 0; i < roll; i++) items.Add(new Item("Słaby przedmiot magiczny")); }
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
            }
            return new Tuple<List<Item>, List<Coin>>(items, coins);
        }
    }
}
