using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LS{
    public class AnimatorManager : MonoBehaviour
{
    public Animator anim;
     public void PlayerTargetAnimation(string targetAnim, bool isInteracting)
        {
            anim.applyRootMotion = isInteracting;
            anim.SetBool("isInteracting", isInteracting);
            anim.CrossFade(targetAnim, 0.2f);
        }
}
}  