using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
   [HideInInspector] public Camera cam;
    float MaxWidth;
    bool a = false;
    private void Start()
    {
        if(cam==null)
        {
            cam = Camera.main;
        }
        Vector3 screensize = new Vector3(Screen.width, Screen.height,0f);
        Vector3 TargetPosition = Camera.main.ScreenToWorldPoint(screensize);
        float hatwidth = GetComponent<Renderer>().bounds.extents.x;
        MaxWidth = TargetPosition.x-hatwidth;

    }

    private void Update()
    {
       if(Mathf.RoundToInt(GameController.GM.timeleft)!=0)
        {
            Vector3 rawPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 targetposition = new Vector3(rawPosition.x, 0, 0);
            targetposition.x = Mathf.Clamp(targetposition.x, -MaxWidth, MaxWidth);
            GetComponent<Rigidbody2D>().MovePosition(targetposition);

       
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            Destroy(collision.gameObject);
        PersistentManager.PM.currentscore += 1;

       
    }


}
