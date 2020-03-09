using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float spawnPoint;
    public GameObject prefab;
    public int spawnCount;
    private Vector3 vec;
    public float timer;
    private float initialTime;
    // Start is called before the first frame update
    void Start()
    {
        initialTime=timer;
        StartSpawn();
    }

    // Update is called once per frame
    void Update()
    {
    timer -= Time.deltaTime;
    if (timer <= 0.0)
    {
      StartSpawn();
      timer = initialTime;
      spawnCount = spawnCount + 10;
    }
    }
    void StartSpawn(){
    for (int i = 0; i < spawnCount; i++)
    {
      var randomx = Random.Range(-spawnPoint, spawnPoint);
      vec.y = 2f;
      vec.x = randomx;
      var randomz = Random.Range(-spawnPoint, spawnPoint);
      vec.z = randomz;
      Instantiate(prefab, vec, Quaternion.identity);
    }
    }
}
