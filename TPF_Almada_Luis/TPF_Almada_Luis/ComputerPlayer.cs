using System;
using System.Collections.Generic;
using System.Linq;

namespace TPF_Almada_Luis
{
	public class ComputerPlayer: Jugador
	{
		private List<int> naipes = new List<int>();
		private List<int> naipesHuman = new List<int>();
		private int limite;
		private bool random_card = false;
				
		public ComputerPlayer()
		{			
		}
		
		public override void  incializar(List<int> cartasPropias, List<int> cartasOponente, int limite)
		{
			this.naipes = cartasPropias;
			this.naipesHuman = cartasOponente;
			this.limite = limite;
		}
				
		public override int descartarUnaCarta()
		{
			/*
			int carta = 0;
			Console.WriteLine("naipes de IA: ");
			for (int i=0; i<naipes.Count; i++)
			{
				Console.WriteLine(naipes[i].ToString());
				if (i < naipes.Count - 1)
				{
					Console.WriteLine(", ");
				}
			}

			if (!random_card)
			{
				Console.WriteLine("hasta aca va bien");

			}
			else
			{
				var random = new Random();
				int index = random.Next(naipes.Count);
				carta = naipes[index]; 
				Console.WriteLine("aca llego bien");
			}
			*/
			//Implementar
			return 0;
		}
				
		public override void cartaDelOponente(int carta)
		{
			//implementar
			
		}
		
	}
}
