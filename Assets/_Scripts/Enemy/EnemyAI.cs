using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{


    public event Action Died;

    [SerializeField] private NavMeshAgent enemyAI;
    [SerializeField] private Transform target;
    [SerializeField] private float attackRange=1f;
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem firePrefab;
    [SerializeField] private Transform muzzlePoint;
    [SerializeField] private LayerMask layerMast;
     
 

    private bool isAttacking = false;
    private void Start()
    {
        if(target == null)
        {
            target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        }
    }


    private void Update()
    {
        float distance=Vector3.Distance(transform.position, target.position);
        if (distance > attackRange)
        {
            isAttacking = false;
            animator.SetBool("walk", true);
            enemyAI.isStopped = false;
            enemyAI.SetDestination(target.position);
             
            
        }
        else
        {
            if (!isAttacking)
            {
                animator.SetTrigger("attack");
                isAttacking = true;
            }
            
            animator.SetBool("walk",false); 
            enemyAI.isStopped=true;
            //Debug.Log("enemy attacking player");
            
            
        }
    }


    public void Fire()
    {
        firePrefab.Play();
        if (Physics.Raycast(muzzlePoint.position, muzzlePoint.forward,out RaycastHit hit, 10f,layerMast))
        {
            if(hit.collider != null)
            {
                //Debug.Log($"got hit {hit.collider.gameObject.name}");
            }
        }
    }

    public void StopFire()
    {
        firePrefab.Stop();  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fireBall"))
        {
            EnemyManager.Instance.SpawnEnemy();
            this.gameObject.SetActive(false);
        }
    }


}
