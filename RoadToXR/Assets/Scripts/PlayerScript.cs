using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	[SerializeField]
	private GvrAudioSource PlayerAudioSource;

	[SerializeField]
	private AudioClip MovementAudioClip;

	private float moveDuration = 1f;

	public void moveToTarget(Transform target){
		PlayerAudioSource.PlayOneShot (MovementAudioClip);
		StartCoroutine(Utils.Move(transform, target, moveDuration));
		StartCoroutine(ShowPanel(target));
	}

	private IEnumerator ShowPanel(Transform wayPoint){
		yield return new WaitForSeconds (moveDuration);
		StartCoroutine(wayPoint.parent.GetComponent<InfoControlScript> ().showInformationPanel (wayPoint));
	}
}
