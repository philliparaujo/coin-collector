using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodingChallenges : MonoBehaviour
{
    public int counter = 10;

    // Start is called before the first frame update
    void Start()
    {
        /* while (counter > 0)
        {
            Debug.Log(counter + "...");
            counter--;
        }
        Debug.Log("Blastoff!"); */

        for (int i=0; i<=100; i+=2)
        {
            if (i % 10 == 0)
            {
                Debug.Log("Honk!");
            }
            else
            {
                Debug.Log(i);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
