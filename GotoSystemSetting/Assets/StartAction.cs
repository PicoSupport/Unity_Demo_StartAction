﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAction : MonoBehaviour {

    string actionForSettings = "pui.settings.action.SETTINGS";
    string actionForBluetooth = "pui.settings.action.BLUETOOTH_SETTINGS";
    string actionForWifi = "pui.settings.action.WIFI_SETTINGS";

    string actionForController = "pui.settings.action.CONTROLLER_SETTINGS";
    // Use this for initialization
    void Start () {

        
	}

	// Update is called once per frame
	void Update () {

	}
	public void startActionSettings()
	{
		startToAction(actionForSettings);
	}
    public void startActionBluetooth()
    {
        startToAction(actionForBluetooth);
    }
    public void startActionWifi()
    {
        startToAction(actionForWifi);
    }
    public void startActionController()
    {
        startToAction(actionForController);
    }
    private void startToAction(string action)
	{
		AndroidJavaClass jcPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject joActivity = jcPlayer.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject joIntent = new AndroidJavaObject("android.content.Intent", action);
		joActivity.Call("startActivity", joIntent);
	}
    
    //Start app in vrshell.
    private void startToAction2(string action)
    {
        AndroidJavaClass jcPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject joActivity = jcPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject joIntent = new AndroidJavaObject("android.content.Intent", "pvr.intent.action.ADAPTER");
        joIntent.Call<AndroidJavaObject>("setPackage", "com.pvr.adapter");
        joIntent.Call<AndroidJavaObject>("putExtra", "way", 2);

        joIntent.Call<AndroidJavaObject>("putExtra", "args", new string[] { action });
        joActivity.Call<AndroidJavaObject>("startService", joIntent);
    }
	
    public void gotoFileManager()
    {
        gotoPUIApp("com.pvr.filemanager", "com.pvr.filemanager.refactor.view.activity.MainActivity");
    }

    void gotoPUIApp(string pkgName, string clsName)
    {
        AndroidJavaClass jcPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject joActivity = jcPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject joIntent = new AndroidJavaObject("android.content.Intent", "pvr.intent.action.ADAPTER");
        joIntent.Call<AndroidJavaObject>("setPackage", "com.pvr.adapter");
        joIntent.Call<AndroidJavaObject>("putExtra", "way", 0);
        joIntent.Call<AndroidJavaObject>("putExtra", "args", new string[] { pkgName, clsName });
        joActivity.Call<AndroidJavaObject>("startService", joIntent);
    }
}
