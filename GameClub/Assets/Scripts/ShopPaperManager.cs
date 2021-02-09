using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPaperManager : MonoBehaviour
{
    public GameObject shopPaper;
    public GameObject buySword, sellSword, sellHat, buyHat, sellPotion, buyPotion, powerPlus, defancePlus, abilityPlus;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (DataMenager.Instance.totalSword <= 0)
        {
            sellSword.SetActive(false);
            powerPlus.SetActive(false);
        }
        else
        {
            sellSword.SetActive(true);
            powerPlus.SetActive(true);
        }
        if (DataMenager.Instance.totalHat <= 0)
        {
            sellHat.SetActive(false);
            defancePlus.SetActive(false);
        }
        else
        {
            sellHat.SetActive(true);
            defancePlus.SetActive(true);
        }
        if (DataMenager.Instance.totalPotion <= 0)
        {
            sellPotion.SetActive(false);
            abilityPlus.SetActive(false);
        }
        else
        {
            sellPotion.SetActive(true);
            abilityPlus.SetActive(true);

        }
        if (DataMenager.Instance.totalEarnedCoin <= 0)
        {
            buyHat.SetActive(false);
            buySword.SetActive(false);
            buyPotion.SetActive(false);
        }
        else
        {
            buyHat.SetActive(true);
            buySword.SetActive(true);
            buyPotion.SetActive(true);
        }
    }

    public void CloseShopButton()
    {
        shopPaper.SetActive(false);
        Time.timeScale = 1;
    }

    public void BuySword()
    {
        DataMenager.Instance.totalSword++;
        DataMenager.Instance.totalEarnedCoin -= 10;
    }

    public void SellSword()
    {
        DataMenager.Instance.totalSword--;
        DataMenager.Instance.totalEarnedCoin += 10;
    }

    public void BuyHat()
    {
        DataMenager.Instance.totalHat++;
        DataMenager.Instance.totalEarnedCoin -= 10;
    }

    public void SellHat()
    {
        DataMenager.Instance.totalHat--;
        DataMenager.Instance.totalEarnedCoin += 10;
    }

    public void BuyPotion()
    {
        DataMenager.Instance.totalPotion++;
        DataMenager.Instance.totalEarnedCoin -= 10;
    }

    public void SellPotion()
    {
        DataMenager.Instance.totalPotion--;
        DataMenager.Instance.totalEarnedCoin += 10;
    }

    public void PowerUp()
    {
        DataMenager.Instance.power += 1;
        DataMenager.Instance.totalSword -= 1;
    }

    public void DefanceUp()
    {
        DataMenager.Instance.defance += 1;
        DataMenager.Instance.totalHat -= 1;
    }

    public void AbilityUp()
    {
        DataMenager.Instance.ability += 1;
        DataMenager.Instance.totalPotion -= 1;
    }


}
