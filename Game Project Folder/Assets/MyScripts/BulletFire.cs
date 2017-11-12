using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class BulletFire : MonoBehaviour {

	public GameObject bullet;
	public float delay = 8f;
	private float counter;
	LineRenderer lr;

	public int ammo = 0;
	private Image ammoBar;

	public int Ammo{get {return ammo;}}

	void Start () {
		ammo = 50;
		ammoBar = GameObject.Find ("MobileSingleStickControl").transform.FindChild ("WeaponSystem").FindChild ("Ammo").GetComponent<Image> ();
		lr = transform.GetComponent<LineRenderer> ();
	}

	void Update () {

	}

	void LateUpdate(){
		lr.SetPosition (0, transform.position);
		RaycastHit hit;

		if (Physics.Raycast(transform.position,transform.forward,out hit, 300f)){
			lr.SetPosition (1, hit.point);
		} else {
			lr.SetPosition (0, Vector3.zero);
			lr.SetPosition (1, Vector3.zero);
		}

		if (CrossPlatformInputManager.GetButton ("Jump") && counter > delay) {
			if (Ammo > 0) {
				shoot ();
				counter = 0;
			} else
				ammo = 50;
		}
		counter += Time.deltaTime;

	}


	void shoot(){
		ammo -= 1;
		Instantiate (bullet, transform.position, transform.rotation);
		ammoBar.fillAmount = (float)Ammo / 50f;
	}
}