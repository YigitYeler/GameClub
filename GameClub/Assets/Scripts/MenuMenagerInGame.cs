using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMenagerInGame : MonoBehaviour
{
    public GameObject InGameScreen, pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseButton()
    {
        Time.timeScale = 0;
        InGameScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }
    public void PlayButton()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        InGameScreen.SetActive(true);
    }
    public void ReplayButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        DataMenager.Instance.Health = 100;
    }
    public void HomeButton()
    {
        DataMenager.Instance.SaveData();
        SceneManager.LoadScene(0);
        DataMenager.Instance.Health = 100;
    }
}
