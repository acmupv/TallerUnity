using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float vel = 1f;
    public float fuerzaSalto = 400f;
    public bool enSuelo = false;

    int saltoIndex = 1;

    public Transform detector;
    public LayerMask layer;

    Rigidbody2D rb;

    // DISPARO
    public GameObject balaLechuga;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal") * vel * Time.deltaTime;

        transform.Translate(h, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && saltoIndex > 0)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * fuerzaSalto);
            saltoIndex--;
        }

        enSuelo = Physics2D.OverlapCircle(detector.position, 0.1f, layer);

        if (enSuelo)
        {
            saltoIndex = 1;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        Instantiate(balaLechuga, transform.position, transform.rotation);
    }

}
