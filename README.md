# Sistema de Análisis y Recorrido de Grafos en Imágenes

Este proyecto consiste en un sistema que permite analizar una imagen con círculos negros (nodos) y obstáculos, para construir un grafo, detectar conexiones válidas entre nodos y simular el recorrido de un agente desde un punto origen hasta un destino utilizando algoritmos de búsqueda.

## 📸 Descripción

La aplicación permite:

- Cargar una imagen con nodos (círculos negros) y obstáculos.
- Analizar la imagen para identificar nodos y construir un grafo.
- Detectar si hay obstrucciones entre nodos antes de crear aristas.
- Seleccionar un nodo de inicio y uno de destino mediante clics.
- Simular la animación de un agente recorriendo el grafo con:
  - Búsqueda en profundidad (DFS)
  - Búsqueda de camino mínimo (BFS)
- Mostrar visualmente los caminos y la información del grafo.

## 🎯 Objetivos

- Comprender e implementar grafos usando memoria dinámica.
- Implementar algoritmos de búsqueda y recorrido (DFS, BFS).
- Aplicar backtracking para exploración de caminos.
- Representar gráficamente estructuras de datos.

## 🧠 Marco Teórico

- Teoría de grafos: vértices, aristas, recorridos.
- Algoritmos DFS (búsqueda en profundidad).
- Algoritmos BFS (camino más corto).
- Árboles como estructura auxiliar para búsquedas.

## 🛠️ Clases Principales

### 🔘 `Circulo`
Representa un nodo del grafo:
- Atributos: centro (x, y), radio, ID.
- Métodos y propiedades para acceder a sus datos.

### 🕸️ `Grafo`
- Lista de vértices.
- Métodos para agregar y acceder a vértices.

### 🧩 `Vertice`
- Atributos: ID, círculo, lista de aristas.
- Métodos para agregar aristas, obtener conexiones, etc.

### 🔗 `Arista`
- Conecta dos vértices.
- Contiene destino, camino (lista de puntos) y peso.

### 🤖 `Agente`
- Simula un agente que recorre el grafo.
- Contiene path, vértices visitados, velocidad, etc.
- Métodos para caminar, verificar visitas, obtener posición actual.

### 🌳 `NodoArbol`
- Nodo de un árbol utilizado en DFS/BFS.
- Guarda hijos, vértice asociado y padre.

## 🖼️ Interfaz Gráfica

- Carga de imagen.
- Detección de círculos mediante análisis de píxeles.
- Visualización del grafo, aristas, ID de nodos.
- ListView para mostrar conexiones entre nodos.
- Clic en nodos para seleccionar origen/destino.

## ⚙️ Funcionalidades Clave

- `analizaImagen`: Detecta círculos en la imagen.
- `estaLibre`: Determina si hay obstáculos entre dos nodos.
- `obtenPath`: Calcula el camino entre dos nodos.
- `DFS`: Búsqueda en profundidad con recursión.
- `BFS`: Camino más corto usando una cola y árbol.
- `dibujaAristasEntre`: Visualiza el mejor camino (color dorado).
- `comienzaSimulacion`: Anima al agente en pantalla.

## 📊 Pruebas

- Imágenes con múltiples nodos y obstáculos.
- Se prueban caminos válidos e inválidos.
- Soporta grafos desconectados.
- El sistema evita errores si no existe un camino.

## ✅ Resultados

- Las aristas sólo se crean si no hay obstáculos entre nodos.
- Se simula correctamente el recorrido del agente.
- Se destaca el camino mínimo.
- Se evita que el programa falle cuando el destino es inalcanzable.

Análisis de una abstracción del CUCEI
https://github.com/user-attachments/assets/f1188f51-452b-4802-9575-58540090795e



## 🧩 Conclusión

El uso de árboles y recorridos recursivos como DFS/BFS permite crear una lógica genérica y reutilizable para recorrer cualquier grafo. La separación en clases mejora la mantenibilidad y escalabilidad del código.

## 🧪 Requisitos

- .NET Framework (Windows Forms).
- Imagen de entrada con nodos claramente delimitados.

## 📂 Estructura del Proyecto

```
/Proyecto
├── MainForm.cs
├── Circulo.cs
├── Grafo.cs
├── Vertice.cs
├── Arista.cs
├── Agente.cs
├── NodoArbol.cs
├── Recursos (Imágenes de prueba)
└── README.md
```

## 🧑‍💻 Autor

**Ramirez Rodriguez Cesar Oswaldo**  
Universidad de Guadalajara  
Ingeniería en Computación – D05  
Profesor: David Alejandro Gómez Anaya  
