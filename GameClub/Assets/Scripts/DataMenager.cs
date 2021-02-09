using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;

public class DataMenager : MonoBehaviour
{
    public static DataMenager Instance;

    private int shotBullet;
    public int totalShotBullet;
    private int enemyKilled;
    public int totalEnemyKilled;
    public int bestShotBullet;
    public int bestEnemyKilled;
    public int earnedCoin;
    public int totalEarnedCoin;
    public int health;
    public int bulletDamage = 0;
    public int sword, hat, potion;
    public int totalSword, totalHat, totalPotion;
    public int power, defance, ability;

    EasyFileSave myfile;

    string mesaj;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            StartProcess();
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int ShotBullet
    {
        get
        {
            return shotBullet;
        }
        set
        {
            shotBullet = value;
            //mesaj = ShotBullet <= 0 ? "MERMİ BİTTİ" : shotBullet.ToString();
            GameObject.Find("ShotBulletText").GetComponent<Text>().text = "SHOT BULLET : " + shotBullet.ToString();
        }
    }
    public int EnemyKilled
    {
        get
        {
            return enemyKilled;
        }
        set
        {
            enemyKilled = value;
            GameObject.Find("EnemyKilledText").GetComponent<Text>().text = "ENEMY KILLED : " + enemyKilled.ToString();
        }
    }
    public int EarnedCoin
    {
        get
        {
            return earnedCoin;
        }
        set
        {
            earnedCoin = value;
            GameObject.Find("CoinText").GetComponent<Text>().text = "COİN : " + earnedCoin.ToString();
        }
    }

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            GameObject.Find("HealthText").GetComponent<Text>().text = "HEALTH:" + health.ToString();
        }
    }

    public int BulletDamage
    {
        get
        {
            return bulletDamage;
        }
        set
        {
            bulletDamage = value;
        }
    }

    public int Sword
    {
        get
        {
            return sword;
        }
        set
        {
            sword = value;
        }
    }

    public int Hat
    {
        get
        {
            return hat;
        }
        set
        {
            hat = value;
        }
    }

    public int Potion
    {
        get
        {
            return potion;
        }
        set
        {
            potion = value;
        }
    }

    public void StartProcess()
    {
        myfile = new EasyFileSave();
        LoadData();
    }

    public void SaveData()
    {
        totalShotBullet += shotBullet;
        totalEnemyKilled += enemyKilled;
        totalEarnedCoin += earnedCoin;
        totalHat += hat;
        totalPotion += potion;
        totalSword += sword;

        myfile.Add("totalShotBullet", totalShotBullet);
        myfile.Add("totalEnemyKilled", totalEnemyKilled);
        myfile.Add("totalEarnedCoin", totalEarnedCoin);
        myfile.Add("totalHat", totalHat);
        myfile.Add("totalPotion", totalPotion);
        myfile.Add("totalSword", totalSword);
        myfile.Add("power", power);
        myfile.Add("defance", defance);
        myfile.Add("ability", ability);

        if (enemyKilled != 0 && bestEnemyKilled != 0 && shotBullet / enemyKilled <= bestShotBullet / bestEnemyKilled && enemyKilled > bestEnemyKilled)
            {
                bestShotBullet = shotBullet;
                bestEnemyKilled = enemyKilled;
                myfile.Add("bestShotBullet", bestShotBullet);
                myfile.Add("bestEnemyKilled", bestEnemyKilled);
            }
            else if (bestShotBullet == 0 && bestEnemyKilled == 0)
            {
                bestShotBullet = shotBullet;
                bestEnemyKilled = enemyKilled;
                myfile.Add("bestShotBullet", bestShotBullet);
                myfile.Add("bestEnemyKilled", bestEnemyKilled);
            }
        
        myfile.Save();
        shotBullet = 0;
        enemyKilled = 0;
        earnedCoin = 0;
        sword = 0;
        hat = 0;
        potion = 0;

    }

    public void LoadData()
    {
        if (myfile.Load())
        {
            totalShotBullet = myfile.GetInt("totalShotBullet");
            totalEnemyKilled = myfile.GetInt("totalEnemyKilled");
            bestShotBullet = myfile.GetInt("bestShotBullet");
            bestEnemyKilled = myfile.GetInt("bestEnemyKilled");
            totalEarnedCoin = myfile.GetInt("totalEarnedCoin");
            totalSword = myfile.GetInt("totalSword");
            totalHat = myfile.GetInt("totalHat");
            totalPotion = myfile.GetInt("totalPotion");
            power = myfile.GetInt("power");
            defance = myfile.GetInt("defance");
            ability = myfile.GetInt("ability");


        }
    }
}
