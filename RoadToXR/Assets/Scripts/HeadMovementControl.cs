using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovementControl : MonoBehaviour {

	[SerializeField]
	private GameObject XRHMD;

	[SerializeField]
	private GameObject VRHMD;

	private bool is_sys_running = false;

	public void StartMovement(){
		StartCoroutine (StartSwitchBetweenVRXRHMD());
		is_sys_running = true;
	}

	public void StopMovement(){
		is_sys_running = false;
		StopCoroutine (StartSwitchBetweenVRXRHMD ());
	}

	public void beingLookedAt(bool looking){
		if (is_sys_running) {
			if (looking)
				GetComponent<RotateScript> ().enabled = false;
			else
				GetComponent<RotateScript> ().enabled = true;
		}
	}

	public IEnumerator StartSwitchBetweenVRXRHMD(){

		yield return new WaitForEndOfFrame ();

		bool run = is_sys_running;

		GameObject currentlyShowing = VRHMD;
		GameObject nextShow = XRHMD;

		while (run) {
			GameObject tmp = currentlyShowing;
			currentlyShowing = nextShow;
			nextShow = tmp;
			yield return new WaitForSeconds (3.5f);
			currentlyShowing.SetActive (true);
			nextShow.SetActive (false);
		}
	}
}
