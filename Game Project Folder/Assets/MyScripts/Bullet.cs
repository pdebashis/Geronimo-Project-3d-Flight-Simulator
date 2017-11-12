using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void Start () {
		Destroy (this.gameObject,2);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.Translate(0,0,5);
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Enemy") {
			other.gameObject.GetComponent<Enemy> ().Hit (10);
			Destroy (this.gameObject);
		} else {
			Destroy (this.gameObject);
		}
	}
}
