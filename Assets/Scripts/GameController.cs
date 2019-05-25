using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController GM;
    [HideInInspector] public Camera cam;
    public GameObject BallPrefab, BombPrefab;
    float MaxWidth;
    public float timeleft;
    
    private void Awake()
    {
        if(GM==null)
        {
            GM = this;
        }
        else
        {
            if(GM!=this)
            {
                Destroy(this.gameObject);
            }
        }
    }
    private void Start()
    {
        settime();
        if (cam == null)
        {
            cam = Camera.main;
        }
        Vector3 screensize = new Vector3(Screen.width, Screen.height, 0f);
        Vector3 TargetPosition = Camera.main.ScreenToWorldPoint(screensize);
        float ballwidth = BallPrefab.GetComponent<Renderer>().bounds.extents.x;
        MaxWidth = TargetPosition.x - ballwidth;
        StartCoroutine(SpawnBalls());
        
    }

    public IEnumerator SpawnBalls()
    {
       
        while(Mathf.RoundToInt(timeleft)>0)
        {
            Vector3 spawnposition = new Vector3(Random.Range(-MaxWidth, MaxWidth), transform.position.y, 0f);
            Instantiate(BallPrefab, spawnposition, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));
            Instantiate(BombPrefab, spawnposition, Quaternion.identity);

        }

       

    }

   public void settime()
    {
        timeleft = PersistentManager.PM.TimeCount;
    }
    private void FixedUpdate()
    {
        if(timeleft>0)
        {
            timeleft -= Time.fixedDeltaTime;
        }

        if (Mathf.RoundToInt(timeleft) == 0)
        {
            Time.timeScale = 0;
        }
    }
}
