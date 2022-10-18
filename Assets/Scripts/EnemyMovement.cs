using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int speed = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rot = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 180, transform.rotation.eulerAngles.z);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (transform.position.x <= -8.0f)
        {
            transform.rotation = Quaternion.Euler(rot);
        }
        if (transform.position.x >= 8.0f)
        {
            transform.rotation = Quaternion.Euler(rot);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
            // this.gameObject.SetActive(false);
        }
    }
}
