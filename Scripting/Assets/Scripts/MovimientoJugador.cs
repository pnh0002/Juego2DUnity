using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 10f;
    public AudioClip sonidoSalto;
    [Range(0f, 1f)]
    public float volumenSalto = 1f; // Control de volumen (0 a 1)
    
    private Rigidbody2D rb;
    private AudioSource audioSource;
    private bool enSuelo = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        
        Vector2 movimiento = new Vector2(x * velocidad, rb.velocity.y);
        rb.velocity = movimiento;
        
        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
            
            if (audioSource != null && sonidoSalto != null)
            {
                // Reproducir con el volumen deseado
                audioSource.PlayOneShot(sonidoSalto, volumenSalto);
            }
            else
            {
                Debug.LogWarning("Falta AudioSource o AudioClip de salto en MovimientoJugador");
            }
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }
    
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = false;
        }
    }
}