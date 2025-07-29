/*
 * Created by SharpDevelop.
 * User: cesar
 * Date: 12/03/2022
 * Time: 05:18 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace RamirezRodriguezCesarOswaldoCF
{
	/// <summary>
	/// Description of Grafo.
	/// </summary>
/** Clase Grafo **/
	public class Grafo{
/** atributos de la clase grafo **/
		List<Vertice> listaVertices;

/** Contructor de la clase grafo **/
		public Grafo(){
			listaVertices = new List<Vertice>();
		}
		
/** propiedad para ver el numero de elementos en la lista de vertices **/
		public int contVertices{
			get{ return listaVertices.Count; }
		}
		
/** metodo para agregar los circulos a la lista de vertices **/
		public void addVertices(List<Circulo> circulos){
			for(int i = 0; i < circulos.Count; i++){
				Vertice v = new Vertice(circulos[i],circulos[i].Id);
				listaVertices.Add(v);
			}
		}
		
/** metodo para ver el vertice de una posicion de la lista **/
		public Vertice obtenerVerticeEn(int pos){
			return listaVertices[pos];
		}
	}

/** Clase Vertice **/
	public class Vertice{
/** Atributos de la calse Vertice **/
		List<Arista> listaAristas;
		Circulo circulo;
		int id;
		
/** Constructor de la clase Vertice **/
		public Vertice(Circulo c,int id){
			listaAristas = new List<Arista>();
			circulo = c;
			this.id = id;
		}
		
/** propiedad para ver el valor del atributo id **/
		public int Id{
			get{ return id; }
		}
		
/** propiedad para ver el valor del atributo circulo **/
		public Circulo Circulo{
			get{ return circulo; }
		}
		
/** Propiedad parver el numero de aristas de la lista de atistas **/
		public int ContAristas{
			get{ return listaAristas.Count; }
		}
		
/** metodo para ver el destino al que lleva una arista en concreto **/
		public Vertice obtenerDestinoA(int pos){
			return listaAristas[pos].Destino;
		}
		
/** metodo para añadira las aristas a la lista **/
		public void addArista(Vertice vertice,Point[] path,double peso){
			Arista arista = new Arista(vertice,path,peso);
			listaAristas.Add(arista);
		}
		
/** metodo para ver el path de una arista en concreto **/
		public Point[] obtenerCamino(int pos){
			return listaAristas[pos].Path;
		}
		
/** Metodo que nos devuelve un string donde se mencionan
	a todos los vertices con los que cuenta con una arista **/
		public string obtenerTodosLosDestinos(){
			string retorno = "";
			for(int i = 0; i < listaAristas.Count; i++){
				retorno += listaAristas[i].Destino.Id.ToString() + ", ";
			}
			return retorno;
		}
	}
	
/** Clase Arista **/
	public class Arista{
/** Atributos de la clase Arista **/
		Vertice destino;
		Point[] path;
		double peso;

/** Constructor de la clase Arista **/
		public Arista(Vertice destino,Point[] path,double peso){
			this.destino = destino;
			this.path = path;
			this.peso = peso;
		}
		
/** propiedad para ver el valor del atributo peso
	(este atributo y propiedad no se usan en esta practica) **/
		public double Peso{
			get{ return peso; }
		}
		
/** propiedad para ver el valor del atributo path **/
		public Point[] Path{
			get{ return path; }
		}
		
/** propiedad para ver el valor del atributo destino **/
		public Vertice Destino{
			get{ return destino; }
		}
	}
}
