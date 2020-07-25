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
		public ArbolGeneral<int> arbol;	
		
		public ComputerPlayer()
		{
			arbol = new ArbolGeneral<int>(-1);
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
			List<int> cartasPosibles=new List<int>();
			int carta=0;
			int cartaEnLista;			
			for (int i = 0; i < naipes.Count; i++){
				int valorNaipe=naipes[i];
				int newLimite;
				newLimite = limite-valorNaipe;
				carta=valorNaipe;
				if (newLimite >= 0){
					for (int j = 0; j < naipesHuman.Count; j++ ){
						int valorNaipeHuman=naipesHuman[j];
						newLimite-=valorNaipeHuman;
						if (newLimite < 0 && valorNaipe >= newLimite || valorNaipeHuman <= newLimite){
							cartaEnLista=valorNaipe;
							if (!cartasPosibles.Contains(cartaEnLista)){
								cartasPosibles.Add(cartaEnLista);
							}
						}
					}	
				}
			}
			int temp=13;
			foreach (int elem in cartasPosibles){
				if (elem < temp){
					carta=elem;
					temp=elem;
				}				
			}
			foreach (int c in cartasPosibles){
				Console.WriteLine(c);
			}
			naipes.Remove(carta);	
			return carta;
		}
		
		public override void cartaDelOponente(int carta)
		{
		}		
		
		public void llenarArbol(ArbolGeneral<int> nodoCarta, List<int> cartasPropias, List<int> cartasOponente)
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
	}
}
