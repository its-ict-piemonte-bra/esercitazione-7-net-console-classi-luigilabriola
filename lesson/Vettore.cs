using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson
{
    /// <summary>
    /// Questa classe gestisce un vettore di interi e fornisce diversi metodi di appoggio
    /// </summary>
    public class Vettore
    {
        /// <summary>
        /// Il vettore di interi gestito 
        /// </summary>
        public int[] _vettore; // cambiamento _ per utilizzare this.vettore a linea 34

        /// <summary>
        /// Crea una nuova istanza(puntatore) vuota dell'oggetti Vettore
        /// </summary>
        public Vettore()
        {
            // Metodo costruttore 1 : vuoto
            _vettore = new int[0];
        }

        /// <summary>
        /// Crea una nuova istanza dell'oggetto Vettore, a partire dall'array specificato
        /// </summary>
        /// <param name="vettore">L'array da gestire</param>
        public Vettore(int[] vettore)
        {
            if (vettore == null)
            {
                throw new ArgumentNullException("Non è possibile inizializzare la classe con un vettore nullo");
            }
            _vettore = vettore; // = this.vettore;
        }

        /// <summary>
        /// Calcola il valore medio di tutte le celle
        /// </summary>
        /// <returns>Il valore medio</returns>
        public float ValoreMedio()
        {
            if (isEmpty())//(_vettore.Length == 0)
            {
                throw new InvalidOperationException("Non si può fare la media su un vettore vuoto");
            }

            float sum = 0;
            for (int i = 0; i < _vettore.Length; i++) //foreach (int value in _vettore)
            {
                sum += _vettore[i];                   //sum += value;
            }
            return sum / _vettore.Length;             //return sum / vettore.Length;
        }

        /// <summary>
        /// Restituisce se un vettore è vuoto oppure no
        /// </summary>
        /// <returns>true se il vettore è vuoto, altrimenti false</returns>
        public bool isEmpty()
        {
            return _vettore == null || _vettore.Length == 0;
        }

        /// <summary>
        /// Restituisce il valore massimo all'interno del vettore
        /// </summary>
        /// <returns>Il valore massimo</returns>
        /// <exception cref="InvalidOperationException">Se il vettore è vuoto</exception>
        public int ValoreMassimo()
        {
            if (isEmpty())
            {
                throw new ArgumentException("Il vettore non può essere vuoto");
            }

            int max = _vettore[0];
            foreach (int i in _vettore)
            {
                if (i > max)
                {
                    max = i;
                }
            }
            return max;
        }

        /// <summary>
        /// Restituisce il valore minimo all'interno del vettore
        /// </summary>
        /// <returns>Il valore minimo</returns>
        /// <exception cref="InvalidOperationException">Se il vettore è vuoto</exception>
        public int ValoreMinimo()
        {
            if (isEmpty())
            {
                throw new ArgumentException("Il vettore non può essere vuoto");
            }

            int min = _vettore[0];
            foreach (int i in _vettore)
            {
                if (i < min)
                {
                    min = i;
                }
            }
            return min;
        }

        /// <summary>
        /// Restituisce la rappresentazione del vettore, sotto forma di 
        /// stringa CSV (valori separati da virgola)
        /// </summary>
        /// <returns>La rappresentazione del vettore</returns>
        /// <example>
        /// int[] sorgente = new int[] { 1, 2, 3 , 4, 5 };
        /// Vettore v = new Vettore(sorgente);
        /// Console.WriteLine(v); // [ 1, 2, 3, 4, 5 ]
        /// </example>
        public override string ToString()
        {
            string result = "[ ";

            if (!isEmpty())
            {
                for (int i = 0; i < _vettore.Length - 1; i++)
                {
                    result += $"{_vettore[i]}, ";
                }

                result += $"{_vettore[_vettore.Length - 1]} ";
            }

            result += "]";

            return result;
        }


        /// <summary>
        /// Stampa solamente i numeri pari a video, uno per riga
        /// </summary>
        public void printEvenNumbers()
        {
            for (int i = 0; i < _vettore.Length; i++)
            {
                if (_vettore[i] % 2 == 0)
                {
                    Console.WriteLine($"{_vettore[i]}");
                }
            }
        }

        /// <summary>
        /// Ordina l'array con l'algoritmo di ordinamento per selezione
        /// </summary>
        public void sort()
        {
            for (int i = 0; i < _vettore.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < _vettore.Length; j++)
                {
                    if (_vettore[j] < _vettore[min])
                    {
                        min = j;
                    }
                }
                if (i != min)
                {
                    int temp = _vettore[min];
                    _vettore[min] = _vettore[i];
                    _vettore[i] = temp;
                }
            }
        }

        /// <summary>
        /// Serializza l'oggetto sul file specificato
        /// </summary>
        /// <param name="path">Il percorso del file</param>
        public void Serialize(string path)
        {
            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine(_vettore.ToString());

            writer.Close();
        }

        /// <summary>
        /// Carica un nuovo oggetto vettore a partire dal file
        /// specificato come parametro
        /// </summary>
        /// <param name="path">Il percorso del file</param>
        /// <returns>L'oggetto Vettore generato</returns>
        public static Vettore Deserialize(string path)
        {
            throw new NotImplementedException();
        }
    }
}