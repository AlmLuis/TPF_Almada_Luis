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
		public HumanPlayer() { }
		public HumanPlayer(bool random_card)
		{
			this.random_card = random_card;
		}
		public override void incializar(List<int> cartasPropias, List<int> cartasOponente, int limite)
		{
			this.naipes = cartasPropias;
			this.naipesComputer = cartasOponente;
			this.limite = limite;
		}
		public override int descartarUnaCarta()
		{
			int carta = 0;
			Console.WriteLine("Sus naipes disponibles son:");
			for (int i = 0; i < naipes.Count; i++)
			{
				Console.Write(naipes[i].ToString());
				if (i < naipes.Count - 1)
				{
					Console.Write(", ");
				}
			}
			// desde aca estoy probando q se muestren las cartas de la IA
			Console.WriteLine("\n");
			Console.WriteLine("Los naipes de Computer son:");
			for (int i = 0; i < naipesComputer.Count; i++)
			{
				Console.Write(naipesComputer[i].ToString());
				if (i < naipesComputer.Count - 1)
				{
					Console.Write(", ");
				}
			}
			// hasta aca es lo q agregue
			if (!random_card)
			{
				Console.WriteLine();
				Console.WriteLine();
				Console.Write("Cual desea arrojar? ");
				string entrada = Console.ReadLine();

				Int32.TryParse(entrada, out carta);
				while (!naipes.Contains(carta))
				{
					Console.Write("Ha elegido una opcion Invalida. Por favor arroje otro naipe: ");
					entrada = Console.ReadLine();
					Int32.TryParse(entrada, out carta);//toma la variable entrada, la convierte a int y la devuelve como carta
				}
			}
			else
			{
				var random = new Random();
				int index = random.Next(naipes.Count);
				carta = naipes[index];
				Console.Write("Ingrese naipe: " + carta.ToString());
			}
			return carta;
		}
		public override void cartaDelOponente(int carta)
		{
		}
	}
}
