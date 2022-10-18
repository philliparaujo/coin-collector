using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject bullet;
    bool canShoot;
    public float timeBetweenShots = 1.0f;
    private float timeUntilNextShot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!(playerMovement.isGameOver))
        {
            if (Time.time > timeUntilNextShot)
            {
                canShoot = true;
            }
            if (Input.GetMouseButtonDown(0) && canShoot)
            {
                canShoot = false;
                timeUntilNextShot = Time.time + timeBetweenShots;
                Instantiate(bullet, this.transform.position, this.transform.rotation);
            }
        }
    }
}
