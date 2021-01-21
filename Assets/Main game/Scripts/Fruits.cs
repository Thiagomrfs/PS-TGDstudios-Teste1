using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BoxCollider2D>() != null)
        {
            if (collision.GetComponent<BoxCollider2D>().tag == "Player")
            {
                Destroy(gameObject);
                Score.scoreValue += 1;
            }
        }
    }
}
