using System;
using System.Collections.Generic;

namespace TPF_Almada_Luis
{
	public class NodoGeneral<T>
	{
		private T dato;
		
		private List<NodoGeneral<T>> hijos;
		
		public NodoGeneral(T dato){		
			this.dato = dato;
			this.hijos = new List<NodoGeneral<T>>();
		}
	
		public T getDato(){		
			return this.dato; 
		}
		
		public List<NodoGeneral<T>> getHijos(){		
			return this.hijos;
		}

		public void setDato(T dato){		
			this.dato = dato;
		}
		
		public void setHijos(List<NodoGeneral<T>> hijos){		
			this.hijos = hijos;
		}

		public void inOrden()
		{
			if (this.hijos.Count > 0)
			{
				this.hijos[0].inOrden();
			}
			Console.WriteLine(this.dato);
			for (int i = 1; i < this.hijos.Count; i++)
			{
				this.hijos[i].inOrden();
			}
		}

		public void preOrden()
		{
			Console.WriteLine(this.dato);
			foreach (NodoGeneral<T> hijo in this.hijos)
			{
				hijo.preOrden();
			}
		}

	}
}
