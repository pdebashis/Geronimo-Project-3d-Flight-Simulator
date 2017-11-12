using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	private int health,maxHealth;
    private Image healthBar;

	public GameObject explosion;

	public int Health{get {return health;}}

	void Start () {
		health = 100;
		maxHealth = 100;
		healthBar = GameObject.Find ("HeliUI").transform.FindChild ("HealthBG").FindChild ("Health").GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (this.gameObject);
		}
	}

	public void Hit(int damage){
		health -= damage;
		healthBar.fillAmount = (float)Health / (float)maxHealth;
	}
}
