using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RespawnObjects : MonoBehaviour
{
    public GameObject _Object;
    public bool powers = false;
    public GameObject[] powerUps;

    public async Task respawn(GameObject obj)
    {
        //StartCoroutine(respawnRoutine());
        //StartCoroutine(RespawnPool(obj));
        await Task.Delay(20000);
        obj.SetActive(true);
    }
    public IEnumerator respawnRoutine()
    {
        yield return new WaitForSeconds(20);
        GameObject instance;
        if (powers == true)
            instance = Instantiate(powerUps[Random.Range(0, powerUps.Length)], transform.position, transform.rotation);
        else
            instance = Instantiate(_Object, transform.position, transform.rotation);
        instance.transform.parent = transform;
        instance.GetComponent<Icons>().respawnObjects = this;
    }

    IEnumerator RespawnPool(GameObject obj)
    {
        yield return new WaitForSeconds(20);
        obj.SetActive(true);
    }
}
