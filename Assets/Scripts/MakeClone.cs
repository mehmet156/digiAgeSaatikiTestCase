using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MakeClone : MonoBehaviour
{
    public float radius;
    public static int countClone,startValue;
    public GameObject pref;
    public Transform mainChar;
    int j = 0;
    public TMP_Text countText;
    void Start()
    {
        startValue = 0;
        radius = 0.4f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Clone()
    {
        Vector3 temp =new Vector3();

        for (int i = startValue; i < countClone; i ++)
        {
          
            temp.x = Mathf.Cos(i) * radius * Mathf.Sqrt(j);
            temp.z = Mathf.Sin(i) * radius * Mathf.Sqrt(j);

           
            Instantiate(pref, new Vector3(transform.position.x+temp.x,transform.position.y,transform.position.z+temp.z) ,
                Quaternion.identity).transform.parent = gameObject.transform;
            j++;
        }
        startValue = startValue + countClone;
       // countClone += (startValue-countClone);
    }

    private void OnTriggerEnter(Collider other)
    {
      
        if (other.tag == "Count")
        {
            Debug.Log("cmolokko");
            AddGate scriptGate = other.GetComponent<AddGate>();
            countClone += scriptGate.addCharCount;
            Clone();

        }
    }
}
