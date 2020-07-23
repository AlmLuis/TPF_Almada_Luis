using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TPF_Almada_Luis
{
	public class ComputerPlayer: Jugador
	{
		private List<int> naipes = new List<int>();
		private List<int> naipesHuman = new List<int>();
		private int limite;
		public int sumaParcial;
		public double chancesDeGanar = 0.0;
		public ArbolGeneral<int> arbol;
		public ComputerPlayer()
		{
			arbol = new ArbolGeneral<int>(-1);			
		}
		private void llenarArbol(ArbolGeneral<int> nodoCarta, List<int> cartasPropias, List<int> cartasOponente)
		{
			List<int> naipesNoJugados = new List<int>(cartasPropias);
			naipesNoJugados.Remove(nodoCarta.getDatoRaiz());
			foreach (int cartaOponente in cartasOponente)
			{
				ArbolGeneral<int> nodoCartaOponente = new ArbolGeneral<int>(cartaOponente);
				llenarArbol(nodoCartaOponente, cartasOponente, naipesNoJugados);
				nodoCarta.agregarHijo(nodoCartaOponente);
			}	
		}
		public override void incializar(List<int> cartasPropias, List<int> cartasOponente, int limite)
		{
			this.naipes = cartasPropias;
			this.naipesHuman = cartasOponente;
			this.limite = limite;
			llenarArbol(this.arbol, cartasPropias, cartasOponente);
		}				
		public override int descartarUnaCarta()
		{
			int carta = 0;
			foreach(int cartaPropia in naipes)
			{
				if (cartaPropia > carta)
				{
					carta = cartaPropia;
				}
			}
			return carta;
		}			
		public override void cartaDelOponente(int carta)
		{
		}		
	}
}
