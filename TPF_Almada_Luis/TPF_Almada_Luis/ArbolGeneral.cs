﻿using System;
using System.Collections.Generic;

namespace TPF_Almada_Luis
{
	public class ArbolGeneral<T>
	{		
		private NodoGeneral<T> raiz;
		
		public ArbolGeneral(T dato) {
			this.raiz = new NodoGeneral<T>(dato);
		}
	
		private ArbolGeneral(NodoGeneral<T> nodo) {
			this.raiz = nodo;
		}
	
		private NodoGeneral<T> getRaiz() {
			return raiz;
		}
	
		public T getDatoRaiz() {
			return this.getRaiz().getDato();
		}
	
		public List<ArbolGeneral<T>> getHijos() {
			List<ArbolGeneral<T>> temp= new List<ArbolGeneral<T>>();
			foreach (var element in this.raiz.getHijos()) {
				temp.Add(new ArbolGeneral<T>(element));
			}
			return temp;
		}
	
		public void agregarHijo(ArbolGeneral<T> hijo) {
			this.raiz.getHijos().Add(hijo.getRaiz());
		}
	
		public void eliminarHijo(ArbolGeneral<T> hijo) {
			this.raiz.getHijos().Remove(hijo.getRaiz());
		}
	
		public bool esVacio() {
			return this.raiz == null;
		}
	
		public bool esHoja() {
			return this.raiz != null && this.getHijos().Count == 0;
		}
	
		public int altura() {
			int alturaMaxima = 0;
			int alturaTemporal;
			
			if (this.esHoja())
			{
				return alturaMaxima;
			}
			else
			{
				alturaTemporal = altura() + 1;
				alturaMaxima = alturaTemporal;
			}

			return alturaMaxima;
		}
	
		
		public int nivel(T dato) {
			return 0;
		}

		public void inOrden()
		{
			this.raiz.inOrden();
		}

		public void preOrden()
		{
			this.raiz.preOrden();
		}

		public void porNivel()
		{
			Cola<NodoGeneral<T>> cola = new Cola<NodoGeneral<T>>();

			cola.encolar(this.getRaiz());

			while (!cola.esVacia())
			{


				NodoGeneral<T> nodo = cola.desencolar();
				Console.WriteLine(nodo.getDato());
				foreach (NodoGeneral<T> element in nodo.getHijos())
				{
					cola.encolar(element);
				}
			}


		}

	}
}
