using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class smoothMouseLook : MonoBehaviour {

	Vector2 _mouseAbsolute;
	Vector2 _smoothMouse;
	public float speed = 0f;

	public Vector2 clampInDegrees = new Vector2(30,30);
	public bool lockCursor;
	Vector2 targetDirection;
	float accel_y,accel_x;

	private Image Xaxis,Yaxis,Xtilt,Ytilt;

	void Start () {
		Xaxis = GameObject.Find ("HeliUI").transform.FindChild ("axisXBG").FindChild ("axisX").GetComponent<Image> ();
		Yaxis = GameObject.Find ("HeliUI").transform.FindChild ("axisYBG").FindChild ("axisY").GetComponent<Image> ();
		Xtilt = GameObject.Find ("HeliUI").transform.FindChild ("tiltXBG").FindChild ("tiltX").GetComponent<Image> ();
		Ytilt = GameObject.Find ("HeliUI").transform.FindChild ("tiltYBG").FindChild ("tiltY").GetComponent<Image> ();
		targetDirection = transform.rotation.eulerAngles;
	}

	void Update () {
		
		accel_y = Input.acceleration.y + 0.5f;
		accel_y = Mathf.Clamp (accel_y,-8.0f,0.8f);

		if (Mathf.Abs (accel_y) > 0.1f) {
			transform.Rotate (new Vector3 (accel_y*70, 0, 0));
		} else {
			transform.Rotate (Vector3.zero);
		}

		accel_x = Input.acceleration.x;

		if (Mathf.Abs (accel_x) > 0.1f) {
			transform.Rotate (new Vector3 (0,0,-accel_x*70));
		} else {
			transform.Rotate (Vector3.zero);
		}

		Xtilt.fillAmount = (accel_x+1)/2f;
		Ytilt.fillAmount = (accel_y+1)/2f;
	}
	
	void FixedUpdate () {
		
		var targetOrientation = Quaternion.Euler (targetDirection);

		speed += Time.deltaTime * 5;
		speed = Mathf.Clamp (speed, 10, 40);

		var mouseDelta = new Vector2 (CrossPlatformInputManager.GetAxis("Horizontal"),-CrossPlatformInputManager.GetAxis ("Vertical"));

		_mouseAbsolute += mouseDelta;

		Xaxis.fillAmount = (mouseDelta.x+1)/2f;
		Yaxis.fillAmount = (mouseDelta.y+1)/2f;

		if (mouseDelta.y < 0f )
			transform.position += transform.forward * Time.deltaTime * speed;
		else if(mouseDelta.y > 0f)
			transform.position -= transform.forward * Time.deltaTime * speed;
		else speed = 0f;

		if (clampInDegrees.x < 360)
			_mouseAbsolute.x = Mathf.Clamp (_mouseAbsolute.x, -clampInDegrees.x * 0.5f, clampInDegrees.x * 0.5f);

		var xRotation = Quaternion.AngleAxis (-_mouseAbsolute.y, targetOrientation * Vector3.right);

		transform.localRotation = xRotation;

		if (clampInDegrees.y < 360)
			_mouseAbsolute.y = Mathf.Clamp (_mouseAbsolute.y, -clampInDegrees.y * 0.5f, clampInDegrees.y * 0.5f);
		
		transform.localRotation *= targetOrientation;

		var yRotation = Quaternion.AngleAxis (_mouseAbsolute.x, transform.InverseTransformDirection (Vector3.up));
		transform.localRotation *= yRotation;


		//above a certain height
		float terrainHeightUs = Terrain.activeTerrain.SampleHeight (transform.position) + 5.0f;
		if (terrainHeightUs > transform.position.y) {
			transform.position = new Vector3 (transform.position.x, terrainHeightUs, transform.position.z);
		}
	
	}
}