using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CombatSystem : MonoBehaviour
{
    [SerializeField] public Animator animator;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    public int attack1;
    public int attack2;
    public int attack3;

    private bool isBlocking = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (isBlocking)
        {
            if (Input.GetKeyUp(KeyCode.B))
            {
                StopBlock();
            }
            return; // Kembalikan agar tidak menjalankan gerakan selain blok
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack1();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            Attack2();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            Attack3();
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            StartBlock();
        }
        else if (Input.GetKeyUp(KeyCode.B))
        {
            StopBlock();
        }
    }

    private void Attack1()
    {
        // Memainkan animasi serangan 1
        animator.SetTrigger("Attack1");

        // Deteksi jangkauan serangan ke enemy
        Collider2D[] hitEnemies= Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            if (!enemy.isTrigger && enemy.CompareTag("Boss"))
            {
                enemy.GetComponent<Boss_Mov>().LoseHealth(attack1);
                Debug.Log("Hit Boss");
                // Lakukan tindakan pada Boss yang terkena serangan
            }
            else if (!enemy.isTrigger)
            {
               enemy.GetComponent<MonsterMov>().LoseHealth(attack1);
                Debug.Log("Hit");
                // Lakukan tindakan pada enemy yang terkena serangan
            }
        }
    }

    private void Attack2()
    {
        // Memainkan animasi serangan 2
        animator.SetTrigger("Attack2");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (!enemy.isTrigger && enemy.CompareTag("Boss"))
            {
                enemy.GetComponent<Boss_Mov>().LoseHealth(attack1);
                Debug.Log("Hit Boss");
                // Lakukan tindakan pada Boss yang terkena serangan
            }
            else if (!enemy.isTrigger)
            {
                enemy.GetComponent<MonsterMov>().LoseHealth(attack1);
                Debug.Log("Hit");
                // Lakukan tindakan pada enemy yang terkena serangan
            }
        }
    }

    private void Attack3()
    {
        // Memainkan animasi serangan 3
        animator.SetTrigger("Attack3");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {

            if(!enemy.isTrigger && enemy.CompareTag("Boss"))
            {
                enemy.GetComponent<Boss_Mov>().LoseHealth(attack1);
                Debug.Log("Hit Boss");
                // Lakukan tindakan pada Boss yang terkena serangan
            }
            else if (!enemy.isTrigger)
            {
                enemy.GetComponent<MonsterMov>().LoseHealth(attack1);
                Debug.Log("Hit");
                // Lakukan tindakan pada enemy yang terkena serangan
            }
        }
    }

    private void StartBlock()
    {
        isBlocking = true;
        animator.SetBool("IsBlocking", true);
    }

    private void StopBlock()
    {
        isBlocking = false;
        animator.SetBool("IsBlocking", false);
    }
}
