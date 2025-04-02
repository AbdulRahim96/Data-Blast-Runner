using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpanwer : MonoBehaviour
{
    public bool isDyanimc = false;
    [ShowIf("isDyanimc")] [SerializeField] private Transform player;
    [ShowIf("isDyanimc")] public Vector3 offset;
    [ShowIf("isDyanimc")] public float[] posiblePositions;
    public GameObject[] obstacles;
    public Vector2 spawnRange = new Vector2(1, 3);

    public bool isMovable = false;

    [ShowIf("isMovable")] public float speed = 1;
    [ShowIf("isMovable")] public Ease animationType;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        if(isDyanimc)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            transform.parent = null;
        }

        while (true)
        {
            float spawnTime = Random.Range(spawnRange.x, spawnRange.y);
            yield return new WaitForSeconds(spawnTime);
            Spawn();
        }
    }

    [Button("Spawn")]
    private void Spawn()
    {
        if(isDyanimc)
        {
            float xPos = posiblePositions[Random.Range(0, posiblePositions.Length)];
            transform.position = new Vector3(xPos, offset.y, player.position.z + offset.z);
        }
        int index = Random.Range(0, obstacles.Length);
        GameObject obj = Instantiate(obstacles[index], transform.position, transform.rotation);

        if (isMovable)
        {
            Tween movingTween = obj.transform.DOMove(obj.transform.forward * speed, 1f) // Move to Z = 5 over 1 second
            .SetLoops(-1, LoopType.Incremental) // Infinite loops, keeps increasing
            .SetEase(animationType)
            .SetRelative(true); // Move relative to the current position

            obj.GetComponent<MovingTween>().movingTween = movingTween;
        }
    }
}
