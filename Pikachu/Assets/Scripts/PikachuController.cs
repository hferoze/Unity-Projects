using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimTriggers { Idle, Happy, Angry, Sit};
public class PikachuController : MonoBehaviour {

    [SerializeField]
    private Animator m_PikachuAnimator;
    [SerializeField]
    private PikachuFacialExpressionController m_PikachuFacialExpressionControllerScript;

	public void GetHappy(){
        m_PikachuAnimator.SetTrigger(AnimTriggers.Happy.ToString());
        m_PikachuFacialExpressionControllerScript.SetHappyFacialExpression();
        m_PikachuFacialExpressionControllerScript.StopBlinking();
    }

    public void GetAngry(){
        m_PikachuAnimator.SetTrigger(AnimTriggers.Angry.ToString());
        m_PikachuFacialExpressionControllerScript.SetAngryFacialExpression();
        m_PikachuFacialExpressionControllerScript.StartAngryBlinking();
    }

    public void Idle(){
        m_PikachuAnimator.SetTrigger(AnimTriggers.Idle.ToString());
        m_PikachuFacialExpressionControllerScript.SetNormalFacialExpression();
        m_PikachuFacialExpressionControllerScript.StartNormalBlinking();
    }

    public void Sit(){
        m_PikachuAnimator.SetTrigger(AnimTriggers.Sit.ToString());
        m_PikachuFacialExpressionControllerScript.SetNormalFacialExpression();
        m_PikachuFacialExpressionControllerScript.StartNormalBlinking();
    }
}
