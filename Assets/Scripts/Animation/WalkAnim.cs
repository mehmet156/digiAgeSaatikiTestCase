using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAnim : MonoBehaviour
{
    public Animator animator;
   
   public static bool playerIn;
    Transform tempPlayer;
    void Start()
    {
        animator.Play("Run");
        playerIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerIn)
        {
         //  transform.position = Vector3.MoveTowards(transform.position, (MoveControl.tempPlayer.position), 7f * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
    }
}
