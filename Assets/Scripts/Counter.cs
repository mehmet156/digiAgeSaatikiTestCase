using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;



public class Counter : MonoBehaviour

{
    public Transform player;
    private int CountStickmans;
    public GameObject stickMan;
    public TMP_Text countText;
    
    public static bool bossFightStart;
    [Range(0F,1F)][SerializeField] private float DistanceFactor,Radius;
    public GameObject loosePanel;
    private void Start()
    {
        player = transform;

        CountStickmans = transform.childCount ;

        countText.text = player.childCount.ToString();
        loosePanel.SetActive(false);
        

    }

    private void Update()
    {
        Debug.Log(BossAnim.healthF);
       if(player.childCount<=0)
        {

            MoveControl.movementSpeed = 0;
            loosePanel.SetActive(true);
        }
       if(BossAnim.healthF<=0)
        {
            //winPanel.SetActive(true);
        }
        countText.text = player.childCount.ToString();
    }
    private void LateUpdate()
    {
        FormatStickMan();
    }



    // Çöp Adamlarý oluþþturmak için fonksiyon
    private void MakeStickMan(int number)
    {
       
        for (int i = 0; i < number; i++)
        {
            Instantiate(stickMan, transform.position, stickMan.transform.rotation, transform);
           
        }

        Debug.Log("child count"+transform.childCount);
        countText.text = player.childCount.ToString();
        
      
    }

    //Çöp adamlarý yerleþtirmek için fonksiyon
    private void FormatStickMan()
    {
        for (int i = 0; i < player.childCount-1; i++)
        {
            
            var x = DistanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * Radius);
            var z = DistanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * Radius);

            var NewPos = new Vector3(x, 0, z);
            if(player.transform.GetChild(i) != null)
            {
                player.transform.GetChild(i).DOLocalMove(NewPos, 1.5f).SetEase(Ease.OutBack);
            }
            
        }   
    }

  


    private void OnTriggerEnter(Collider other)
    {
       

        if (other.tag=="Count")
        {
                      
            AddGate scriptGate = other.gameObject.GetComponent<AddGate>();
            MakeStickMan(scriptGate.addCharCount);
            Debug.Log("gate count"+scriptGate.addCharCount);           
        }

        if (other.tag == "Boss")
        {
            StartCoroutine(DeadRoutine());
          
        }
       
    }

    
   public  IEnumerator DeadRoutine()
    {
        
        for(int i=player.childCount;i>=player.childCount;i--)
        {
            if (player.childCount>0&&BossAnim.healthF>0)
            {
                Destroy(transform.GetChild(0).gameObject);
                yield return new WaitForSeconds(0.5f);
            }
            
        }
        


       

    }
  
}
