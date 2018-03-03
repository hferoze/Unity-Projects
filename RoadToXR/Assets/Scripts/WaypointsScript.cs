using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsScript : MonoBehaviour {

	[SerializeField]
	private PlayerScript playerScript;

	[SerializeField]
	private Material beingLookedAt;
	[SerializeField]
	private Material notBeingLookedAt;

	[SerializeField]
	private GameObject orb;

	[SerializeField]
	private AudioClip ClickedAudioClip;

	public void SetIsPlayerLooking(bool looking){
		if (looking) {
			orb.GetComponent<Renderer> ().material = beingLookedAt;
			GetComponentInChildren<RotateScript> ().enabled = false;
		} else {
			orb.GetComponent<Renderer> ().material = notBeingLookedAt;
			GetComponentInChildren<RotateScript> ().enabled = true;
		}
	}

	public void OnClicked(){
		GetComponent<GvrAudioSource> ().PlayOneShot (ClickedAudioClip);

		playerScript.moveToTarget (transform);
	}
}
