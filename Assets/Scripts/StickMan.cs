using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickMan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Obstacle")
        {
           // Destroy(other.gameObject);
            Destroy(this.gameObject);            
        }
        if(other.tag=="Enemy")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        
    }

}
