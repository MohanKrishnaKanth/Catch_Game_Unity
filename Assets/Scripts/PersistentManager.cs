using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PersistentManager : BasePersistentManager
{
    public static PersistentManager PM;
    public string oldname,newname;
    public float TimeCount;
    public float TimeTaken;
    public Toggle inputtoggle;
  
    private void Awake()
    {
        create();
      
    }

    private void Update()
    {
        checkHighScore();
        
    }

    public override void create()
    {
        if(PM==null)
        {
            PM = this;
            load();
        }
        else
        {
            if(PM!=this)
            {
                Destroy(this.gameObject);
            }
        }
        
        DontDestroyOnLoad(this.gameObject);

    }

    public override void save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/GameData.data");
        GameData data = new GameData();
        data._HighScore = highscore;
        data._Name = newname;
        data._TimeTaken = TimeCount;
        bf.Serialize(file, data);
        file.Close();
      
    }

    public override void load()
    {
        if(File.Exists(Application.persistentDataPath +"/GameData.data"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/GameData.data", FileMode.Open);
            GameData data = (GameData)bf.Deserialize(file);
            highscore = data._HighScore;
            oldname = data._Name;
            TimeTaken = data._TimeTaken;
            
        }
    }

    [Serializable]
    class GameData
    {
        public int _HighScore;
        public string _Name;
        public float _TimeTaken;
    }

    public override void checkHighScore()
    {
        
        if (currentscore > highscore)
        {
            highscore = currentscore;
            save();
        }
        
    }
}

