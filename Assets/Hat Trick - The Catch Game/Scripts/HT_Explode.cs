using UnityEngine;
using System.Collections;

public class HT_Explode : MonoBehaviour {

	public GameObject explosion;
	public ParticleSystem[] effects;
    Vector3 border = new Vector3(Screen.width, Screen.height, 0);
    Vector3 camborder;

    void Start()
    {
        camborder = Camera.main.ScreenToWorldPoint(border);
    }



    void Update()
    {
        if (transform.position.x > camborder.x || transform.position.x < -camborder.x || transform.position.y < -camborder.y)
        {
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Player") {
            PersistentManager.PM.currentscore -= 2;
			Instantiate (explosion, transform.position, transform.rotation);
			foreach (var effect in effects) {
				effect.transform.parent = null;
				effect.Stop ();
				Destroy (effect.gameObject, 1.0f);
			}
			Destroy (gameObject);
		}
	}
}
