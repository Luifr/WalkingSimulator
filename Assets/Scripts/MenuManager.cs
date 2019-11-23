using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MenuManager : MonoBehaviour
{

    [SerializeField]
    GameObject warnName = null;

    [SerializeField]
    GameObject scoreBoard = null;

    [SerializeField]
    GameObject scoreText;

    [SerializeField]
    GameObject controlGroup;
    
    public void Play() {
        string name = GameObject.Find("name").GetComponent<Text>().text;
        if(name == "") {
            warnName.SetActive(true);
            StopCoroutine("DisableGameObject");
            StartCoroutine("DisableGameObject");
            return;
        }
        NetworkManager.name = name;
        SceneManager.LoadScene("Game");
    }

    public void ToMenu(){
        SceneManager.LoadScene("Menu");
    }

    public void ToggleScoreBoard(bool set = true){
        if(set){
            NetworkManager.Get<Players>("/scores", SetScoreBoard);
        }
        else{
            scoreBoard.SetActive(set);
        }
    }

    public void Quit(){
        Application.Quit();
    }

    IEnumerator DisableGameObject(){
        yield return new WaitForSeconds(.8f);
        warnName.SetActive(false);
    }

    void SetScoreBoard(Players players){
        foreach (Transform child in controlGroup.transform) {
            Destroy(child.gameObject);
        }
        Vector3 pos = new Vector3(0,0,0);
        foreach(Player player in players.players){
            GameObject textObject = Instantiate(scoreText, pos, Quaternion.identity);
            textObject.transform.SetParent(controlGroup.transform);
            Text text = textObject.GetComponent<Text>();
            text.text = player.name + " : " + player.score;
        }
        scoreBoard.SetActive(true);
    }

}

[Serializable]
public class Player {
    public string score;
    public string name;
}

[Serializable]
public class Players {
    public Player[] players;
}

