using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    Animator animator;
   // public bool finishGame;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveControl.gameEnd == true)
        {
            //MoveControl.gameEnd = false;
            animator.Play("MainCam");
        }
            
    }
}
