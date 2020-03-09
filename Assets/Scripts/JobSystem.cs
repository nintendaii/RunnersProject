using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
using Unity.Jobs;

namespace Project
{

  public class JobSystem : MonoBehaviour
  {
      public float speed=15f;
      public float range = 100f;
      public int incremement=100;
      public int count=1;

      public GameObject prefab;
    TransformAccessArray transforms;

    MoveJob moveJob;

    JobHandle moveHandle;
    void Start()
    {
      transforms = new TransformAccessArray(0, -1);
    }

    // Update is called once per frame
    void Update()
    {
      moveHandle.Complete();
      if (Input.GetKeyDown("space"))
        AddObjects(incremement);
      moveJob = new MoveJob()
      {
        moveSpeed = speed,
        deltaTime = Time.deltaTime
      };
      moveHandle = moveJob.Schedule(transforms);
      JobHandle.ScheduleBatchedJobs();
    }
    void AddObjects(int amount)
    {
      moveHandle.Complete();
      transforms.capacity = transforms.length + amount;
      for (int i = 0; i < amount; i++)
      {
        float xVal = Random.Range(-range, range);
        float zVal = Random.Range(-range, range);
        Vector3 pos = new Vector3(xVal, 0f, zVal);
        Quaternion rot = Quaternion.Euler(0f, 180f, 0f);
        var obj = Instantiate(prefab, pos, rot) as GameObject;
        transforms.Add(obj.transform);
      }
      count += amount;
    }
  }
}

