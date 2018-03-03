using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoControlScript : MonoBehaviour {

	private static string WAYPOINT0_BACKGROUND = "panel";
	private static string WAYPOINT1_BACKGROUND = "panel";
	private static string WAYPOINT2_BACKGROUND = "panel";
	private static string WAYPOINT3_BACKGROUND = "panel";
	private static string WAYPOINT4_BACKGROUND = "panel";

	[SerializeField]
	private GameObject openInfoEffect;

	[SerializeField]
	private GameObject infoPanel;

	private Transform ps;
	private Transform infoPanelTr;

	private Dictionary<string, string> panelToBackgroundHash =  new Dictionary<string, string>();

	private List<Sprite> mSlideShowImages;
	private int currImageIdx = 0;

	private Camera mMainCamera;

	void Start(){
		infoPanel.SetActive (false);
		panelToBackgroundHash.Add ("WayPoint0", WAYPOINT0_BACKGROUND);
		panelToBackgroundHash.Add ("WayPoint1", WAYPOINT1_BACKGROUND);
		panelToBackgroundHash.Add ("WayPoint2", WAYPOINT2_BACKGROUND);
		panelToBackgroundHash.Add ("WayPoint3", WAYPOINT3_BACKGROUND);
		panelToBackgroundHash.Add ("WayPoint4", WAYPOINT4_BACKGROUND);

		Sprite [] sprites = Resources.LoadAll<Sprite> ("Sprites/SlideShowImages");
		mSlideShowImages = new List<Sprite> (sprites);

		mMainCamera = Camera.main;
	}

	public IEnumerator showInformationPanel(Transform current_way_point){
		disableTransform (transform, current_way_point);
		infoPanelTr = infoPanel.transform;
		if (infoPanelTr==null)
			infoPanelTr = Instantiate (infoPanel.transform, transform.position, Quaternion.identity);

		disableAllChildren (infoPanelTr.GetChild(0));

		string backgroundSprite = WAYPOINT0_BACKGROUND;
		panelToBackgroundHash.TryGetValue (current_way_point.name, out backgroundSprite);
		Transform panelBackground = infoPanelTr.GetChild (0);
		panelBackground.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/"+backgroundSprite);

		closeCurrentInfoPanel ();

		infoPanelTr.position = (mMainCamera.transform.position + mMainCamera.transform.forward);
		infoPanelTr.eulerAngles = new Vector3(infoPanelTr.localEulerAngles.x, mMainCamera.transform.localEulerAngles.y, infoPanelTr.localEulerAngles.z); 

		Vector3 pos = infoPanelTr.position;
		pos = new Vector3 (pos.x, pos.y - 0.5f, pos.z);
		if (ps == null)
			ps = Instantiate (openInfoEffect.transform, pos, openInfoEffect.transform.localRotation);
		else
			ps.position = pos;

		ps.gameObject.SetActive (false);
		ps.gameObject.SetActive (true);

		yield return new WaitForSeconds (0.35f);

		infoPanelTr.gameObject.SetActive (true);
		yield return new WaitForSeconds (0.8f);
		enableTransformWithName (infoPanelTr.GetChild(0), current_way_point);
		currImageIdx = 0;
	}

	public void enableAllChildren(Transform parent){
		for(int i=0; i<parent.childCount; i++) {
			Transform child = parent.GetChild (i);
			child.gameObject.SetActive (true);
		}
	}

	public void closeCurrentInfoPanel(){
		infoPanelTr.gameObject.SetActive (false);
	}

	public void GoToNextImage(Transform image_to_set){
		StopCoroutine (LoadImageAndSet (null, null));

		currImageIdx = currImageIdx + 1 > mSlideShowImages.Count - 1 ? 0 : currImageIdx + 1;

		StartCoroutine(LoadImageAndSet(image_to_set.GetComponent<Image>(), mSlideShowImages[currImageIdx]));
	}

	public void GoToPreviousImage(Transform image_to_set){
		StopCoroutine (LoadImageAndSet (null, null));

		currImageIdx = currImageIdx - 1 >= 0 ? currImageIdx - 1: mSlideShowImages.Count - 1 ;

		StartCoroutine(LoadImageAndSet(image_to_set.GetComponent<Image>(), mSlideShowImages[currImageIdx]));
	}

	private IEnumerator LoadImageAndSet(Image image_to_set, Sprite image){
		yield return new WaitForEndOfFrame ();
		image_to_set.sprite = image;
	}

	private void disableTransform(Transform parent, Transform to_disable_tr){
		for(int i=0; i<parent.childCount; i++) {
			Transform child = parent.GetChild (i);
			if (child.Equals (to_disable_tr)) {
				child.gameObject.SetActive (false);
			} else {
				child.gameObject.SetActive (true);
			}
		}
	}

	private void disableAllChildren(Transform parent){
		for(int i=0; i<parent.childCount; i++) {
			Transform child = parent.GetChild (i);
			child.gameObject.SetActive (false);
		}
	}
		
	private void enableTransformWithName(Transform parent, Transform to_disable_tr){
		for(int i=0; i<parent.childCount; i++) {
			Transform child = parent.GetChild (i);
			if (child.name.Equals (to_disable_tr.name)) {
				child.gameObject.SetActive (true);
			} else {
				child.gameObject.SetActive (false);
			}
		}
	}
}
