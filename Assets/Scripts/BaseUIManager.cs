using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUIManager : MonoBehaviour
{
    [HideInInspector]
    public int menuscene = 0;
    [HideInInspector]
    public int gamescene = 1;


  
    public virtual void restart()
    {

    }
    public virtual void quit()
    {
     
    }
    public virtual void play()
    {

    }
    public virtual void resume()
    {

    }
    public virtual void pause()
    {

    }

   public virtual void mainmenu()
    {

    }

    public virtual void gameovermenu()
    {

    }
}
