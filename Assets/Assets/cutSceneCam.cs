using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutSceneCam : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        
        StartCoroutine(switchCam());

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Transform target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(target);
    }

    IEnumerator switchCam()
    {
        yield return new WaitForSeconds(3);
        GetComponent<CameraFollow>().enabled = true;
        FindObjectOfType<SwipeManager>().enabled = true;
        Destroy(this);
    }
}
