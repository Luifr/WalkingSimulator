using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance = null;
    static int score = 0;
    static Text text = null;

    void Start(){
        SceneManager.sceneLoaded += OnSceneLoaded;
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        score = 0;
        text = GameObject.Find("score")?.GetComponent<Text>();
    }

    public static void CollectCoin(int value = 1){
        score += value;
        text.text = "Score: " + score;
    }

    public static int GetScore(){
        return score;
    }

}
