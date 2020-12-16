using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace LS{
public class EnemyLocomotionManager : MonoBehaviour
{

   NavMeshAgent navMeshAgent;
    EnemyManager enemyManager;
    EnemyAnimatorManager enemyAnimatorManager;
    public CharacterStats currentTarget;

    public float distanceFromTarget;
    public float stoppingDistance = 0.5f;

   public LayerMask detectionLayer;

   public float rotationSpeed = 15;

   Rigidbody enemyRigidBody;
private void Awake(){
    enemyManager = GetComponent<EnemyManager>();
    enemyAnimatorManager = GetComponentInChildren<EnemyAnimatorManager>();
    navMeshAgent = GetComponentInChildren<NavMeshAgent>();
    enemyRigidBody = GetComponent<Rigidbody>();
}

    public void HandleDetection(){

        Collider[] colliders = Physics.OverlapSphere(transform.position, enemyManager.detectionRadius, detectionLayer);

        for(int i = 0; i < colliders.Length; i++){
                CharacterStats characterStats = colliders[i].transform.GetComponent<CharacterStats>();

                if(characterStats != null){
                    //Check For Team ID

                    Vector3 targetDirection = characterStats.transform.position - transform.position;
                    float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

                    if(viewableAngle > enemyManager.minimumDetectionAngle && viewableAngle < enemyManager.maximumDetectionAngle){
                        currentTarget = characterStats;
                    }
                }
        }
    }

    public void HandleMoveToTarget(){
        Vector3 targetDirection = currentTarget.transform.position - transform.position;
        float viewableAngle = Vector3.Angle(targetDirection, transform.forward);  
        distanceFromTarget = Vector3.Distance(currentTarget.transform.position, transform.position);

        if(enemyManager.isPreformingAction){
            enemyAnimatorManager.anim.SetFloat("Vertical", 0,0.1f, Time.deltaTime);
           navMeshAgent.enabled=false;
        }
        else{
            if(distanceFromTarget > stoppingDistance){
                 enemyAnimatorManager.anim.SetFloat("Vertical", 1,0.1f, Time.deltaTime);
            }
        }

    HandleRotateTowardsTarget();

        navMeshAgent.transform.localPosition = Vector3.zero;
        navMeshAgent.transform.localRotation= Quaternion.identity;
    }

    private void HandleRotateTowardsTarget(){
        if(enemyManager.isPreformingAction){
            Vector3 direction = currentTarget.transform.position - transform.position;
            direction.y = 0;
            direction.Normalize();

            if(direction == Vector3.zero){
                direction = transform.forward;
            }
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation, rotationSpeed/ Time.deltaTime);
        }else{
            Vector3 relativeDirection = transform.InverseTransformDirection(navMeshAgent.desiredVelocity);
            Vector3 targetVelocity = enemyRigidBody.velocity;

            navMeshAgent.enabled =true;
            navMeshAgent.SetDestination(currentTarget.transform.position);
            enemyRigidBody.velocity = targetVelocity;
            transform.rotation = Quaternion.Slerp(transform.rotation, navMeshAgent.transform.rotation, rotationSpeed/Time.deltaTime);
        }

        

       
    }
}
}
