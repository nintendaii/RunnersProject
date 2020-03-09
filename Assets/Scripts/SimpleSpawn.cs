using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawn : MonoBehaviour
{
  public float spawnPoint;
  public GameObject prefab;
  public int spawnCount;
  private Vector3 vec;

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown("space")){
        StartSpawn();
    }
  }
  void StartSpawn()
  {
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
