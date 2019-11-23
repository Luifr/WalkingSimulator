using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    int range = 50;

    [SerializeField]
    float quantity = 10;

    [SerializeField]
    GameObject objectToSpawn = null;

    // Start is called before the first frame update
    void Start()
    {
        if(objectToSpawn == null) return;
        Vector3 pos = new Vector3(0,0,0);
        for(int index = 0; index < quantity ; index ++){
            Vector2 point = Random.insideUnitCircle * range;
            pos.x = point.x;
            pos.y = point.y;
            Instantiate(objectToSpawn, pos, Quaternion.identity);
        }
    }

}
