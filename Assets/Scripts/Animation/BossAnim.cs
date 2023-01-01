using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossAnim : MonoBehaviour
{
    public Animator bossAnimator;
    bool endGame;
    public Image health;
    public static float healthF;
    public GameObject winPanel;
    bool endOk=false;
    public string sceneName;
    void Start()
    {
        //  bossAnimator.Play("Boss");
        endGame = false;
        healthF = 1;
        winPanel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        health.fillAmount = healthF;
        if(healthF<=0&&endOk==false)
        {
            endOk = true;
           bossAnimator.Play("die");
            StartCoroutine("waitEnd");
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag=="Player")
        {
            
           // bossAnimator.SetBool("bossOk", true);
            bossAnimator.Play("Boss");
            StartCoroutine(HealthRoutine());
        }
    }

    IEnumerator HealthRoutine()
    {
        for(float i=1;i>=0;i-=0.1f)
        {
            healthF -= 0.1f;
            yield return new WaitForSeconds(1);
        }
        if(healthF<=0)
        {
            
         //   bossAnimator.Play("die");
            //yield return new WaitForSeconds(2.5f);
            
        }
        yield return new WaitForSeconds(2.5f);
        
    }
    IEnumerator waitEnd()
    {

        yield return new WaitForSeconds(2.5f);
        winPanel.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(sceneName);
    }
}
