using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

	void Start () {
		Destroy (this.gameObject,3);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0,0,2);
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<Player> ().Hit (10);
			Destroy (this.gameObject);
		} else {
			Destroy (this.gameObject);
		}
	}
}
