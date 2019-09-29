using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeLengthDisplay : MonoBehaviour
{
    public Snake snake;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = "Amount Of Food Eaten:  " + snake.Length.ToString();
    }
}
