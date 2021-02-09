using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMenager : MonoBehaviour
{
    public float health;
    public float damage;
    float distance, turnPlayer;
    public float speed, bulletSpeed;
    public bool moveRight = true;
    float instantiationTimer = 1f;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    int num;

    public Transform bullet, player, coin;
    public GameObject sword, hat, potion;
    string[] items = new string[] {"sword", "hat", "potion" };
    Transform muzzle;

    public Slider slider;

    bool colliderBusy = false;
    // Start is called before the first frame update
    void Start()
    {
        num = Random.Range(0, 3);
        muzzle = transform.GetChild(1);
        slider.maxValue = health;
        slider.value = health;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance <= 5)
        {
            TurnPlayer();
            shootBullet();
        }

        MoveRandom();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !colliderBusy)
        {
            colliderBusy = true;
            other.GetComponent<PlayerMenager>().GetDamage(damage);
        }
        else if (other.tag == "Bullet")
        {
            GetDamage(other.GetComponent<BulletMenager>().bulletDamage);
            Destroy(other.gameObject);
        }

        if (other.tag == "Turn")
        {
            if (moveRight)
            {
                moveRight = false;
            }
            else
            {
                moveRight = true;

            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            colliderBusy = false;
        }
    }

    public void GetDamage(float damage)
    {
        if ((health - damage) >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        slider.value = health;
        AmIDead();
    }

    void AmIDead()
    {
        if (health <= 0)
        {
            DataMenager.Instance.EnemyKilled++;
            DataMenager.Instance.EarnedCoin += 10;

            if (items[num] == "sword")
            {
                do
                {
                    DataMenager.Instance.Sword++;
                    Destroy(Instantiate(sword, transform.position, Quaternion.identity), 3f);
                }
                while (false);
            }
            else if(items[num] == "hat")
            {
                do
                {
                    DataMenager.Instance.Hat++;
                    Destroy(Instantiate(hat, transform.position, Quaternion.identity), 3f);
                }
                while (false);
            }
            else if (items[num] == "potion")
            {
                do
                {
                    DataMenager.Instance.Potion++;
                    Destroy(Instantiate(potion, transform.position, Quaternion.identity), 3f);
                }
                while (false);
            }
            
            Destroy(gameObject);
        }
    }

    void MoveRandom()
    {
        if (moveRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            sprite.flipX = false;
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            sprite.flipX = true;
        }
    }

    public void shootBullet()
    {
        instantiationTimer -= Time.deltaTime;

        if(instantiationTimer <= 0)
        {
            Transform tempBullet;
            tempBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
            tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.right * bulletSpeed);
            Destroy(bullet, 3f);
            instantiationTimer = 1f;
        }
        

    }

    public void TurnPlayer()
    {

        turnPlayer = player.transform.position.x - transform.position.x;
        if (turnPlayer > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;

        }
        else if (turnPlayer < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            muzzle.eulerAngles= Vector3.forward * 180;

        }
    }
}
