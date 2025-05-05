using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class EndlessRoadManager : MonoBehaviour
{
    public static EndlessRoadManager instance;
    public List<GameObject> currentRoads, roadPool;
    public float offset = 60f;

    private void Awake()
    {
        instance = this;
    }

    [Button("Update Road")]
    public void MoveRoad()
    {
        GameObject movedRoad = currentRoads[0];
        currentRoads.Remove(movedRoad);
        roadPool.Add(movedRoad);
        movedRoad.SetActive(false);

        Vector3 newPos = currentRoads[currentRoads.Count - 1].transform.position;
        GameObject newRoad = GetAvailableRoad();
        newRoad.SetActive(true);
        newRoad.transform.position = new Vector3(0, newPos.y, newPos.z + offset);
        roadPool.Remove(newRoad);
        currentRoads.Add(newRoad);
        newRoad.transform.SetAsLastSibling();
    }

    private GameObject GetAvailableRoad()
    {
        GameObject road = roadPool[Random.Range(0, roadPool.Count)];
        return road;
    }
}
