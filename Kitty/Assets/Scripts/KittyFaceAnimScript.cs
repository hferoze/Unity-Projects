using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyFaceAnimScript : MonoBehaviour {

    [SerializeField]
    private Material m_MainMat;
    [SerializeField]
    private Renderer m_FaceRenderer;

    private float mBlinkWaitTime = 8f;
    private float mBlinkTime = 0f;

    public float off = -0.3f;

    // Use this for initialization
    void Start () {
        mBlinkTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
		if (Time.time-mBlinkTime > mBlinkWaitTime) {
           StartCoroutine(Blink(Random.Range(1,3)));
           mBlinkTime = Time.time;
        }
    }

    private IEnumerator Blink(int times){
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < times; i++){
            m_FaceRenderer.materials[1].SetTextureOffset("_MainTex", new Vector2(0f, off));
            yield return new WaitForSeconds(Random.Range(0.2f,0.5f));
            m_FaceRenderer.materials[1].SetTextureOffset("_MainTex", new Vector2(0f, 0f));
            yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
        }
    }
}
