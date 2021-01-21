using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SawMovement : MonoBehaviour
{
    public Transform[] target;
    public float speed = 5f;

    private int current;

    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position != target[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody2D>().MovePosition(pos);
        }
        else
        {
            current = (current + 1) % target.Length;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Score.scoreValue = 0;
            SceneManager.LoadScene("SampleScene");
        }
    }

}
