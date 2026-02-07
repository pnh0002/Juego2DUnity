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
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (objetivo != null)
        {
            float directionX = Mathf.Sign(objetivo.position.x - transform.position.x);
            rb.velocity = new Vector2(directionX * velocidad, rb.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            if (gameManager != null)
            {
                gameManager.restarPuntos(1);
            }
        }
    }

}
