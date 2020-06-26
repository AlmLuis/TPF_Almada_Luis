using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TPF_Almada_Luis
{

	public class HumanPlayer : Jugador
	{
		private List<int> naipes = new List<int>();
		private List<int> naipesComputer = new List<int>();
		private int limite;
		private bool random_card = false;
		
		
		public HumanPlayer(){}
		
		public HumanPlayer(bool random_card)
		{
			this.random_card = random_card;
		}
		
		public override void  incializar(List<int> cartasPropias, List<int> cartasOponente, int limite)
		{
			this.naipes = cartasPropias;
			this.naipesComputer = cartasOponente;
			this.limite = limite;
		}
		
		public override int descartarUnaCarta()
		{
			int carta = 0;
			Console.WriteLine("Sus naipes disponibles son:");
			for (int i = 0; i < naipes.Count; i++) {
				Console.Write(naipes[i].ToString());
				if (i<naipes.Count-1) {
					Console.Write(", ");
				}
			}
		
			Console.WriteLine();
			Console.Write("Desea realizar una jugada?(S/N): ");
			string cont = Console.ReadLine();
			switch (cont)
			{
				case "s":
				case "S":
					if (!random_card)
					{
						Console.Write("Cual desea arrojar?");
						string entrada = Console.ReadLine();

						Int32.TryParse(entrada, out carta);
						while (!naipes.Contains(carta))
						{
							Console.Write("Ha elegido una opcion Invalida. Por favor arroje otro naipe:");
							entrada = Console.ReadLine();
							Int32.TryParse(entrada, out carta);
						}
					}
					else
					{
						var random = new Random();
						int index = random.Next(naipes.Count);
						carta = naipes[index];
						Console.Write("Ingrese naipe:" + carta.ToString());
					}
					break;

				case "n":
				case "N":
					Console.Clear();
					Console.WriteLine();
					Console.WriteLine("G A M E  O V E R");
					Console.WriteLine();
					Console.Write("Desea intentar una nueva partida(S/N): ");
					string opcion = Console.ReadLine();
					switch (opcion)
					{
						case "s":
						case "S":
							Game game = new Game();
							game.play();
							break;
						case "n":
						case "N":
							Console.Clear();
							Console.WriteLine("G A M E  O V E R");
							Console.WriteLine();
							Console.WriteLine("Gracias por haber jugado!!!");
							Console.WriteLine();
							Console.WriteLine("Hasta la proxima. . .");
							Console.WriteLine();
							Environment.Exit(0);
							break;
					}
					break;

			}
			
			
			return carta;
		}
		
		public override void cartaDelOponente(int carta){
		}		
	}
}
