using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject shopPaper;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("TotalCoinText").GetComponent<Text>().text = "TOTAL COIN : " + DataMenager.Instance.totalEarnedCoin.ToString();
        GameObject.Find("SwordText").GetComponent<Text>().text = DataMenager.Instance.totalSword.ToString();
        GameObject.Find("HatText").GetComponent<Text>().text = DataMenager.Instance.totalHat.ToString();
        GameObject.Find("PotionText").GetComponent<Text>().text = DataMenager.Instance.totalPotion.ToString();
        GameObject.Find("POWER").GetComponent<Text>().text = "POWER : " + DataMenager.Instance.power.ToString();
        GameObject.Find("DEFANCE").GetComponent<Text>().text = "DEFANCE : " + DataMenager.Instance.defance.ToString();
        GameObject.Find("ABILITY").GetComponent<Text>().text = "ABILITY : " + DataMenager.Instance.ability.ToString();

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && Input.GetKeyDown("e"))
        {

            shopPaper.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
