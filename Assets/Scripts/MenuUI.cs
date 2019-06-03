using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : BaseUIManager
{
    public static MenuUI MU;
    public Text highscoreText;
    public Text highScore_name,texttime,timeTaken;
    public GameObject InfoPanel;
    bool a = false, b = false;
    public Toggle t;
    public Text inputtype, newnametext;
    private void Start()
    {
        if(MU==null)
        {
            MU = this;
        }
        else
        {
            if(MU!=this)
            {
                Destroy(this.gameObject);
            }
        }
        copy();
        DontDestroyOnLoad(this.gameObject);
    }
    public override void play()
    {
        InfoPanel.SetActive(true);
        gameObject.transform.Find("MainMenu").gameObject.SetActive(false);
    }

    public void Playstart()
    {
        if (a==true&&b==true)
        {
            InfoPanel.SetActive(false);
            string s = texttime.GetComponent<Text>().text.ToString();
            PersistentManager.PM.TimeCount = float.Parse(s);
            SceneManager.LoadScene(gamescene);
            Time.timeScale = 1;
            PersistentManager.PM.currentscore = 0;
            PersistentManager.PM.newname = newnametext.GetComponent<Text>().text;
          
        }
    }

    public override void quit()
    {
        Application.Quit();
    }


    public void copy()
    {
        if(PersistentManager.PM)
        {
            highscoreText.text = "HIGHSCORE: " + PersistentManager.PM.highscore;
            highScore_name.text = "NAME: " + PersistentManager.PM.oldname;
            timeTaken.text = "TIMETAKEN: " + PersistentManager.PM.TimeTaken;
        }
    }

    public void active()
    {
        gameObject.transform.Find("MainMenu").gameObject.SetActive(true);
        InfoPanel.SetActive(false);
    }


    public void okname()
    {
        a = true;
    }

    public void oktime()
    {
        b = true;
    }

    public void ValueChange()
    {
        bool switchon = t.GetComponent<Toggle>().isOn;
        if (switchon)
        {
            inputtype.GetComponent<Text>().text = "ACCELROMETER";
        }
        else
        {
            inputtype.GetComponent<Text>().text = "TOUCH";
        }
    }
}
