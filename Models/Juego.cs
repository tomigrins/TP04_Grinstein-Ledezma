namespace TP04_Grinstein_Ledezma.Models;

public class Juego{
    public string palabra {get; private set;}
    public List <char> letras {get; private set;}
    public char intneto {get; private set;}
    public int cantIntentos {get; private set;}
    public List <char> letrasAdivinadas {get; private set;}
    public Juego (string palabra, int cantIntentos){
        this.palabra = palabra;
        this.letras = new List <char>();
        this.cantIntentos = cantIntentos;
        this.letrasAdivinadas = new List<char>();
    }
    public void inicializarJuego(){
        palabra = "jazz";
    }
    public void agregarIntento(char intneto){
        bool usada = intentoYaUsado(intneto);
        if(!usada){
        cantIntentos++;
        letras.Add(intneto);
        bool acerto = verificarIntento(intneto);
        }
    }
    private bool verificarIntento(char intneto){
        foreach (char c in palabra)
        {
            if (c == intneto)
            {
                letrasAdivinadas.Add(intneto);
                return true;
            }
        }
        return false;
    }
    private bool intentoYaUsado(char intento)
    {
        foreach (char l in letras)
        {
            if (l == intento)
            {
                return true;
            }
        }
        return false;
    }

}