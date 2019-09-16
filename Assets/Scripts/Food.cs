using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SnakeHead"))
        {
            Snake snake = collision.transform.parent.GetComponent<Snake>();
            snake.Grow();

            GameObject.Destroy(gameObject);
        }
    }
   
}
