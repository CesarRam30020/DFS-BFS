/*
 * Created by SharpDevelop.
 * User: cesar
 * Date: 12/03/2022
 * Time: 04:39 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RamirezRodriguezCesarOswaldoCF{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		Bitmap bmpOriginal;
		Bitmap bmpAnimacion;
		List<Circulo> listaCirculos;
		Grafo grafo;
		Agente agente;
		int seleccion;
		Vertice inicio;
		Vertice final;
		
		nodoArbol raiz;
		List<Vertice> visitados;
		bool explorar, error;
		Queue<Vertice> colaVertices;
		
		Random rand;
		
		public MainForm(){
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
/** Metodo de clic para el boton (Selecciona la imagen) **/
		void ButtonSeleccionClick(object sender, EventArgs e){
			openFileDialog1.ShowDialog();
			listViewGrafo.Items.Clear();
			
			bmpOriginal = new Bitmap(openFileDialog1.FileName);
			bmpAnimacion = new Bitmap(bmpOriginal.Width,bmpOriginal.Height);
			pictureBoxImage.Image = bmpAnimacion;
			pictureBoxImage.BackgroundImage = bmpOriginal;
			pictureBoxImage.BackgroundImageLayout = ImageLayout.Zoom;
			
			listaCirculos = new List<Circulo>();
			grafo = new Grafo();
			
			seleccion = 0;
			
			analizaImagen();
			
/** Aqui es donde hay que crear el grafo con las restricciones necesarias **/
			Vertice v_o, v_d;
			for(int i = 0; i < grafo.contVertices; i++){
				v_o = grafo.obtenerVerticeEn(i);
				for(int j = i+1; j < grafo.contVertices; j++){
					v_d = grafo.obtenerVerticeEn(j);
					
					if(estaLibre(v_o,v_d)){
						Point[] path = obtenPath(v_o.Circulo.Centro,v_d.Circulo.Centro);
						Point[] path2 = obtenPath(v_d.Circulo.Centro,v_o.Circulo.Centro);

						double peso = Math.Abs(Math.Sqrt(
							Math.Pow(v_d.Circulo.Centro.X-v_o.Circulo.Centro.X,2)+
							Math.Pow(v_d.Circulo.Centro.Y-v_o.Circulo.Centro.Y,2)));
	
						v_o.addArista(v_d,path,peso);
						v_d.addArista(v_o,path2,peso);
					}
				}
			}
			
			muestraGrafo();
			
			Vertice v_g;
			for(int i = 0; i < listaCirculos.Count; i++){
				dibujaID(listaCirculos[i]);
				
				v_g = grafo.obtenerVerticeEn(i);
				
				listViewGrafo.Items.Add(new ListViewItem(new string[]{v_g.Id.ToString(),v_g.Circulo.Centro.X.ToString(),
				                                         	v_g.Circulo.Centro.Y.ToString(),v_g.obtenerTodosLosDestinos()}));
			}
		}
		
/** Analiza toda la imagen, de izquierda a derecha y de arriba a abajo **/
		void analizaImagen(){
			for(int y_i = 0; y_i < bmpOriginal.Height; y_i++){
				for(int x_i = 0; x_i < bmpOriginal.Width; x_i++){
					if(esNegro(bmpOriginal.GetPixel(x_i,y_i))){
						if(!fueBuscado(x_i,y_i)){
							Circulo circle = centroCirculo(x_i, y_i);
							listaCirculos.Add(circle);
						}
					}
				}
			}
			
			grafo.addVertices(listaCirculos);
		}
		
/** Metodo que analiza un pixel y nos dice si es blanco o no **/
		bool esBlanco(Color pixel){
			if(pixel.R == 255)
				if(pixel.G == 255)
					if(pixel.B == 255)
						return true;
			return false;
		}
		
/** Metodo que analiza un pixel y nos dice si es negro o no **/
		bool esNegro(Color pixel){
			if(pixel.R == 0)
				if(pixel.G == 0)
					if(pixel.B == 0)
						return true;
			return false;
		}

/** Metodo que analiza una posicion en la imagen y nos dice si esta pertenece a un circulo o no **/
		bool fueBuscado(int x,int y){
			if(listaCirculos != null){
				Circulo circulo = new Circulo();
				for(int i = 0; i < listaCirculos.Count; i++){
					circulo = listaCirculos[i];
					
					if(pitagoras(x,y,circulo) <= 0)
						return true;
				}
			}
			return false;
		}

