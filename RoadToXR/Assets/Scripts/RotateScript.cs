using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RotateMode {Down, Up, Left, Right, Forward, Back};

public class RotateScript : MonoBehaviour {

	public int dir = 1;

	public RotateMode CurrentRotateMode = RotateMode.Down;

	// Update is called once per frame
	void Update () {
		if (CurrentRotateMode == RotateMode.Down) {
			transform.Rotate (Vector3.down * dir * Time.deltaTime * 20f, Space.Self);
		} else if (CurrentRotateMode == RotateMode.Up) {
			transform.Rotate (Vector3.up * dir * Time.deltaTime * 20f, Space.Self);
		} else if (CurrentRotateMode == RotateMode.Left) {
			transform.Rotate (Vector3.left * dir * Time.deltaTime * 20f, Space.Self);
		} else if (CurrentRotateMode == RotateMode.Right) {
			transform.Rotate (Vector3.right * dir * Time.deltaTime * 20f, Space.Self);
		} else if (CurrentRotateMode == RotateMode.Forward) {
			transform.Rotate (Vector3.forward * dir * Time.deltaTime * 20f, Space.Self);
		} else if (CurrentRotateMode == RotateMode.Back) {
			transform.Rotate (Vector3.back * dir * Time.deltaTime * 20f, Space.Self);
		}
	}
}
