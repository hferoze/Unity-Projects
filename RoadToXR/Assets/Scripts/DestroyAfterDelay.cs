using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour {

	private float delay = 1f;

	// Use this for initialization
	void Start () {
		StartCoroutine (DestroySelf ());		
	}

	private IEnumerator DestroySelf(){
		yield return new WaitForSeconds (delay);
		Destroy (gameObject);
	}
}
