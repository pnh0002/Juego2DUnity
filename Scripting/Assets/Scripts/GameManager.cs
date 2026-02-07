using UnityEngine.UI; 
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // VARIABLES ESTÁTICAS (Compartidas por todos los scripts )
    public int puntos = 0;
    public int vidas = 3;

    // Referencia a los textos de la UI 
    public Text textoPuntos; 
    public Text textoVidas; 
    
    // Sonidos
    public AudioClip sonidoMoneda;
    public AudioClip sonidoDano;
    private AudioSource audioSource;

    public GameObject panelGameOver; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        //    Debug.Log(puntos); 
        textoPuntos.text = "Puntos: " + puntos; 
        
        if (audioSource != null && sonidoMoneda != null)
        {
            audioSource.PlayOneShot(sonidoMoneda);
        }
    }

    public void restarPuntos(int cantidad)
    {
        vidas -= cantidad; 
        
        if (audioSource != null && sonidoDano != null)
        {
            audioSource.PlayOneShot(sonidoDano);
        }
        
        if (vidas == 0)
        {
            vidas = 0;
            textoVidas.text = "Vidas: " + vidas; 
            panelGameOver.SetActive(true); 
            Time.timeScale = 0f; 

        }
        textoVidas.text= "Vidas: " + vidas; 
    }

}
