using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaLet : MonoBehaviour
{
    public float vel = 10f;

    private void Start()
    {
        Destroy(this.gameObject, 2.5f);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * vel * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bala")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            //Debug.Log(collision.name);
        }
    }
}
