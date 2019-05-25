using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePersistentManager : MonoBehaviour
{
    [HideInInspector] public int highscore=0, currentscore;
    
    public virtual void create()
    {

    }
    public virtual void save()
    {

    }

    public virtual void load()
    {

    }

    public virtual void checkHighScore()
    {

    }
}
