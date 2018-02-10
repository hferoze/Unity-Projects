using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyScript : MonoBehaviour {
    
    private KittyAnimControlScript mKittyAnimControlScript;
    private float mAnimSwitchWaitTime = 5f;
    private float mStartTime = 0f;

    void Start () {
        mKittyAnimControlScript = GetComponent<KittyAnimControlScript>();
        mStartTime = Time.time;
    }
	
	void Update () {
		if (Time.time - mStartTime > mAnimSwitchWaitTime){
            mKittyAnimControlScript.SwitchAnim("scratch");
            mAnimSwitchWaitTime = Random.Range(5f, 15f);
            mStartTime = Time.time;
        }
	}
}
