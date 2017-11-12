using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToraBoraLoader : MonoBehaviour {

	IEnumerator Start() {
		AsyncOperation async = SceneManager.LoadSceneAsync("Cave");
		yield return async;
		Debug.Log("Loading complete");
	}
}