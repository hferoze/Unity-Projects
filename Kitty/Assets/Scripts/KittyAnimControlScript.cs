using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyAnimControlScript : MonoBehaviour {

    private Animator mAnimator;

	// Use this for initialization
	void Start () {
        mAnimator = GetComponent<Animator>();
    }
	
	public void SwitchAnim(string anim){
        if (anim.StartsWith("scratch")){
            mAnimator.SetTrigger("scratch");
        }
    }
}
