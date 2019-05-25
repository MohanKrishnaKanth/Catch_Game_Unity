using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    Vector3 border = new Vector3(Screen.width, Screen.height, 0);
    Vector3 camborder;
    // Start is called before the first frame update
    void Start()
    {
        camborder = Camera.main.ScreenToWorldPoint(border); 
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x>camborder.x||transform.position.x<-camborder.x||transform.position.y<-camborder.y)
        {
            Destroy(this.gameObject);
        }
    }
}
