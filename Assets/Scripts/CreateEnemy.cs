using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreateEnemy : MonoBehaviour
{
    public Transform player;
    public GameObject stickMan;
    public Transform enemyBase;
    [Range(0F, 1F)][SerializeField] private float DistanceFactor, Radius;
    public int EnemyNumber;
    public static Transform tempPlayer;
    public static bool playerIn;
    public TMP_Text enemyCount;

    void Start()
    {
      // enemy = transform;
        MakeStickMan(EnemyNumber);
    }

    // Update is called once per frame
    void Update()
    {
        // if (playerIn)
        // {
        //   transform.position = Vector3.MoveTowards(transform.position, (tempPlayer.position), 3f * Time.deltaTime);
        //}
        enemyCount.text = player.childCount.ToString();
    }

    private void LateUpdate()
    {
        FormatStickMan();
    }

    private void MakeStickMan(int number)
    {
        for (int i = 0; i < number; i++)
        {
            //  Quaternion quaternion = new Quaternion(0, 180, 0, 0);
            Instantiate(stickMan, transform.position, stickMan.transform.rotation, transform);
        }

       // FormatStickMan();

        Debug.Log(transform.childCount);

    }

    private void FormatStickMan()
    {
        
        /*
        for (int i = 0; i < enemy.childCount; i++)
        {
            
            var x = DistanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * Radius);
            var z = DistanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * Radius);

            var NewPos = new Vector3(x, 0, z);
            if (enemy.transform.GetChild(i) != null)
            {
                enemy.transform.GetChild(i).localScale = new Vector3(0.25f, 100, 0.25f);
                enemy.transform.GetChild(i).tag = "Enemy";
                enemy.transform.GetChild(i).DOLocalMove(NewPos, 1.5f).SetEase(Ease.OutBack);
               
            }
            */


            for (int i = 0; i < player.childCount - 1; i++)
            {

                var x = DistanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * Radius);
                var z = DistanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * Radius);

                var NewPos = new Vector3(x, 0, z);
                if (player.transform.GetChild(i) != null)
                {
                    player.transform.GetChild(i).DOLocalMove(NewPos, 1.5f).SetEase(Ease.OutBack);
                }

            }
        
    }


    private void OnTriggerEnter(Collider other)
    {
      
    }
}
