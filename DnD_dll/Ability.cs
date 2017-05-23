using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD
{
    public static class Skill
    {
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
            Swim,           	//Pływanie
            OpenLock,       	//Otwieranie zamków
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
            Perform,        	//Występy
            SenseMotive,    	//Wyczucie pobudek
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
