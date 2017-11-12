using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AfghanistanLoader : MonoBehaviour {

	IEnumerator Start() {
		AsyncOperation async = SceneManager.LoadSceneAsync("Mountain");
		yield return async;
		Debug.Log("Loading complete");
	}
}