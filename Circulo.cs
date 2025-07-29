/*
 * Created by SharpDevelop.
 * User: cesar
 * Date: 12/03/2022
 * Time: 04:47 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

namespace RamirezRodriguezCesarOswaldoCF
{
	/// <summary>
	/// Description of Circulo.
	/// </summary>
	public class Circulo
	{
/** Atributos de la clase Circulo **/
		Point centro;
		float r;
		int id;
		
/** Constructores de la clase circle **/
		public Circulo(){}
		public Circulo(Point centro,float r, int id){
			this.centro = centro;
			this.r = r;
			this.id = id;
		}
		
/** Propiedad para dar y ver el valor del atributo centro **/
		public Point Centro{
			get{ return centro; }
			set{ centro = value; }
		}
		
/** Propiedad para dar y ver el valor del atributo r (radio) **/
		public float R{
			get{ return r; }
			set{ r = value; }
		}
		
/** Propiedad para dar y ver el valor del atributro id **/
		public int Id{
			get{ return id; }
			set{ id = value; }
		}
		
		public bool perteneceA(Point p){
			float x, y;
			float x_c, y_c;
			float r;
			float s;
			
			x_c = p.X;
			y_c = p.Y;
			
			x = centro.X;
			y = centro.Y;
			
			r = this.r;
			
			s = (x-x_c)*(x-x_c)+(y-y_c)*(y-y_c)-r*r;
			
			return s <= 0;
		}
	}
}
