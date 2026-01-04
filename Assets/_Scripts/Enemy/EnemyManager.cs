using System;
using NUnit.Framework;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public static EnemyManager Instance;    


    private int enemyLeft = 2;
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject broomstick;
    [SerializeField] private Light pointLight;
    [SerializeField] private Animator doorAnimator;



    private void Awake()
    {
        Instance = this;
    }


    public void SpawnEnemy()
    {
        if (enemyLeft > 0)
        {
            var ind =UnityEngine.Random.Range(0, spawnPositions.Length);
            Instantiate(enemyPrefab, spawnPositions[ind].position, Quaternion.identity);
            enemyLeft--;
        }
        else
        {
            pointLight.enabled = true;
            broomstick.SetActive(true);
            doorAnimator.SetTrigger("Open");
        }
        
    }

}
