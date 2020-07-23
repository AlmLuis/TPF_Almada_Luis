using System;
using System.Collections.Generic;
using System.Linq;

namespace TPF_Almada_Luis
{
	public class ComputerPlayer: Jugador
	{
		private ArbolGeneral<int> arbol;
								
		public ComputerPlayer()
		{
			arbol = new ArbolGeneral<int>(-1);
		}

		private void llenarArbol(ArbolGeneral<int> nodoCarta, List<int> cartasPropias, List<int> cartasOponente)
		{
			List<int> naipesNoJugados = new List<int>(cartasPropias);
			naipesNoJugados.Remove(nodoCarta.getDatoRaiz());
			foreach(int cartaOponente in cartasOponente)
			{
				ArbolGeneral<int> nodoCartaOponente = new ArbolGeneral<int>(cartaOponente);
				llenarArbol(nodoCartaOponente, cartasOponente, naipesNoJugados);
				nodoCarta.agregarHijo(nodoCartaOponente);
			}
		}
		public override void  incializar(List<int> cartasPropias, List<int> cartasOponente, int limite)
		{
			llenarArbol(this.arbol, cartasPropias, cartasOponente);
			
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
