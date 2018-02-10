using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    [SerializeField]
    private PikachuController m_PikachuControllerScript;

	public void OnIdleBtnClicked(){
        m_PikachuControllerScript.Idle();
    }

    public void OnHappyBtnClicked(){
        m_PikachuControllerScript.GetHappy();
    }

    public void OnAngryBtnClicked(){
        m_PikachuControllerScript.GetAngry();
    }

    public void OnSitBtnClicked(){
        m_PikachuControllerScript.Sit();
    }
}
