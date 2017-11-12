using UnityEngine;
using System.Collections;

public class MissileFire : MonoBehaviour {

	public GameObject missile;
	public GameObject Heli;

	float spawnRate = 2.0f;
	float current,lastSpawn;
	GameObject target;

	float distance;
	public float range = 10f;

	void Start () {
		InvokeRepeating ("getTarget", 0, 1.0f);
	}

	void Update () {
		if (target != null) {
			transform.LookAt (target.transform);

			current = Time.time;
			if ((current - lastSpawn) > spawnRate) {
				shoot ();
				lastSpawn = current;
			}
		}
	}

	void getTarget(){
		if (Heli != null) {
			distance = (Heli.transform.position - transform.position).magnitude; 
			if (distance < range) {
				target = Heli;
			} else
				target = null;
		} else
			target = null;
	}

	void shoot(){
		Instantiate (missile, transform.position, transform.rotation);
	}
}
