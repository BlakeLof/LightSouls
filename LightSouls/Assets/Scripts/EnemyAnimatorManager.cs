using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LS{
    public class EnemyAnimatorManager : AnimatorManager
{
    private void Awake(){
        anim = GetComponent<Animator>();
    }
}
}