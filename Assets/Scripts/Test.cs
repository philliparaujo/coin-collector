using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public string name = "Phillip";
    int counter = 0;
    bool finished = false;
    int[] highscores = { 10, 7, 12, 8, 9, 10, 10 };

    /*This is a comment
        That I want to include
        on many lines*/

    // Start is called before the first frame update
    void Start()
    {
        for (int i=10; i>=counter; i--)
        {
            Debug.Log(i);
        }

        while (counter < 10)
        {
            counter++;
            //SOME CODE HERE
        }

        foreach (int score in highscores)
        {
            if (score > 9)
            {
                Debug.Log("high score: " + score);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (counter < 20)
        {
            counter++;
            Debug.Log("Counter value: " + counter);
        }
        else
        {
            if (!finished)
            {
                finished = true;
                counter = 0;
                Debug.Log("LOOP FINISHED");
            }
        }
    }
}
