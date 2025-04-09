using System;
using StarterAssets;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.Utilities;

public class Robot : MonoBehaviour
{

   FirstPersonController player;
   NavMeshAgent agent;
   const String PLayername="Player";
    void Awake()
    {
        agent=GetComponent<NavMeshAgent>();
        player=FindFirstObjectByType<FirstPersonController>();
    }
    void Update()
    {
        if(!player) return;
        agent.SetDestination(player.transform.position);
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(PLayername))
        {
            EnemyHealth enemyHealth=GetComponent<EnemyHealth>();
            enemyHealth.selfdistruct();
        }
    }

}
