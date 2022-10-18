using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject enemyBullet;
    public float shotTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shotTimer += Time.deltaTime;
        if (shotTimer > 1)
        {
            Instantiate(enemyBullet, transform.position, transform.rotation);
            shotTimer = 0.0f;
        }
    }
}
