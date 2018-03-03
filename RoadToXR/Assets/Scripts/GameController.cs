using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	[SerializeField]
	private GameObject WayPoints;

	[SerializeField]
	private GameObject Head;

	[SerializeField]
	private GameObject [] ParticleSystemGameObjects;

	[SerializeField]
	private AudioClip SystemStartAudioClip;

	private bool is_system_running = false;

	private InfoControlScript mInfoControlScript;

	void Start () {
		if (FindObjectsOfType (GetType ()).Length > 1) {
			Destroy (gameObject);
		}
		DisableWayPoints ();
		DisableParticles ();
		isSystemRunning = false;
		mInfoControlScript = WayPoints.GetComponent<InfoControlScript> ();
	}
	
	public void EnableWayPoints(){
		WayPoints.SetActive (true);
	}

	public void DisableWayPoints(){
		WayPoints.SetActive (false);
	}

	public void EnableParticles(){
		foreach (GameObject psGo in ParticleSystemGameObjects) {
			psGo.SetActive (true);
		}
	}

	public void DisableParticles (){
		foreach (GameObject psGo in ParticleSystemGameObjects) {
			psGo.SetActive (false);
		}
	}

	public void StartHead(){
		Head.GetComponent<HeadMovementControl>().StartMovement ();
	}

	public void StopHead(){
		Head.GetComponent<HeadMovementControl>().StopMovement ();
	}


	public void Reset(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void StartSystem(){
		isSystemRunning = true;
		EnableWayPoints ();
		EnableParticles ();
		StartHead ();
		PlaySystemStartSound ();
	}

	public void StopSystem(){
		isSystemRunning = true;
		DisableWayPoints ();
		DisableParticles ();
		StopHead ();
	}
		
	public void Recenter() {
		#if !UNITY_EDITOR
		GvrCardboardHelpers.Recenter();
		#else
		GvrEditorEmulator emulator = FindObjectOfType<GvrEditorEmulator>();
		if (emulator == null) {
			return;
		}
		emulator.Recenter();
		#endif  // !UNITY_EDITOR
	}

	public void CloseCurrentPanel(){
		mInfoControlScript.enableAllChildren (WayPoints.transform);
		mInfoControlScript.closeCurrentInfoPanel ();
	}

	public void GoToNextInfoImage(Transform image_to_set){
		mInfoControlScript.GoToNextImage (image_to_set);
	}

	public void GoToPrevInfoImage(Transform image_to_set){
		mInfoControlScript.GoToPreviousImage (image_to_set);
	}

	public bool isSystemRunning{
		get { return is_system_running;}
		set {is_system_running = value;}
	}

	private void PlaySystemStartSound (){
		GetComponent<GvrAudioSource> ().PlayOneShot (SystemStartAudioClip);
	}
}


