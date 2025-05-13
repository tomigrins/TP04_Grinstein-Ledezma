namespace TP04_Grinstein_Ledezma.Models;

public class Juego{
    static public string palabra {get; private set;}
    static public List <char> letrasUsadas {get; private set;}
    static public int cantIntentos {get; private set;}
    static public List <char> letrasAdivinadas {get; private set;}
    static public int cantLetras {get; private set;}
    static public void inicializarJuego(){
        palabra = "jazz";
        cantIntentos = 0;
        cantLetras = contarLetras(palabra);
    }
    static private int contarLetras (string palabra){
        int num = palabra.Length;
        return num;
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
        foreach (char c in palabra)
        {
            if (c == intento)
            {
                letrasAdivinadas.Add(intento);
                return true;
            }
        }
        return false;
    }
    private bool intentoYaUsado(char intento)
    {
        foreach (char l in letrasUsadas)
        {
            if (l == intento)
            {
                return true;
            }
        }
        return false;
    }
    static public void arriesgoPalabra(string palabra){
        cantIntentos++;
        bool acerto = verificarPalabra(palabra);
    }
    static private bool verificarPalabra(string palabra){
        bool acerto = false;
        if (Juego.palabra == palabra){
            acerto = true;
        }
        return acerto;
    }
}