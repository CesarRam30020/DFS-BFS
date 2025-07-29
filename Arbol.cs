/*
 * Created by SharpDevelop.
 * User: cesar
 * Date: 20/03/2022
 * Time: 05:50 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace RamirezRodriguezCesarOswaldoCF
{
	/// <summary>
	/// Description of Arbol.
	/// </summary>	
/** Clase nodoArbol **/
	public class nodoArbol{
	/** Atributos de la calse
		* Hijos del nodo
		* Padre del nodo
		* Dato del nodo (Vertice) **/
		List<nodoArbol> hijos;
		nodoArbol padre;
		Vertice dato;
		
	/** Constructor de la clase **/
		public nodoArbol(Vertice vert,nodoArbol padre){
			hijos = new List<nodoArbol>();
			dato = vert;
			this.padre = padre;
		}
		
	/** metodo para añadir hijos al nodo **/
		public void addHijos(nodoArbol hijo){
			hijos.Add(hijo);
		}
	
	/** Devielve el hijo en una posicion especifica **/
		public nodoArbol hijoEn(int pos){
			return hijos[pos];
		}
	
	/** propiedad que devuelve el vertice del nodo **/
		public Vertice Dato{
			get{ return dato; }
		}
	
	/** propiedad que devuelve la cantidad de hijos que tiene el nodo **/
		public int contHijos{
			get{ return hijos.Count; }
		}
	
	/** Propiedad que devuelve al padre del nodo **/
		public nodoArbol Padre{
			get{ return padre; }
		}
	}
	
	
	
	
	/** Clase Arbol **/
//	public class Arbol{
//	/** Raiz del Arbol **/
//		nodoArbol raiz;
//		
//	/** Propedad vara ver la raiz del arbol **/
//		public nodoArbol Raiz{
//			get{ return raiz; }
//		}
//	
//	/** Constructor de la clase Arbol **/
//		public Arbol(Vertice vert){
//			raiz = new nodoArbol(vert,null);
//		}
//	}
}
