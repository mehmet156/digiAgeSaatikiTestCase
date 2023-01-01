using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    public static float movementSpeed = 7;    
    private Vector3 position;
    public static bool gameEnd;
    public float horizontalRange = 4, horizontalMoveSpeed = 0.05f;
    public Transform  boss;
    public Animator animator;
    Transform tempEnemy;
    public static Transform tempPlayer;
    public GameObject start;
    //Counter counter;
    void Start()
    {
        
        movementSpeed = 0;
        gameEnd = false;
        start.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
       // tempPlayer.position = transform.position;
        position.x = Mathf.Clamp(position.x, -horizontalRange, horizontalRange);
        if (gameEnd == false)
        {

            if (Input.touchCount > 0)
            {
                start.SetActive(false);
                movementSpeed = 15;
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                    Vector2 pos = touch.deltaPosition;

                    position = position + new Vector3(pos.x * horizontalMoveSpeed, 0, 0);

                    transform.position = position;

                }
            }

            position = position + new Vector3(0, 0, movementSpeed * Time.deltaTime);
            transform.position = position;

        }
        if(gameEnd)
        {
            BossFight();
        }
    }

    private void FixedUpdate()
    {
        

    }
    public void BossFight()
    {
               
        transform.position = Vector3.MoveTowards(transform.position, (boss.transform.position), 7f*Time.deltaTime);
        
    }

    public void Fight()
    {
        transform.position = Vector3.MoveTowards(transform.position, (tempEnemy.position), 7f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            gameEnd = true;
            Debug.Log("end");
        }
           if(other.tag=="Zone")
        {
           
            movementSpeed = 1f;
            //tempEnemy.transform.position = other.gameObject.transform.position;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        movementSpeed = 9;
    }
}
