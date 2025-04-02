using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class EndlessRoadManager : MonoBehaviour
{
    public static EndlessRoadManager instance;
    public List<GameObject> roads;
    public float offset = 60f;

    private void Awake()
    {
        instance = this;
    }

    [Button("Update Road")]
    public void MoveRoad()
    {
        GameObject movedRoad = roads[Random.Range(0,2)];
        roads.Remove(movedRoad);
        Vector3 newPos = roads[roads.Count - 1].transform.position;
        movedRoad.transform.position = new Vector3(0, newPos.y, newPos.z + offset);
        roads.Add(movedRoad);
        movedRoad.transform.SetAsLastSibling();
        
    }
}
