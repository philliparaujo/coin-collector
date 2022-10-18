using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 10;
    Rigidbody rb;
    float jumpForce = 8.0f;
    bool jumping = false;
    public Text score;
    public Text hp;
    public int scoreNum;
    public int hpNum = 3;
    private Vector3 reset;
    private Vector3 OGpos;

    public bool isGameOver = false;
    public float timeBetweenDamage = 1.0f;
    private float timeUntilNextDamage;

    [SerializeField]
    private GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        reset = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        OGpos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        SpawnCoin();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            /*
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            if (Input.GetButtonDown("Jump") && jumping == false)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                jumping = true;
            }

            // Reset rotation
            if (Input.GetKey(KeyCode.X))
            {
                transform.rotation = Quaternion.identity;
                transform.position = new Vector3(transform.position.x, OGpos.y, transform.position.z);
            }

            // Reset position
            if (Input.GetKey(KeyCode.Z))
            {
                transform.position = OGpos;
            } */

            if (hpNum <= 0)
            {
                isGameOver = true;
            }
        }
    }

    void SpawnCoin()
    {
        bool coinSpawned = false;
        while (!coinSpawned)
        {
            Vector3 coinPos = new Vector3(Random.Range(-10f, 10f), Random.Range(1f, 4f), Random.Range(-10f, 10f));
            if (!((coinPos - transform.position).magnitude < 3))
            {
                Instantiate(coin, coinPos, coin.transform.rotation);
                coinSpawned = true;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!isGameOver)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                jumping = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isGameOver)
        {
            if (other.gameObject.CompareTag("Coin"))
            {
                scoreNum++;
                score.text = "Score: " + scoreNum;
                Destroy(other.gameObject);
                SpawnCoin();
            }

            if (other.gameObject.CompareTag("EnemyBullet"))
            {
                // Check for invulnerability frame
                if (timeUntilNextDamage < Time.time)
                {
                    hpNum--;
                    timeUntilNextDamage = Time.time + timeBetweenDamage;
                    hp.text = "HP: " + hpNum;
                }
                Destroy(other.gameObject);
            }

            if (other.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("SHOULD TAKE DAMAGE (ENEMY)");
                // Check for invulnerability frame
                if (timeUntilNextDamage < Time.time)
                {
                    hpNum--;
                    timeUntilNextDamage = Time.time + timeBetweenDamage;
                    hp.text = "HP: " + hpNum;
                }
            }
        }
    }
}