/** Hace el calculo pertinente para saber si un punto pertenece a un circulo **/
		double pitagoras(int x,int y, Circulo ci){
			double a = Math.Pow((x - ci.Centro.X), 2);
			double b = Math.Pow((y - ci.Centro.Y), 2);
			double c = Math.Pow(ci.R + 5, 2);
			return a + b - c;
		}
		
/** Busca el centro de un circulo **/
		Circulo centroCirculo(int x_0,int y_0){
			int y_superior = y_0;
			
			int y_inferior = y_0;
/** Itera desde el primer pixel negro que encuentra hasta la parte inferior de un circulo **/
			while(!esBlanco(bmpOriginal.GetPixel(x_0, y_inferior + 1)))
				y_inferior++;

/** Crea el 'y' central el cual es la division de la suma de 'y' inferior y 'y' superior**/			
			float y_centro = ((float)y_inferior + (float)y_superior) / (float)2;
			
			int x_derecha = x_0;
/** itera desde el centro en 'y' del circulo hasta la parte mas derecha de un circulo **/
			while(!esBlanco(bmpOriginal.GetPixel(x_derecha + 1, (int)Math.Round(y_centro))))
				x_derecha++;
			
			int x_izquierda = x_0;
/** itera desde el centro en 'y' del circulo hasta la parte mas izquerda de un circulo **/
			while(!esBlanco(bmpOriginal.GetPixel(x_izquierda - 1, (int)Math.Round(y_centro))))
				x_izquierda--;

/** Crea el 'x' central el cual es la division de la suma de 'x' derecha y 'x' izquierda **/
			float x_centro = ((float)x_izquierda + (float)x_derecha) / (float)2;

/** Creamos un radio con respecto a 'x' y uno con respecto 'y' **/
			float radio_x = (x_derecha - x_izquierda) / 2;
			float radio_y = (y_inferior - y_superior) / 2;
			float radio;
			
/** Seleccionamos el radio mayor de los dos **/
			if(radio_x > radio_y)
				radio = radio_x;
			else
				radio = radio_y;
			
/** Creamos un nuevo circulo con las propiedades que acabamos de calcular **/
			Point n_point = new Point((int)Math.Round(x_centro), (int)Math.Round(y_centro));
			Circulo c = new Circulo(n_point, radio, listaCirculos.Count+1);
			return c;
		}

/** Dibuja el ID de un circulo en el centro del mismo **/
		void dibujaID(Circulo circulo){
			Graphics g = Graphics.FromImage(bmpOriginal);
			Font fontId = new Font("Arial",30);
			SolidBrush sb = new SolidBrush(Color.MediumPurple);
			
			g.DrawString(circulo.Id.ToString(),fontId,sb,circulo.Centro.X - 20,circulo.Centro.Y - 20);
			pictureBoxImage.Refresh();
		}
		
/** Obtiene el camino de un determinado circulo a otro **/
		Point[] obtenPath(Point p_0, Point p_f){
			float x_0, y_0;
			float x_f, y_f;
			float x_k, y_k;
			float m, b;
			int incremento = 1;
			
			x_0 = p_0.X;
			y_0 = p_0.Y;
			
			x_f = p_f.X;
			y_f = p_f.Y;
			int cont = 0;
			Point[] path;
			
			if((x_f-x_0) == 0){
				path = new Point[Math.Abs((int)y_0-(int)y_f)+5];
				
				if(y_0 > y_f)
					incremento = -1;
				for(y_k = y_0; y_k != y_f; y_k += incremento){
					path[cont].X = (int)Math.Round(x_0);
					path[cont++].Y = (int)Math.Round(y_k);
				}
				
				path[cont].X = (int)Math.Round(x_0);
				path[cont++].Y = (int)Math.Round(y_k);
			}else{
				m = (y_f-y_0)/(x_f-x_0);
				b = y_0-m*x_0;
				
				if(m < 1 && m > -1){
					path = new Point[Math.Abs((int)x_0-(int)x_f)+1];
					
					if(x_0 > x_f)
						incremento = -1;
					
					for(x_k = x_0; x_k != x_f; x_k+=incremento){
						y_k = m * x_k + b;
						path[cont].X = (int)Math.Round(x_k);
						path[cont++].Y = (int)Math.Round(y_k);
					}y_k = m * x_k + b;
					
					path[cont].X = (int)Math.Round(x_k);
					path[cont++].Y = (int)Math.Round(y_k);
				}else{
					path = new Point[Math.Abs((int)y_0-(int)y_f)+5];
					
					if(y_0 > y_f)
						incremento = -1;
					
					for(y_k = y_0; y_k != y_f; y_k += incremento){
						x_k = 1/m * (y_k - b);
						path[cont].X = (int)Math.Round(x_k);
						path[cont++].Y = (int)Math.Round(y_k);
					}x_k = 1/m * (y_k - b);
					
					path[cont].X = (int)Math.Round(x_k);
					path[cont++].Y = (int)Math.Round(y_k);
				}
			}
			return path;
		}

