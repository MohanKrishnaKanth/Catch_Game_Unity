using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
   [HideInInspector] public Camera cam;
    float MaxWidth;
    bool a = false;
    float hatwidth,camwidth;
    private void Start()
    {
        if(cam==null)
        {
            cam = Camera.main;
        }
        Vector3 screensize = new Vector3(Screen.width, Screen.height,0f);
        Vector3 TargetPosition = Camera.main.ScreenToWorldPoint(screensize);
        hatwidth = GetComponent<Renderer>().bounds.extents.x;
        MaxWidth = TargetPosition.x-hatwidth;
        camwidth = Camera.main.orthographicSize + 2.8f;
    }

    private void Update()
    {
        
       if(Mathf.RoundToInt(GameController.GM.timeleft)!=0)
        {
            if(PersistentManager.PM.inputtoggle.GetComponent<Toggle>().isOn==true)
            {
                accelrometer();
            }
            if (PersistentManager.PM.inputtoggle.GetComponent<Toggle>().isOn == false)
            {
                mouseinput();
            }
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        PersistentManager.PM.currentscore += 1;

    }

    void accelrometer()
    {
        float limit = Mathf.Clamp(transform.position.x, -camwidth, camwidth);
        transform.position = new Vector3(limit, 0, 0);
        transform.Translate(Input.acceleration.x, 0, 0);
    }

    void mouseinput()
    {
        Vector3 rawPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetposition = new Vector3(rawPosition.x, 0, 0);
        targetposition.x = Mathf.Clamp(targetposition.x, -MaxWidth, MaxWidth);
        GetComponent<Rigidbody2D>().MovePosition(targetposition);
    }
}
