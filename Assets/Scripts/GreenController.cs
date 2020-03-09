using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GreenController : MonoBehaviour
{
  public float lookRadius = 10f;
  public Transform target;
  NavMeshAgent agent;
  private Animator ch_animator;
  private bool isRunning;
  private Vector3 startPosition;

  private Transform eTransform;
  void Start()
  {
    target = GameObject.FindWithTag("Player").transform;
    agent = GetComponent<NavMeshAgent>();
    ch_animator = GetComponent<Animator>();
    eTransform = GetComponent<Transform>();
    startPosition = eTransform.position;
  }
  void Update()
  {
    isRunning = false;
    float distance = Vector3.Distance(target.position, transform.position);
    if (distance <= lookRadius)
    {
      Vector3 dest=new Vector3(-target.position.x,target.position.y,target.position.z+20);
      agent.SetDestination(dest);
      isRunning = true;
    }
    if (isRunning)
    {
      ch_animator.SetBool("Run", true);
    }
    else
    {
      ch_animator.SetBool("Run", false);
    }
  }

  void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, lookRadius);
  }

}