/** Muestra el grafo **/
		void muestraGrafo(){
			Graphics g = Graphics.FromImage(bmpOriginal);
			Pen aristasPen = new Pen(Color.Black,4);
			
			Circulo c_o, c_d;
			Vertice v_o, v_d;
			
			for(int i = 0; i < grafo.contVertices; i++){
				v_o = grafo.obtenerVerticeEn(i);
				c_o = v_o.Circulo;
				for(int j = 0; j < grafo.contVertices; j++){
					v_d = grafo.obtenerVerticeEn(j);
					c_d = v_d.Circulo;
					
					if(existeArista(v_o,v_d))
						g.DrawLine(aristasPen,c_o.Centro.X,c_o.Centro.Y,c_d.Centro.X,c_d.Centro.Y);
				}
			}
		}

/** Nos dice si existe una arista entre dos vertices **/
		bool existeArista(Vertice v_o, Vertice v_d){
			for(int i = 0; i < v_o.ContAristas; i++){
				if(v_o.obtenerDestinoA(i) == v_d)
					return true;
			}
			return false;
		}
		
/** Verifica si el camino hasta un vertice esta libre **/
		bool estaLibre(Vertice v_o,Vertice v_d){
			int aux = 0;		
			Vertice v_x;
			Point[] path = obtenPath(v_o.Circulo.Centro,v_d.Circulo.Centro);
			agente = new Agente(0/**v_o.Id**/);
			agente.IndicePath = 0;
			agente.Velocidad = 5;
			agente.Path = path;
			while(agente.camina()){
				Point p = agente.obtenPosicionActual();
				v_x = perteneceAVerticeVer(p.X, p.Y);
				if(v_x != null)
					aux = v_x.Id;
				if(!esBlanco(bmpOriginal.GetPixel(p.X, p.Y)) && !esNegro(bmpOriginal.GetPixel(p.X, p.Y)))
					if(v_x == null)
						return false;
					if(aux != v_d.Id && aux != v_o.Id)
						return false;
			}
			return true;
		}
		
/** Verifica si el lugar donde se dio clic, fue sobre un vertice (devuelve un vertice) **/
		Vertice perteneceAVerticeVer(float x_b,float y_b){
			Vertice v_i;
			Circulo c;
			float x_c, y_c, s, r;
			
			for(int i = 0; i < grafo.contVertices; i++){
				v_i = grafo.obtenerVerticeEn(i);
				c = v_i.Circulo;
				x_c = c.Centro.X;
				y_c	= c.Centro.Y;
				r = c.R;
				s = (x_b-x_c)*(x_b-x_c)+(y_b-y_c)*(y_b-y_c)-(r*r);
				if(s <= 200)
					return v_i;
			}
			return null;
		}
		
