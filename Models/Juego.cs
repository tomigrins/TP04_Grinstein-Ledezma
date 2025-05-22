namespace TP04_Grinstein_Ledezma.Models;

public class Juego{

     public string palabra {get; private set;} = "";
     public List<char> letrasUsadas {get; private set;} = new List<char>();
     public int cantIntentos {get; set;}
     public List<char> letrasAdivinadas {get; private set;} = new List<char>();
     public int cantLetras {get; private set;}
     public string tablero {get; private set;} = "";

     public void inicializarJuego(){
        palabra = "leocrack";
        cantIntentos = 0;
        letrasUsadas = new List<char>();
        letrasAdivinadas = new List<char>();
        cantLetras = contarLetras(palabra);
        actualizarTablero();
        
    }

    public  bool Letra(char intento)
    {
        if (intentoYaUsado(intento))
            return false;

        cantIntentos++;
        letrasUsadas.Add(intento);

        bool acerto = palabra.Contains(intento);

        if (acerto && !letrasAdivinadas.Contains(intento))
        {
            letrasAdivinadas.Add(intento);
        }

        actualizarTablero();
        return acerto;
    }

     private int contarLetras(string palabra){
        return palabra.Length;
    }

    public void agregarIntento(char intento){
        bool usada = intentoYaUsado(intento);
        if(!usada){
            cantIntentos++;
            letrasUsadas.Add(intento);
            bool acerto = verificarIntento(intento);
            if (acerto){
                letrasAdivinadas.Add(intento);
            }
        }
    }

    private bool verificarIntento(char intento){
        foreach (char c in palabra){
            if (c == intento){
                letrasAdivinadas.Add(intento);
                return true;
            }
        }
        return false;
    }

    private  bool intentoYaUsado(char intento){
        return letrasUsadas.Contains(intento);
    }

     public bool verificarPalabra(){
        foreach (char c in palabra){
            if (!letrasAdivinadas.Contains(c))
                return false;
        }
        return true;
    }

     public void actualizarTablero(){
        tablero = "";
        foreach (char c in palabra){
            if (letrasAdivinadas.Contains(c))
                tablero += $" {c} ";
            else
                tablero += " _ ";
        }
    }
}
