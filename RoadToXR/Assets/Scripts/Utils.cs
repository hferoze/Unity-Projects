using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour {

	public static IEnumerator Move(Transform who, Transform target, float duration){
		yield return new WaitForEndOfFrame ();
		float currentT = 0f;
		Vector3 currentPos = who.position;
		Vector3 targetPos = new Vector3(target.position.x - 0.2f, target.position.y, target.position.z + 0.5f);
		while (currentT < duration) {
			currentT += Time.deltaTime;
			who.position = Vector3.Lerp (currentPos, targetPos, currentT / duration);
			yield return null;
		}
	}
}
