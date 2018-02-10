using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PikachuFacialExpressionController : MonoBehaviour {

    [SerializeField]
    private Material m_MainMat;
    [SerializeField]
    private Renderer m_FaceRenderer;

    private enum CurrentBlinkType { None, Normal, Angry};

    private float mCurrentOffset = 0f;
    private CurrentBlinkType mCurrentBlinkType = CurrentBlinkType.Normal;

    private float mBlinkWaitTime = 8f;
    private float mBlinkTime = 0f;
    private float mNormalBlinkOffset = -0.147f;
    private float mAngryBlinkOffset = -0.447f;

    public float normal_face_offset = 0.0f;
    public float happy_face_offset = -0.655f;
    public float angry_face_offset = -0.3f;
    public float blink_offset = -0.147f;
   
    void Start(){
        mBlinkTime = Time.time;
    }

    void Update(){
        //m_FaceRenderer.materials[0].SetTextureOffset("_MainTex", new Vector2(0f, blink_offset));
        if (Time.time - mBlinkTime > mBlinkWaitTime && !mCurrentBlinkType.Equals(CurrentBlinkType.None)){
            StartCoroutine(Blink(Random.Range(1, 3)));
            mBlinkTime = Time.time;
        }
    }

    public void SetHappyFacialExpression(){
        SetFacialExperessionOffset(happy_face_offset);
    }

    public void SetAngryFacialExpression(){
        SetFacialExperessionOffset(angry_face_offset);
    }

    public void SetNormalFacialExpression(){
        SetFacialExperessionOffset(normal_face_offset);
    }

    public void StartNormalBlinking(){
        mCurrentBlinkType = CurrentBlinkType.Normal;
        blink_offset = mNormalBlinkOffset;
    }

    public void StartAngryBlinking(){
        mCurrentBlinkType = CurrentBlinkType.Angry;
        blink_offset = mAngryBlinkOffset;
    }

    public void StopBlinking(){
        mCurrentBlinkType = CurrentBlinkType.None;
    }

    private void SetFacialExperessionOffset(float offset){
        mCurrentOffset = offset;
        m_FaceRenderer.materials[0].SetTextureOffset("_MainTex", new Vector2(0f, mCurrentOffset));
    }

    private IEnumerator Blink(int times){
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < times; i++){
            m_FaceRenderer.materials[0].SetTextureOffset("_MainTex", new Vector2(0f, blink_offset));
            yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
            m_FaceRenderer.materials[0].SetTextureOffset("_MainTex", new Vector2(0f, mCurrentOffset));
            yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
        }
    }

}
