using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
  public float lookRadius = 10f;
  private GameObject[] massTarget;

  private GameObject[] enemyTarget;
  private GameObject playerTarged;
  private NavMeshAgent agent;
  private Animator ch_animator;
  private bool isRunning;
  Growth other_gr;
  Growth own_gr;

  Growth enemy_gr;
    void Start()
    {
        agent=GetComponent<NavMeshAgent>();
        massTarget = GameObject.FindGameObjectsWithTag("Mass");
        enemyTarget=GameObject.FindGameObjectsWithTag("Enemy");
        ch_animator = GetComponent<Animator>();
        own_gr=GetComponent<Growth>();
        playerTarged=GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
    massTarget = GameObject.FindGameObjectsWithTag("Mass");
    //Mass finding
    isRunning = false;
    foreach (var mass in massTarget)
    {
      float distance = Vector3.Distance(mass.transform.position, transform.position);
      if (distance <= lookRadius)
      {
        agent.SetDestination(mass.transform.position);
        isRunning = true;
      }
    }
    //Player finding
    float player_dist = Vector3.Distance(playerTarged.transform.position, transform.position);
    if (player_dist <= lookRadius)
    {
      other_gr=playerTarged.GetComponent<Growth>();

      if (other_gr.score<own_gr.score)
      {
        agent.SetDestination(playerTarged.transform.position);
        isRunning = true;
      }
    }
    //Enemy finding
    enemyTarget = GameObject.FindGameObjectsWithTag("Enemy");
    foreach (var enemy in enemyTarget)
    {
        if (enemy.name!=gameObject.name)
        {
        float distance = Vector3.Distance(enemy.transform.position, transform.position);
        enemy_gr = enemy.GetComponent<Growth>();
        if (enemy_gr.score < own_gr.score)
        {
          agent.SetDestination(enemy.transform.position);
          isRunning = true;
        }
        }

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
