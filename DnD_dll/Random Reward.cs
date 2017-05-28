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
        public static Inventory GenerateTreasure(int SW)
        {
            List<Item> items = new List<Item>();
            List<Coin> coins = new List<Coin>();
            int roll;
#pragma warning disable CS0642 // Possible mistaken empty statement
            switch (SW)
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
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 11) ;
                    else if (roll < 19) coins.Add(new Coin(CoinType.Copper, Dice.Roll(Dice.Type.k6) * 10000));
                    else if (roll < 38) coins.Add(new Coin(CoinType.Silver, Dice.Roll(Dice.Type.k8) * 1000));
                    else if (roll < 96) coins.Add(new Coin(CoinType.Gold, Dice.Roll(Dice.Type.k10) * 100));
                    else                coins.Add(new Coin(CoinType.Platinium, Dice.Roll(Dice.Type.k12) * 10));
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 57) ;
                    else if (roll < 93) { roll = Dice.Roll(Dice.Type.k4); for (int i = 0; i < roll; i++) items.Add(new Item("Klejnot")); }
                    else                { roll = Dice.Roll(Dice.Type.k4); for (int i = 0; i < roll; i++) items.Add(new Item("Dzieło sztuki")); }
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 55) ;
                    else if (roll < 60)     { roll = Dice.Roll(Dice.Type.k4); for (int i = 0; i < roll; i++) items.Add(new Item("Zwykły przedmiot")); }
                    else if (roll < 100)    { roll = Dice.Roll(Dice.Type.k3); for (int i = 0; i < roll; i++) items.Add(new Item("Słaby magiczny przedmiot")); }
                    else                    items.Add(new Item("Przeciętny magiczny przedmiot"));
                    break;
                case 7:
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 12) ;
                    else if (roll < 19) coins.Add(new Coin(CoinType.Copper, Dice.Roll(Dice.Type.k10) * 10000));
                    else if (roll < 36) coins.Add(new Coin(CoinType.Silver, Dice.Roll(Dice.Type.k12) * 1000));
                    else if (roll < 94) coins.Add(new Coin(CoinType.Gold, Dice.Roll(Dice.Type.k6, 2) * 100));
                    else                coins.Add(new Coin(CoinType.Platinium, Dice.Roll(Dice.Type.k4, 3) * 10));
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 49) ;
                    else if (roll < 89) { roll = Dice.Roll(Dice.Type.k4); for (int i = 0; i < roll; i++) items.Add(new Item("Klejnot")); }
                    else                { roll = Dice.Roll(Dice.Type.k4); for (int i = 0; i < roll; i++) items.Add(new Item("Dzieło sztuki")); }
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 52) ;
                    else if (roll < 98) { roll = Dice.Roll(Dice.Type.k3); for (int i = 0; i < roll; i++) items.Add(new Item("Słaby magiczny przedmiot")); }
                    else                items.Add(new Item("Przeciętny magiczny przedmiot"));
                    break;
                case 8:
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 11) ;
                    else if (roll < 16) coins.Add(new Coin(CoinType.Copper, Dice.Roll(Dice.Type.k12) * 10000));
                    else if (roll < 30) coins.Add(new Coin(CoinType.Silver, Dice.Roll(Dice.Type.k6, 2) * 1000));
                    else if (roll < 88) coins.Add(new Coin(CoinType.Gold, Dice.Roll(Dice.Type.k8, 2) * 100));
                    else                coins.Add(new Coin(CoinType.Platinium, Dice.Roll(Dice.Type.k6, 3) * 10));
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 46) ;
                    else if (roll < 86) { roll = Dice.Roll(Dice.Type.k6); for (int i = 0; i < roll; i++) items.Add(new Item("Klejnot")); }
                    else                { roll = Dice.Roll(Dice.Type.k4); for (int i = 0; i < roll; i++) items.Add(new Item("Dzieło sztuki")); }
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 49) ;
                    else if (roll < 97) { roll = Dice.Roll(Dice.Type.k4); for (int i = 0; i < roll; i++) items.Add(new Item("Słaby magiczny przedmiot")); }
                    else                items.Add(new Item("Przeciętny magiczny przedmiot"));
                    break;
                case 9:
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 11) ;
                    else if (roll < 16) coins.Add(new Coin(CoinType.Copper, Dice.Roll(Dice.Type.k6, 2) * 10000));
                    else if (roll < 30) coins.Add(new Coin(CoinType.Silver, Dice.Roll(Dice.Type.k8, 2) * 1000));
                    else if (roll < 86) coins.Add(new Coin(CoinType.Gold, Dice.Roll(Dice.Type.k4, 5) * 100));
                    else                coins.Add(new Coin(CoinType.Platinium, Dice.Roll(Dice.Type.k12, 2) * 10));
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 41) ;
                    else if (roll < 81) { roll = Dice.Roll(Dice.Type.k8); for (int i = 0; i < roll; i++) items.Add(new Item("Klejnot")); }
                    else                { roll = Dice.Roll(Dice.Type.k4); for (int i = 0; i < roll; i++) items.Add(new Item("Dzieło sztuki")); }
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 44) ;
                    else if (roll < 92) { roll = Dice.Roll(Dice.Type.k4); for (int i = 0; i < roll; i++) items.Add(new Item("Słaby magiczny przedmiot")); }
                    else items.Add(new Item("Przeciętny magiczny przedmiot"));
                    break;
                case 10:
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 11) ;
                    else if (roll < 25) coins.Add(new Coin(CoinType.Silver, Dice.Roll(Dice.Type.k10, 2) * 1000));
                    else if (roll < 80) coins.Add(new Coin(CoinType.Gold, Dice.Roll(Dice.Type.k4, 6) * 100));
                    else                coins.Add(new Coin(CoinType.Platinium, Dice.Roll(Dice.Type.k6, 5) * 10));
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 36) ;
                    else if (roll < 80) { roll = Dice.Roll(Dice.Type.k8); for (int i = 0; i < roll; i++) items.Add(new Item("Klejnot")); }
                    else                { roll = Dice.Roll(Dice.Type.k6); for (int i = 0; i < roll; i++) items.Add(new Item("Dzieło sztuki")); }
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 41) ;
                    else if (roll < 89)     { roll = Dice.Roll(Dice.Type.k4); for (int i = 0; i < roll; i++) items.Add(new Item("Słaby magiczny przedmiot")); }
                    else if (roll < 100)    items.Add(new Item("Przeciętny magiczny przedmiot")); 
                    else                    items.Add(new Item("Potężny magiczny przedmiot"));
                    break;
                case 11:
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 9) ;
                    else if (roll < 15) coins.Add(new Coin(CoinType.Silver, Dice.Roll(Dice.Type.k10, 3) * 1000));
                    else if (roll < 76) coins.Add(new Coin(CoinType.Gold, Dice.Roll(Dice.Type.k8, 4) * 100));
                    else                coins.Add(new Coin(CoinType.Platinium, Dice.Roll(Dice.Type.k10, 4) * 10));
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 25) ;
                    else if (roll < 75) { roll = Dice.Roll(Dice.Type.k10); for (int i = 0; i < roll; i++) items.Add(new Item("Klejnot")); }
                    else                { roll = Dice.Roll(Dice.Type.k6); for (int i = 0; i < roll; i++) items.Add(new Item("Dzieło sztuki")); }
                    roll = Dice.Roll(Dice.Type.k100);
                    if (roll < 32) ;
                    else if (roll < 85)     { roll = Dice.Roll(Dice.Type.k4); for (int i = 0; i < roll; i++) items.Add(new Item("Słaby magiczny przedmiot")); }
                    else if (roll < 99)     items.Add(new Item("Przeciętny magiczny przedmiot"));
                    else                    items.Add(new Item("Potężny magiczny przedmiot"));
                    break;
                default:
                    break;
            }
#pragma warning restore CS0642 // Possible mistaken empty statement
            return new Inventory(items, coins);
        }
    }
}
