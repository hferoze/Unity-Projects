using System.Collections;
using UnityEngine;

/*
 * Created by hferoze 
 */

public class GUIManager : MonoBehaviour{

    public void OnStartListeningBtnClick(){
#if UNITY_ANDROID && !UNITY_EDITOR
        PluginHelper.StartListening();
#endif
    }

    public void Scale(GameObject obj){
        StartCoroutine(ScaleUpDown(obj));      
    }

    private IEnumerator ScaleUpDown(GameObject obj){
        yield return new WaitForEndOfFrame();
        Vector3 curr_scale = obj.transform.localScale;
        Vector3 mid_scale = new Vector3(curr_scale.x + curr_scale.x/5f, curr_scale.y + curr_scale.y/5f, curr_scale.z);
        Vector3 final_scale = curr_scale;
        float totalT = 0.5f;
        float currT = 0f;

        while (currT < totalT){
            currT += Time.deltaTime;
            Vector3 a = Vector3.Lerp(curr_scale, mid_scale, currT / totalT);
            Vector3 b = Vector3.Lerp(mid_scale, final_scale, currT / totalT);
            obj.transform.localScale = Vector3.Lerp(a, b, currT / totalT);
            yield return null;
        }
    }
}
