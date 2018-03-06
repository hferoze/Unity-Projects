using System.Collections.Generic;
using UnityEngine;

/*
 * Created by hferoze 
 */

public class PluginHelper : MonoBehaviour {

	private static string TAG = "Speech-To-Text";

	private static AndroidJavaObject unityPlugin = null;
	private static AndroidJavaObject activityContext = null;

	private static Dictionary<string, string> inputExtras = new Dictionary<string, string>();

	void Start(){
#if UNITY_ANDROID && !UNITY_EDITOR
        if (unityPlugin == null) {

			using (AndroidJavaClass activityClass = new AndroidJavaClass ("com.unity3d.player.UnityPlayer")) {
				activityContext = activityClass.GetStatic<AndroidJavaObject> ("currentActivity");
            }

			using (AndroidJavaClass pluginClass = new AndroidJavaClass ("com.hferoze.speechtotextplugin.SpeechToTextUnityBridge")) {
				if (pluginClass != null) {
                    unityPlugin = pluginClass.CallStatic<AndroidJavaObject> ("getInstance");
					unityPlugin.Call ("setContext", activityContext);
                }
			}
		}
#endif
    }
    
    public static void StartListening(){
        if (activityContext != null)
        {
            activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() => {
                unityPlugin.Call("getSpeechInput");
            }));
        }
    }
}
