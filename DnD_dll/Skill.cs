using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD
{
    public static class Skill
    {
        private static HeroAttribute.Type[] _atr;
        private static bool[] _training;
        static Skill()
        {
            _atr = new HeroAttribute.Type[Enum.GetValues(typeof(Type)).Length];
            _training = new bool[Enum.GetValues(typeof(Type)).Length];
            #region Atrybuty umiejętności
            _atr[(int)Type.Bluff] = HeroAttribute.Type.Charisma;
            _atr[(int)Type.MoveSilently] = HeroAttribute.Type.Dexterity;
            _atr[(int)Type.Spellcraft] = HeroAttribute.Type.Intelligence;
            _atr[(int)Type.Diplomacy] = HeroAttribute.Type.Charisma;
            _atr[(int)Type.Forgery] = HeroAttribute.Type.Intelligence;
            _atr[(int)Type.Ride] = HeroAttribute.Type.Dexterity;
            _atr[(int)Type.SpeakLanguage] = HeroAttribute.Type.Intelligence;
            _atr[(int)Type.Concentration] = HeroAttribute.Type.Constitution;
            _atr[(int)Type.Heal] = HeroAttribute.Type.Wisdom;
            _atr[(int)Type.Listen] = HeroAttribute.Type.Wisdom;
            _atr[(int)Type.DecipherScript] = HeroAttribute.Type.Intelligence;
            _atr[(int)Type.OpenLock] = HeroAttribute.Type.Dexterity;
            _atr[(int)Type.Swim] = HeroAttribute.Type.Strength;
            _atr[(int)Type.HandleAnimal] = HeroAttribute.Type.Charisma;
            _atr[(int)Type.Disguise] = HeroAttribute.Type.Charisma;
            _atr[(int)Type.Search] = HeroAttribute.Type.Intelligence;
            _atr[(int)Type.Craft] = HeroAttribute.Type.Intelligence;
            _atr[(int)Type.Jump] = HeroAttribute.Type.Strength;
            _atr[(int)Type.Spot] = HeroAttribute.Type.Wisdom;
            _atr[(int)Type.Appraise] = HeroAttribute.Type.Intelligence;
            _atr[(int)Type.Survival] = HeroAttribute.Type.Wisdom;
            _atr[(int)Type.Hide] = HeroAttribute.Type.Dexterity;
            _atr[(int)Type.DisableDevice] = HeroAttribute.Type.Intelligence;
            _atr[(int)Type.UseRope] = HeroAttribute.Type.Dexterity;
            _atr[(int)Type.UseMagicDevice] = HeroAttribute.Type.Charisma;
            _atr[(int)Type.Knowledge] = HeroAttribute.Type.Intelligence;
            _atr[(int)Type.Climb] = HeroAttribute.Type.Strength;
            _atr[(int)Type.SenseMotive] = HeroAttribute.Type.Wisdom;
            _atr[(int)Type.Perform] = HeroAttribute.Type.Charisma;
            _atr[(int)Type.EscapeArtist] = HeroAttribute.Type.Dexterity;
            _atr[(int)Type.Balance] = HeroAttribute.Type.Dexterity;
            _atr[(int)Type.Intimidate] = HeroAttribute.Type.Charisma;
            _atr[(int)Type.Profession] = HeroAttribute.Type.Wisdom;
            _atr[(int)Type.GatherInformation] = HeroAttribute.Type.Charisma;
            _atr[(int)Type.SleightOfHand] = HeroAttribute.Type.Dexterity;
            _atr[(int)Type.Tumble] = HeroAttribute.Type.Dexterity;
            #endregion
            #region Czy wyszkolone
            _training[(int)Type.Bluff] = false;
            _training[(int)Type.MoveSilently] = false;
            _training[(int)Type.Spellcraft] = true;
            _training[(int)Type.Diplomacy] = false;
            _training[(int)Type.Forgery] = false;
            _training[(int)Type.Ride] = false;
            _training[(int)Type.SpeakLanguage] = true;
            _training[(int)Type.Concentration] = false;
            _training[(int)Type.Heal] = false;
            _training[(int)Type.Listen] = false;
            _training[(int)Type.DecipherScript] = true;
            _training[(int)Type.OpenLock] = true;
            _training[(int)Type.Swim] = false;
            _training[(int)Type.HandleAnimal] = true;
            _training[(int)Type.Disguise] = false;
            _training[(int)Type.Search] = false;
            _training[(int)Type.Craft] = false;
            _training[(int)Type.Jump] = false;
            _training[(int)Type.Spot] = false;
            _training[(int)Type.Appraise] = false;
            _training[(int)Type.Survival] = false;
            _training[(int)Type.Hide] = false;
            _training[(int)Type.DisableDevice] = true;
            _training[(int)Type.UseRope] = false;
            _training[(int)Type.UseMagicDevice] = false;
            _training[(int)Type.Knowledge] = true;
            _training[(int)Type.Climb] = false;
            _training[(int)Type.Perform] = false;
            _training[(int)Type.SenseMotive] = false;
            _training[(int)Type.EscapeArtist] = false;
            _training[(int)Type.Balance] = false;
            _training[(int)Type.Intimidate] = false;
            _training[(int)Type.Profession] = true;
            _training[(int)Type.GatherInformation] = false;
            _training[(int)Type.SleightOfHand] = true;
            _training[(int)Type.Tumble] = true;
            #endregion
        }
        public static bool NeedTraining(Type t)
        {
            return _training[(int)t];
        }
        public static HeroAttribute.Type BaseAtribute(Type t)
        {
            return _atr[(int)t];
        }
        public enum Type
        {
            Bluff,          	//Blefowanie
            MoveSilently,   	//Ciche poruszanie się
            Spellcraft,     	//Czarostwo
            Diplomacy,      	//Dyplomacja
            Forgery,        	//Fałszerstwo
            Ride,           	//Jeździectwo
            SpeakLanguage,  	//Język obcy
            Concentration,  	//Koncentracja
            Heal,           	//Leczenie
            Listen,         	//Nasłuchiwanie
            DecipherScript, 	//Odcyfrowywanie zapisków
            OpenLock,       	//Otwieranie zamków
            Swim,           	//Pływanie
            HandleAnimal,   	//Postępowanie ze zwierzętami
            Disguise,       	//Przebieranie się
            Search,         	//Przeszukiwanie
            Craft,          	//Rzemisoło
            Jump,           	//Skakanie
            Spot,           	//Spostrzegwaczość
            Appraise,       	//Szacowanie
            Survival,       	//Sztuka przetrwania
            Hide,           	//Ukrywanie się
            DisableDevice,  	//Unieszkodliwianie mechanizmów
            UseRope,        	//Używanie liny
            UseMagicDevice, 	//Używanie magicznych urządzeń
            Knowledge,      	//Wiedza
            Climb,          	//Wspinaczka
            SenseMotive,    	//Wyczucie pobudek
            Perform,        	//Występy
            EscapeArtist,   	//Wyzwalanie się
            Balance,        	//Zachowanie równowagi
            Intimidate,     	//Zastraszanie
            Profession,     	//Zawód
            GatherInformation,  //Zbieranie informacji
            SleightOfHand,      //Zręczna dłoń
            Tumble              //Zwinność
        }
    }
}
