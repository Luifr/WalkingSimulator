using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

public class NetworkManager : MonoBehaviour
{

    int port = 3000;
    string baseUrl = "http://localhost:";

    public static NetworkManager instance = null;
    public static string name = "";

    void Start(){
        
        if(instance == null){
            baseUrl += port;
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    public static void Get<T>(string route, Action<T> callback){
        instance.StartCoroutine(GetRoutine<T>(instance.baseUrl + route, callback));
    }

    public static void Post<T>(string route, WWWForm data, Action<T> callback){
        instance.StartCoroutine(PostRoutine<T>(instance.baseUrl + route, data, callback));
    }

    static IEnumerator GetRoutine<T>(string route, Action<T> callback) {
        
        UnityWebRequest www = UnityWebRequest.Get(route);
        yield return www.SendWebRequest();
 
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            if(callback != null)
                callback(JsonUtility.FromJson<T>(www.downloadHandler.text));
        }
    }

    static IEnumerator PostRoutine<T>(string route, WWWForm data, Action<T> callback) {
 
        UnityWebRequest www = UnityWebRequest.Post(route, data);
        yield return www.SendWebRequest();
 
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            if(callback != null)
                callback(JsonUtility.FromJson<T>(www.downloadHandler.text));
        }
    }

}