/** Metodo de clic para el PictureBox **/
		void PictureBoxImageMouseClick(object sender, MouseEventArgs e){
			float w_b, h_b;
			float w_p, h_p;
			float x_b, y_b;
			float x_p, y_p;
			float r_x, r_y, r;
			float d_x, d_y;
			
			x_p = e.X;
			y_p = e.Y;
			
			w_b = bmpOriginal.Width;
			h_b = bmpOriginal.Height;
			w_p = pictureBoxImage.Width;
			h_p = pictureBoxImage.Height;
			
			r_x = w_p / w_b;
			r_y = h_p / h_b;
			
			r = r_y;
			if(r_x < r_y)
				r = r_x;
			
			d_x = (w_p-r*w_b)/2;
			d_y = (h_p-r*h_b)/2;
			
			x_b = (x_p-d_x)/r;
			y_b = (y_p-d_y)/r;
			
			int v_index = perteneceAVerticeInt(x_b,y_b);
			int v_index_ini = 0;
			if(v_index != -1 && listaCirculos.Count > 1){
/** Le asigna el valor de destino al vertice al que se le haya dado clic (1er clic) **/
				if(seleccion == 0){
					inicio = grafo.obtenerVerticeEn(v_index);
					Graphics g = Graphics.FromImage(bmpAnimacion);
					g.Clear(Color.Transparent);
					Brush orig = new SolidBrush(Color.BlueViolet);
					Vertice origV = grafo.obtenerVerticeEn(v_index);
					g.FillEllipse(orig, origV.Circulo.Centro.X-20, origV.Circulo.Centro.Y-20, 40, 40);
					v_index_ini = v_index;
				}
/** Le asigna el valor de destino al vertice al que se le haya dado clic (2do clic) **/
				else{
					final = grafo.obtenerVerticeEn(v_index);
					Graphics g = Graphics.FromImage(bmpAnimacion);
					Brush dest = new SolidBrush(Color.Firebrick);
					Vertice destV = grafo.obtenerVerticeEn(v_index);
					g.FillEllipse(dest, destV.Circulo.Centro.X-20, destV.Circulo.Centro.Y-20, 40, 40);
				}pictureBoxImage.Refresh();
				
// Manda a llamar al metodo que hace la siumulacion
				if(seleccion != 0){
/** Inicializa lo necesario para hacer la busqueda en profundidad **/
					raiz = new nodoArbol(inicio,null);
					visitados = new List<Vertice>();
					agente = new Agente(v_index_ini);
					explorar = true;
					rand = new Random(DateTime.Now.Millisecond);

/** Hace una busqueda en profundidad dentro del grafo **/
//					error = false;
					DFS(inicio,final,raiz/*,rand*/);
					
					Graphics g = Graphics.FromImage(bmpAnimacion);
					g.Clear(Color.Transparent);
					g.FillEllipse(new SolidBrush(Color.Firebrick), final.Circulo.Centro.X-20, final.Circulo.Centro.Y-20, 40, 40);
					g.FillEllipse(new SolidBrush(Color.BlueViolet), inicio.Circulo.Centro.X-20, inicio.Circulo.Centro.Y-20, 40, 40);
					pictureBoxImage.Refresh();
					
					nodoArbol nodo = BFS(raiz,final.Circulo.Centro);
					
					if(nodo == null){
						seleccion = 0;
						error = true;
						explorar = true;
						raiz = new nodoArbol(inicio,null);
						visitados = new List<Vertice>();
						colaVertices = new Queue<Vertice>();
						return;
					}
					
					g.Clear(Color.Transparent);
					g.FillEllipse(new SolidBrush(Color.BlueViolet), final.Circulo.Centro.X-20, final.Circulo.Centro.Y-20, 40, 40);
					pictureBoxImage.Refresh();
					
					while(nodo != null){
						if(nodo.Padre != null){
							nodoArbol padre = nodo.Padre;
							dibujaAristaEntre(nodo.Dato,padre.Dato);
						}
						nodo = nodo.Padre;
					}					
					seleccion = -1;
				}
				seleccion++;
			}
		}
/** Crea el arbol (Busqueda en anchura o amplitud)
 	BFS (Breadth First Search)  **/
		nodoArbol BFS(nodoArbol root,Point point){
			List<Vertice> visited = new List<Vertice>();
			Queue<nodoArbol> queue = new Queue<nodoArbol>();
			
			visited.Add(root.Dato);
			queue.Enqueue(root);
			
			return BFS(visited,queue,point);
		}
		nodoArbol BFS(List<Vertice> visited,Queue<nodoArbol> queue,Point point/*,Vertice v_o,Vertice v_d*/){
			if(queue.Count == 0)
				return null;
			
			nodoArbol root = queue.Dequeue();
			Vertice v_o = root.Dato;
			
			if(v_o.Id == final.Id)
				return root;
			
			for(int i = 0; i < v_o.ContAristas; i++){
				Vertice v_d = v_o.obtenerDestinoA(i);
				if(!visited.Contains(v_d)){
					visited.Add(v_d);
					nodoArbol hijo = new nodoArbol(v_d,root);
					
					queue.Enqueue(hijo);
					
					root.addHijos(hijo);
				}
			}
			return BFS(visited,queue,point);
		}
		
