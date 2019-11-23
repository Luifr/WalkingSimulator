using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float speed = 5f;
    public bool canWalk;
    
    // Start is called before the first frame update
    void Start()
    {
        canWalk = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!canWalk) return;

        Vector3 pos = transform.position;
        if(Input.GetKey(KeyCode.W)){
            pos.y += speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S)){
            pos.y -= speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A)){
            pos.x -= speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D)){
            pos.x += speed * Time.deltaTime;
        }
        transform.position = pos;
    }
}
