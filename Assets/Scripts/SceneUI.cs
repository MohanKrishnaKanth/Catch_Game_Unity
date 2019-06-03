using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneUI : BaseUIManager
{
    public static SceneUI sceneUI_Manager;
   [HideInInspector] public GameObject pausemenu, pausebutton, gameovermenupanel;
    public Text TimeLeft,score,Highscore,naame,timetaken;
    int time;

    public override void pause()
    {
        Time.timeScale = 0;
        pausemenu.SetActive(true);
    }
    private void Start()
    {
        Highscore.text = "HIGHSCORE: " + PersistentManager.PM.highscore;
        naame.text = "NAME: " + PersistentManager.PM.oldname;
        timetaken.text = "TIMETAKEN: " +
            "" + PersistentManager.PM.TimeTaken;
    }

    void Update()
    {
        time = Mathf.RoundToInt(GameController.GM.timeleft);
        TimeLeft.text = "TIME LEFT\n" + time;
        score.text = "Score: " + PersistentManager.PM.currentscore;
        if(time==0)
        {
            
            gameovermenupanel.SetActive(true);
        }
        
    }

    public override void resume()
    {
        Time.timeScale = 1;

        pausemenu.SetActive(false);
    }

    public override void mainmenu()
    {
        PersistentManager.PM.load();
        MenuUI.MU.copy();
        MenuUI.MU.active();
        SceneManager.LoadScene(menuscene);
    }

    public override void restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(gamescene);
        PersistentManager.PM.currentscore = 0;
    }


    public override void quit()
    {
        Application.Quit();
    }


}