/** Hace la simulacion de la animacion del agente **/
		void comienzaSimulacion(){
			Graphics g = Graphics.FromImage(bmpAnimacion);
			Brush agentBrush = new SolidBrush(Color.BlueViolet);
			Brush agentEraseBrush = new SolidBrush(Color.White);
			Brush dest = new SolidBrush(Color.Firebrick);
			
			agente.Velocidad = (pictureBoxImage.Width + pictureBoxImage.Height)/50;
			
			while(agente.camina()){
				Point p_k = agente.obtenPosicionActual();
				g.Clear(Color.Transparent);
				/** Dibuja el nuevo estado del circulo **/
				g.FillEllipse(dest, final.Circulo.Centro.X-20, final.Circulo.Centro.Y-20, 40, 40);
				g.FillEllipse(agentBrush, p_k.X-20, p_k.Y-20, 40, 40);
				pictureBoxImage.Refresh();
			}
		}
		
/** verifica si una posicion en especifico pertenece a un vertice o no **/
		int perteneceAVerticeInt(float x_b,float y_b){
			Vertice v_i;
			Circulo c;
			float x_c, y_c, s, r;
			
			for(int i = 0; i < grafo.contVertices; i++){
				v_i = grafo.obtenerVerticeEn(i);
				c = v_i.Circulo;
				x_c = c.Centro.X;
				y_c	= c.Centro.Y;
				r = c.R;
				s = (x_b-x_c)*(x_b-x_c)+(y_b-y_c)*(y_b-y_c)-(r*r);
				if(s <= 0)
					return i;
			}
			return -1;
		}
		
/** Crea el arbol (Busqueda en profundidad) 
 	DFS (Depth First Search) **/
		void DFS(Vertice v_o,Vertice v_d,nodoArbol raiz/*,Random rand*/){
			visitados.Add(v_o);
			int alea = 0;
			
			if(v_o.Id == v_d.Id){
				explorar = false;
				return;
			}
			
			while(true){
				alea = rand.Next(0,v_o.ContAristas);
				
				if(!explorar)
					return;
				
				if(!fueVisitado(v_o.obtenerDestinoA(alea/*i*/))){
					nodoArbol hijo = new nodoArbol(v_o.obtenerDestinoA(/*i*/alea),raiz);
					raiz.addHijos(hijo);
					
					dibujarCaminoHacia(v_o,v_o.obtenerDestinoA(/*i*/alea));
					
					DFS(v_o.obtenerDestinoA(/*i*/alea),v_d,hijo/*,rand*/);
					
					if(explorar)
						dibujarCaminoHacia(v_o.obtenerDestinoA(/*i*/alea),v_o);
				}
				
				if(todosVisitados(v_o))
					return;
			}
		}
/** Dibuja una arista entre dos vertices **/
		void dibujaAristaEntre(Vertice v_o,Vertice v_d){
			Graphics g = Graphics.FromImage(bmpAnimacion);
			Pen p = new Pen(Color.Gold,8);
			
			g.DrawLine(p,v_o.Circulo.Centro.X,v_o.Circulo.Centro.Y,v_d.Circulo.Centro.X,v_d.Circulo.Centro.Y);
			pictureBoxImage.Refresh();
		}

/** Verifica si un vertice ya esta en la lista de los buscados **/
		bool fueVisitado(Vertice v_b){
			for(int i = 0; i < visitados.Count; i++){
				if(v_b.Id == visitados[i].Id)
					return true;
			}
			return false;
		}

/** Dibuja el camino desde el vertice de inicio hasta el vertice de destino que se
	le han pasado como parametros **/
		void dibujarCaminoHacia(Vertice comienzo,Vertice destino){
			agente.IndicePath = 0;
			Vertice v_o = comienzo;
			
			int indice = 0;
			
			for(int i = 0; i < comienzo.ContAristas; i++){
				if(comienzo.obtenerDestinoA(i) == destino)
					indice = i;
			}
			
			Point[] camino = v_o.obtenerCamino(indice);
			agente.Path = camino;
			comienzaSimulacion();
		}

/** Verifica si todas sus aristas estan en visitados, si es asi
	devuelve un true, sino, un false **/
		bool todosVisitados(Vertice v_o){
			int aux = 0;
			for(int j = 0; j < visitados.Count; j++){
				for(int i = 0; i < v_o.ContAristas; i++){
					if(v_o.obtenerDestinoA(i) == visitados[j])
						aux++;
				}
			}
			
			return v_o.ContAristas == aux;
		}
	}
}
