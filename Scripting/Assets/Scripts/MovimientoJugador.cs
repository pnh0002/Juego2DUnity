using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{

    // Cuando es "public" implica que lo podemos cambiar desde Unity el valor 
    public float velocidad = 5f;

    private Rigidbody2D rb;
    private Vector2 direccion;

    // Start is called before the first frame update
    void Start()
    {
        // Obtenemos el componente Rigidbody del propio objeto 
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal"); // Detecta flechas Izq/Der o A/D
        float y = Input.GetAxisRaw("Vertical"); // Detecta flechas Arr/Abj o w/S

        // Creamos el vector de dirección 
        direccion = new Vector2(x, y);

        // NORMALIZAR: Si nos movemos en diagonal, la longitud es de 1.41 (hipotenusa)
        // .normalized recorta el vector a 1 para no correr más rápido en diagonal 
        if (direccion.magnitude > 1)
        {
            direccion = direccion.normalized;
        }
    }

    // FIXEUPDATE: Aquí aplicamos el movimiento físico 
    void FixedUpdate()
    {
        // Calculamos cuánto movernos: Dirección * Velocidad * Tiempo 
        Vector2 desplazamiento = direccion * velocidad * Time.fixedDeltaTime;

        // Movemos el RigidBody a la nueva posición 
        rb.MovePosition(rb.position + desplazamiento); 
    }
}
