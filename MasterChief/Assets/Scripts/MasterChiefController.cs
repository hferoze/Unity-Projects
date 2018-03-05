using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MasterChiefController : MonoBehaviour {

    [SerializeField]
    private Transform m_Gun;
    [SerializeField]
    private Transform m_RightHand;
    [SerializeField]
    private Transform m_ReleaseGunPos;
    [SerializeField]
    private GameObject m_FirePower;

    private Animator mAnimator;

    private bool mIsHoldingGun = false;
  
    private void Start(){
        mAnimator = GetComponent<Animator>();
    }

    private void Update(){
        if (CrossPlatformInputManager.GetButtonDown("Hold Gun")){ //h
            HoldGun();
        }else if (CrossPlatformInputManager.GetButtonDown("Release Gun")){ //r
            ReleaseGun();
        }
        //Check gun rotation
        if (mIsHoldingGun){
            if (CrossPlatformInputManager.GetButtonDown("Fire1")){ //left ctrl/left mouse
                Fire(true);
            }
            if (CrossPlatformInputManager.GetButtonUp("Fire1")){ 
                Fire(false);
            }
        }
    }

    private void HoldGun(){
        if (!mIsHoldingGun){
            mIsHoldingGun = true;
            mAnimator.SetBool("HoldingGun", mIsHoldingGun);
            m_Gun.parent = m_RightHand;
            m_Gun.localPosition = new Vector3(-1f, 0f, 0f);
            m_Gun.localEulerAngles = new Vector3(65f, 0f, 0f);
        }
    }

    private void ReleaseGun(){
        mIsHoldingGun = false;
        mAnimator.SetBool("HoldingGun", mIsHoldingGun);
        m_Gun.parent = m_ReleaseGunPos;
        m_Gun.localPosition = new Vector3(0f, 0f, 0f);
        m_Gun.localEulerAngles = new Vector3(0f, 0f, 75f);
    }

    private void Fire(bool fire){
        if (!m_FirePower.activeSelf.Equals(fire))
            m_FirePower.SetActive(fire);
    }

}
