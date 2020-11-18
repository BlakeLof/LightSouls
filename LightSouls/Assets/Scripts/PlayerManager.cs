using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LS
{


    public class PlayerManager : MonoBehaviour
    {
        Animator anim;
        InputHandler inputHandler;
        // Start is called before the first frame update
        void Start()
        {
            inputHandler = GetComponent<InputHandler>();
            anim = GetComponentInChildren<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            inputHandler.isInteracting = anim.GetBool("isInteracting");
            inputHandler.rollFlag = false;
            inputHandler.sprintFlag = false;
        }

    }

}
