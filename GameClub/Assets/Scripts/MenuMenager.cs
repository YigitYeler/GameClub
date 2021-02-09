using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuMenager : MonoBehaviour
{
    public GameObject dataBoard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void DataBoardButton()
    {
        DataMenager.Instance.LoadData();

        dataBoard.transform.GetChild(1).GetComponent<Text>().text = "TOTAL BULLET SHOT : " + DataMenager.Instance.totalShotBullet.ToString();
        dataBoard.transform.GetChild(2).GetComponent<Text>().text = "TOTAL ENEMY KILLED : " + DataMenager.Instance.totalEnemyKilled.ToString();
        dataBoard.transform.GetChild(5).GetComponent<Text>().text = "BEST BULLET SHOT : " + DataMenager.Instance.bestShotBullet.ToString();
        dataBoard.transform.GetChild(6).GetComponent<Text>().text = "BEST ENEMY KILLED : " + DataMenager.Instance.bestEnemyKilled.ToString();
        dataBoard.SetActive(true);
    }

    public void XButton()
    {
        dataBoard.SetActive(false);
    }
}
