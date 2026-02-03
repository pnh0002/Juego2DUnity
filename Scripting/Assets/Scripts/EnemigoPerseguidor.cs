using UnityEngine;

public class EnemigoPerseguidor : MonoBehaviour
{

    public Transform objetivo;

    public float velocidad = 3f;


    private Rigidbody2D rb;

    private GameManager gameManager; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (objetivo != null)
        {
            Vector2 direccion = objetivo.position - transform.position;

            direccion = direccion.normalized;

            rb.MovePosition(rb.position + (direccion * velocidad * Time.deltaTime));
        }
    }

    void OnColisionEnter2D(Collider2D objetoTocado)
    {
        if (objetoTocado.CompareTag("Jugador"))
        {
            gameManager.restarPuntos(1); 
        }
    }

}
