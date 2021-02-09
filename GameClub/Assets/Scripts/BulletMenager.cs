using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMenager : MonoBehaviour
{
    public float bulletDamage, lifeTime;
    int power;
    // Start is called before the first frame update
    void Start()
    {
        power = DataMenager.Instance.power;
        bulletDamage += power;
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
