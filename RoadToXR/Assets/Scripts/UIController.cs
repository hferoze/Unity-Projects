using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

	[SerializeField]
	private GameObject mGameController;

	[SerializeField]
	private GvrAudioSource UIAudioSource;

	[SerializeField]
	private AudioClip ButtonClickAudioClip;

	void Start(){
		mGameController = GameObject.Find ("GameController");
	}

	public void OnFirstWelcomeScreenBtnClicked(GameObject nextScreen){
		StartCoroutine (PlayButtonSound ());
		GameObject thisScreen = GameObject.Find ("FirstScreen");
		nextScreen.SetActive (true);
		thisScreen.SetActive (false);
	}

	public void OnSecondWelcomeScreenBtnClicked(GameObject toClose){
		StartCoroutine (PlayButtonSound ());
		mGameController.GetComponent<GameController> ().StartSystem ();
		toClose.SetActive (false);
	}

	public void Reset(){
		StartCoroutine (PlayButtonSound ());
		mGameController.GetComponent<GameController> ().Reset ();
	}

	public void Recenter(){
		StartCoroutine (PlayButtonSound ());
		mGameController.GetComponent<GameController> ().Recenter ();
	}

	public void OnCloseCurrentPanelClicked(){
		StartCoroutine (PlayButtonSound ());
		mGameController.GetComponent<GameController> ().CloseCurrentPanel ();
	}

	public void OnNextImageClicked(Transform image_to_set){
		StartCoroutine (PlayButtonSound ());
		mGameController.GetComponent<GameController> ().GoToNextInfoImage (image_to_set);
	}

	public void OnPrevImageClicked(Transform image_to_set){
		StartCoroutine (PlayButtonSound ());
		mGameController.GetComponent<GameController> ().GoToPrevInfoImage (image_to_set);
	}

	private IEnumerator PlayButtonSound(){
		yield return new WaitForEndOfFrame ();
		UIAudioSource.PlayOneShot (ButtonClickAudioClip);
	}
}
