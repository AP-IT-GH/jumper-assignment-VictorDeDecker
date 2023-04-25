using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public GameObject parent;

    private void Start()
    {
        Invoke("SpawnObstacle", Random.Range(2f,5f));
    }

    private void SpawnObstacle()
    {
        GameObject obstacle = Instantiate(ObjectToSpawn);
        obstacle.transform.parent = parent.transform;
        obstacle.transform.localPosition = new Vector3(-10, 0.5f, 0); 
        obstacle.transform.localScale = new Vector3(1, 1, 4);
        Invoke("SpawnObstacle", Random.Range(2f, 5f));
    }
}
