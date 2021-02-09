using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerMenager : MonoBehaviour
{
    public float health;

    public float bulletSpeed;
    public Slider slider;
    public GameObject InGameScreen, pauseScreen, bloodParticle;

    bool mouseIsNotOverUI;
    public Transform bullet, floatingText;
    int defance;
    Transform muzzle;
    // Start is called before the first frame update
    void Start()
    {
        defance = DataMenager.Instance.defance;
        muzzle = transform.GetChild(1);
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;

        if (Input.GetMouseButtonDown(0) && mouseIsNotOverUI)
        {
            shootBullet();
        }
    }

    public void GetDamage(float damage)
    {
        //Instantiate(floatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();

        if((health - damage) >= 0)
        {
            health -= damage;
            DataMenager.Instance.Health -= (10-defance);
        }
        else
        {
            health = 0;
            DataMenager.Instance.Health = 0;
        }
        slider.value = DataMenager.Instance.Health;
        AmIDead();
    }

    void AmIDead()
    {
        if(health <= 0)
        {
            Destroy(Instantiate(bloodParticle, transform.position, Quaternion.identity), 3f);
            InGameScreen.SetActive(false);
            pauseScreen.SetActive(true);
            Destroy(gameObject);
            
        }
    }

    void shootBullet()
    {

        Transform tempBullet;
        tempBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.right * bulletSpeed);
        DataMenager.Instance.ShotBullet++;
        
    }
}
