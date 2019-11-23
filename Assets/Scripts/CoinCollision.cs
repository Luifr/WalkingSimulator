using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Player")){
            Destroy(gameObject, 0.1f);
            ScoreManager.CollectCoin();
        }
    }
}
