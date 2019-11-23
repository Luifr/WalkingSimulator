using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField]
    GameObject warnName = null;

    [SerializeField]
    GameObject scoreBoard = null;

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
        scoreBoard.SetActive(set);
    }

    public void Quit(){
        Application.Quit();
    }

    IEnumerator DisableGameObject(){
        yield return new WaitForSeconds(.8f);
        warnName.SetActive(false);
    }

}
