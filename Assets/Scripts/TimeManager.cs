using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

public class TimeManager : MonoBehaviour
{

    [SerializeField]
    float totalTime = 10f;
    float timeLeft;
    Text timeText;
    bool gameIsOver;
    [SerializeField]
    GameObject gameOverPanel = null;

    // Start is called before the first frame update
    void Start()
    {
        gameIsOver = false;
        timeLeft = totalTime;
        timeText = GameObject.Find("time").GetComponent<Text>();
        timeText.text = "Time left: " + timeLeft.ToString("F2").Replace(",", ".");
    }

    // Update is called once per frame
    void Update()
    {
        if(gameIsOver) return;

        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0){
            timeLeft = 0f;
            GameOver();
        }
        
        timeText.text = "Time left: " + timeLeft.ToString("F2").Replace(",", ".");
        
    }

    void GameOver(){
        gameIsOver = true;
        GameObject.Find("Player").GetComponent<PlayerMovement>().canWalk = false;
        if(gameOverPanel) gameOverPanel.SetActive(true);
        WWWForm data = new WWWForm();
        data.AddField("name", NetworkManager.name);
        data.AddField("score", ScoreManager.GetScore());
        NetworkManager.Post<string>("/score", data, null);
    }

    public void IncreaseTime(float time = 1f){
        timeLeft += time;
    }

}
