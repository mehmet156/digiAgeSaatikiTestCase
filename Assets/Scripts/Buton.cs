using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buton : MonoBehaviour
{
    public string sceneName; 
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(Restart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart()
    {
        Debug.Log("on click");
        SceneManager.LoadScene(sceneName);
    }
}
