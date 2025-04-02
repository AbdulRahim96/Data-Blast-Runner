using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tractor : MonoBehaviour
{
    public RespawnObjects respawnObjects;
    public int speed = 5;
    public int distance = 500;
    bool inrange = false;
    public bool isBoss = false;
    // Start is called before the first frame update
    void Start()
    {
        if(isBoss == true)
          Destroy(gameObject, 6);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var dis = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position);
        if(dis <= distance)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            inrange = true;
            
        }
        if (dis > distance && inrange == true)
        {
            //respawnObjects.respawn();
            Destroy(gameObject);
        }

    }

    
}
