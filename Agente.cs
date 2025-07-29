/*
 * Created by SharpDevelop.
 * User: cesar
 * Date: 19/03/2022
 * Time: 11:20 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace RamirezRodriguezCesarOswaldoCF
{
	/// <summary>
	/// Description of Agente.
	/// </summary>
	public class Agente
	{
/** Atributos del agente **/
		int indicePath;
		Point [] path;
		List<int> visitados;
		int indiceVertice;
		int vel;
		
/** Propiedad para ver y asignar un valor a la velocidad del agente **/
		public int Velocidad{
			get{ return vel; }
			set{ vel = value; }
		}
		
/** Propiedad para ver cuantos elementos hay en visitados **/
		public int contVisitados{
			get{ return visitados.Count; }
		}
		
/** propiedad del agente para asignar valores al path **/
		public Point[] Path{
			set{ path = value; }
		}
		
/** propiedad del agente para asignar y ver el valor del indicePath **/
		public int IndicePath{
			get{ return indicePath; }
			set{ indicePath = value; }
		}
		
/** Constructor del agente **/
		public Agente(int indice){
			indicePath = 0;
			visitados = new List<int>();
			indiceVertice = indice;
			vel = 10;
		}
		
/** Metodo para saber si el agente puede avanzar mas en el path o no **/
		public bool camina(){
			if(indicePath+vel < path.Length){
				indicePath += vel;
				return true;
			}
			indicePath = path.Length-1;
			return false;
		}
		
/** Metodo para ver la posicion actual del agente **/
		public Point obtenPosicionActual(){
			return path[indicePath];
		}
		
/** metodo para verificar si ya se ha visitado algun vertice **/
		public bool compruebaVisitado(int id){
			for(int i = 0; i < visitados.Count; i++){
				if(id == visitados[i])
					return true;
			}
			return false;
		}
		
/** Metodo para agregar los id's de los vertices anteriormente visitados **/
		public void addVisitados(int id){
			visitados.Add(id);
		}
	}
}
