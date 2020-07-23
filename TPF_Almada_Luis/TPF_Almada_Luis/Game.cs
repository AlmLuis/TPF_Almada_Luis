using System;
using System.Collections.Generic;
using System.Linq;

namespace TPF_Almada_Luis
{

	public class Game
	{
		public static int WIDTH = 12;
		public static int UPPER = 35;
		public static int LOWER = 25;
		
		private Jugador player1 = new ComputerPlayer();
		private Jugador player2 = new HumanPlayer();
		private List<int> naipesHuman = new List<int>();
		private List<int> naipesComputer = new List<int>();
		private int limite;
		private bool juegaHumano = false;		
		
		public Game()
		{
			var rnd = new Random();
			limite = rnd.Next(LOWER, UPPER);			
			naipesHuman = Enumerable.Range(1, WIDTH).OrderBy(x => rnd.Next()).Take(WIDTH / 2).ToList();			
			for (int i = 1; i <= WIDTH; i++) {
				if (!naipesHuman.Contains(i)) {
					naipesComputer.Add(i);
				}
			}
			player1.incializar(naipesComputer, naipesHuman, limite);
			player2.incializar(naipesHuman, naipesComputer, limite);			
		}	
		
		private void printScreen()
		{
			Console.Clear();
			Console.WriteLine();
			Console.WriteLine("A pensar. . . ");
			Console.WriteLine();
			Console.WriteLine("El limite es:" + limite.ToString());
		}
		
		private void turn(Jugador jugador, Jugador oponente, List<int> naipes)
		{
			int carta = jugador.descartarUnaCarta();
			naipes.Remove(carta);
			limite -= carta;
			oponente.cartaDelOponente(carta);
			juegaHumano = !juegaHumano;
		}		
		private void printWinner()
		{
			if (!juegaHumano) {
				Console.Clear();
				Console.WriteLine("Ud ha ganado!!!");
			} else {
				Console.Clear();
				Console.WriteLine("G A M E  O V E R - - - Ha ganado Computer!!!");
			}
			
		}		
		private bool fin()
		{
			return limite < 0;
		}
		
		public void play()
		{
			while (!this.fin()) {
				this.printScreen();
				Console.WriteLine();
				Console.WriteLine("Desea continuar?(S/N): ");
				string cont = Console.ReadLine();
				switch (cont)
				{
					case "s":
					case "S":
						this.turn(player2, player1, naipesHuman); // Juega el usuario
						if (!this.fin()) {
							this.printScreen();
							this.turn(player1, player2, naipesComputer); // Juega la IA
						}
						break;
					case "n":
					case "N":
						Console.Clear();
						Console.WriteLine();
						Console.WriteLine("Desea ?(S/N): ");
						Console.WriteLine("G A M E  O V E R");
						Console.WriteLine();
						Console.Write("Desea iniciar una nueva partida (S/N): ");
						string cont1 = Console.ReadLine();
						switch (cont1)
						{
							case "s":
							case "S":
								Game game=new Game();
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
			}
			this.printWinner();
		}		
	}
}
