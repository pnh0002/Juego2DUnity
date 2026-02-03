
using UnityEngine;

public class ColisionesJugador : MonoBehaviour
{

    // Referencia al GameManager para poder avisarle 
    public GameManager miGameManager;

    // 1. OnTriggerEnter2D: Para objetos "fantasma" que atravesamos (Monedas)
    void OnTriggerEnter2D(Collider2D objetoTocado)
    {
        if (objetoTocado.CompareTag("Moneda"))
        {
            miGameManager.SumarPuntos(10);
            Destroy(objetoTocado.gameObject); // Destruye la moneda
        }

        if (objetoTocado.CompareTag("Bloque"))
        {
            miGameManager.restarPuntos(1);

        }
    }

}
