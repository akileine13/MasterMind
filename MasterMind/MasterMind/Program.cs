using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace MasterMind
{
	class Program
	{
		
 
		static List<int> ListColors = new List<int>();

		//FUNCTION COLOR
		static void color(int colorDefine) {
            switch (colorDefine) {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                default:
                    Console.ResetColor();  
                    break;
            }
        }

		//RANDOM COMBINAISON
        static List<int> RandomCombinaison(){
            //RANDOM
            Random RandomList = new Random();
            int randomColor = 0;

            //RANDOM LIST
			for (int i = 0; i < 4; i++) {
				randomColor = RandomList.Next(1, 5);
                color(randomColor);
				//Console.Write(randomColor);
                ListColors.Add(randomColor);
			}
            //RESET COLOR
            color(5);
            return ListColors;
        }

		
        static List<int> game() {
            //INPUT COMBINAISON
            Console.WriteLine("\nRentrez votre combinaison: ");
            int combinaison = Convert.ToInt32(Console.ReadLine());

            //CONVERT LIST INT TO STRING
            List<int> ListCombinaison = new List<int>();
            String combinaisonString = combinaison.ToString();
            for (int i =0;i<combinaisonString.Length;i++){
                String combinaisonToString = combinaisonString[i].ToString();
                int Nombre = Int32.Parse(combinaisonToString);
                ListCombinaison.Add(Nombre);
                }

			checkList(combinaison);

            return ListCombinaison;
        }

		static void checkList(int inputList)
		{
			List<int> compareList = new List<int>();
			int presentGoodPlace = 0;
			int presentNotPlace = 0;
			while (inputList > 0)
			{
				compareList.Insert(0, inputList % 10);
				inputList = inputList / 10;
			}
			for (int i = 0; i < 4; i++)
			{
				if (ListColors[i] == compareList[i])
				{
					presentGoodPlace++;
				}
				else if (ListColors.IndexOf(compareList[i]) != -1)
				{
					presentNotPlace++;
				}

			}
			for (int i = 0; i < compareList.Count; i++)
			{
				color(compareList[i]);
				Console.Write(compareList[i]);
			}
			color(5);
			Console.WriteLine(" ");
			Console.WriteLine("Present et bien placer " + presentGoodPlace);
			Console.WriteLine("Present et pas bien placer " + presentNotPlace);
		}
		
		static void Main(string[] args)
		{
			Console.WriteLine("MASTERMIND - 227785");
			color(1);
			Console.Write("1:Bleu");
			color(2);
			Console.Write(" 2:Rouge");
			color(3);
			Console.Write(" 3:Blanc");
			color(4);
			Console.WriteLine(" 4:Vert");
			color(5);

			//Connect("127.0.0.1", "coucou");
			List<int> ListColors = RandomCombinaison();
            List<int> ListCombinaison = game();
            
            //CHECK WIN OR LOOSE
            bool notWin = false;
			int compteur = 12;
			while (!notWin){
				if (ListCombinaison.SequenceEqual(ListColors)) {
					notWin = true;
					Console.WriteLine("Bravo");
				} else if (compteur == 0) {
					notWin = true;
					Console.WriteLine("Nombre de coups maximum atteints, vous avez perdu");
				} else {
					Console.WriteLine("Rejouer, il vous reste " + compteur);
					ListCombinaison = game();
				}
				compteur--;
			}
            Console.ReadKey();
		}
	}
}
