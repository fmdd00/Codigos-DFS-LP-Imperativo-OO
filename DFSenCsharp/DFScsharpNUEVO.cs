// Programa en C# para hacer la busqueda DFS de un grafo dado.
// Nuestro codigo maneja numeros, por lo cual, convertimos el grafo
// de ejemplo de letras a numeros, teniendo un total de 15 numeros/nodos
// empezando del 0 hasta el 14
using System;
using System.Collections.Generic; // Librerias estandar de C#
 
// Creamos la clase Grafo, la cual formará uno mediante listas de adyacencia
class Grafo {
    private int V; // V será el numero de nodos, en nuestro caso son 15
 
    // Ponemos nuestras listas de adyacencia en un arreglo de listas
    private List<int>[] ady;

    Grafo(int v)
    {
        V = v;
        ady = new List<int>[ v ];
        for (int i = 0; i < v; ++i)
            ady[i] = new List<int>();
    }
 
    // Creamos la funcion Unir que unira un nodo con su adyacente
    void Unir(int v, int u)
    {
        ady[v].Add(u); // Agrega el valor que tenga la variable "u" a la lista.
    }
 
    // Creamos una funcion recursiva que se encargará de ir visitando cada nodo
    void FuncionVisitar(int v, bool[] visitado)
    {
        // Cada vez que visite un nodo, lo imprime
        visitado[v] = true;
        Console.Write(v + " ");
 
        // Creamos la recursividad, para pasar de un nodo al nodo adyacente
        List<int> vList = ady[v];
        foreach(var n in vList)
        {
            if (!visitado[n])
                FuncionVisitar(n, visitado);
        }
    }
 
    // Creamos la funcion principal BusquedaDFS, que prepara todo y emplea la funcion
	// recursiva FuncionVisitar para visitar nodo por nodo
    void BusquedaDFS(int v)
    {
        // Por defecto, los vertices estan marcados como no visitados, por lo cual
		// nuestra funcion recursiva se encargara de marcarlos cada vez que los visite
        bool[] visitado = new bool[V];
 
        // Llamada a la funcion recursiva para finalmente most
        FuncionVisitar(v, visitado);
    }
 
    public static void Main(String[] args)
    {
        Grafo g1 = new Grafo(15);
 
 		// Nota: El grafo de ejemplo es un grafo no dirigido, esto quiere decir que el recorrido de un nodo A a un nodo B
		// puede darse de A-B o también podria darse de B-A (el sentido más conveniete sería escogido por el algoritmo), 
		// en cambio, en un grafo no dirigido, la conexion solo es de un solo sentido (y graficamente es representada con una flecha),
		// A->B significaría que el recorrido de A a B solo puede darse en ese sentido y no de B a A.
		
		// Con todo esto explicado, para representar un grafo no dirigido en este programa, es necesario señalar que un nodo está conectado
		// a otro en ambos sentidos. Por ejemplo, en el grafo de ejemplo empleado en este programa, el nodo 0 esta conectado al nodo 1,
		// por lo cual, en las listas de adyacencia se tiene que expresar el (0, 1) y tambien el (1, 0) para que el programa entienda que el
		// recorrido puede darse de ambos sentidos segun sea conveniente, y de que se trata de un grafo no dirigido.
		
        g1.Unir(0, 1); // Del sentido de 0-1
        g1.Unir(0, 2);
		g1.Unir(0, 3);
        g1.Unir(1, 4);
		g1.Unir(1, 5);
		g1.Unir(1, 6);
		g1.Unir(1, 0); // Del sentido de 1-0
        g1.Unir(2, 10);
        g1.Unir(2, 11);
		g1.Unir(2, 0);
        g1.Unir(3, 7);
		g1.Unir(3, 0);
		g1.Unir(4, 1);
		g1.Unir(5, 8);
		g1.Unir(5, 9);
		g1.Unir(5, 1);
		g1.Unir(6, 9);
		g1.Unir(6, 1);
		g1.Unir(7, 12);
		g1.Unir(7, 3);
		g1.Unir(8, 13);
		g1.Unir(8, 5);
		g1.Unir(9, 13);
		g1.Unir(9, 5);
		g1.Unir(9, 6);
		g1.Unir(10, 2);
		g1.Unir(11, 14);
		g1.Unir(11, 12);
		g1.Unir(11, 2);
		g1.Unir(12, 11);
		g1.Unir(12, 7);
		
		// Y como nota aparte, si quisieramos representar un grafo dirigido en las listas de adyacencia de este programa, solo tendríamos que escribir el
		// sentido en el que se da la conexion de un nodo a otro. Por ejemplo, si tenemos un grafo dirigido cuyos nodos 0 y 1 están conectados de la forma
		// 0->1, entonces tendriamos que escribir en el programa (0, 1) y nada mas.
 
        Console.WriteLine("Se aplico la busqueda DFS al grafo, el resultado es el siguiente: ");		
	    g1.BusquedaDFS(0); // Iniciamos la busqueda desde el nodo 0
    }
}