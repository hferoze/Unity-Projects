using UnityEngine;
using UnityEngine.UI;

/*
 * Created by hferoze 
 */

public class SpeechRecogResultUpdate : MonoBehaviour {

    public GameObject SpeechResultTextGO;

    private Text SpeechResultText;

    void Start(){
        SpeechResultText = SpeechResultTextGO.GetComponent<Text>();
    }

	public void UpdateResultText(string txt){
        string[] matches = txt.Split('\n');
        foreach (string m in matches){
            Debug.Log("match : " + m);
        }
        SpeechResultText.text = txt;
    }
}
