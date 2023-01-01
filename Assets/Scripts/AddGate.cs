using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddGate : MonoBehaviour
{
    public int addCharCount;
    public TMP_Text addCharCountText;
    void Start()
    {
        addCharCountText.text ="+"+ addCharCount.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
}
