using UnityEngine;

public class CamaraSigue : MonoBehaviour
{

    public Transform jugador; // Arrastra al jugador aquí 

    // Usamos LateUpdate para mover la cámara DESPUËs de que el jugador se haya movido
    void LateUpdate()
    {
        if (jugador != null)
        {
            // Copiamos la X e Y del jugador, pero mantenemos la Z de la cámara (-10) 
            transform.position = new Vector3(jugador.position.x, jugador.position.y, -10); 
        }
    }

}
