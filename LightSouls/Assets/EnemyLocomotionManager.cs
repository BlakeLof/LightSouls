using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LS{
public class EnemyLocomotionManager : MonoBehaviour
{
    EnemyManager enemyManager;

    LayerMask detectionLayer;
private void Awake(){
    enemyManager = GetComponent<EnemyManager>();
}

    public void HandleDetection(){
        Collider[] colliders = Physics.OverlapSphere(transform.position, enemyManager.detectionRadius, detectionLayer);

        for(int i = 0; i < colliders.Length; i++){
                
        }
    }
}
}
