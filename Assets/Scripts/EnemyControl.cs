using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    
    public static bool playerIn;
    GameObject main;
    void Start()
    {
      // main= GameObject.Find("Main").GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, main.transform.position, 7f * Time.deltaTime);

        if (playerIn)
        {
           // transform.position = Vector3.MoveTowards(transform.position,main.transform.position , 7f * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIn = true;
           // tempPlayer.position = other.gameObject.transform.position;
        }
    }
}
