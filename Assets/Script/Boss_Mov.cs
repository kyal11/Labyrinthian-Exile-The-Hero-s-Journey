using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Mov : MonoBehaviour
{
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    public int damage;
    public Collider2D hitboxCollider;

    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;
    private bool playerblock;

    public Image fillBar;
    public float healt;


    public void LoseHealth(int damage)
    {
        // Kurangin Darah
        healt -= damage;

        anim.SetTrigger("Hit");
        anim.SetBool("Death", false);

        //resfresh UI healt bar
        fillBar.fillAmount = healt / 100;

        if (healt <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        anim.SetBool("Death", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        // Hilangkan objek setelah beberapa waktu
        Destroy(gameObject,1f);
    }
    void Awake()
    {
        intTimer = timer;
        anim = GetComponent<Animator>();

        // Mengambil komponen Rigidbody2D pada monster
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = true; // Mengatur isKinematic menjadi true
        }
    }


    void Update()
    {
        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength, raycastMask);
            RaycastDebugger();
        }

        if (hit.collider != null)
        {
            EnemyLogic();
        }
        else if (hit.collider == null)
        {
            inRange = false;
        }

        if (inRange == false)
        {
            anim.SetBool("Run", false);
            StopAttack();
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            target = trig.gameObject;
            inRange = true;
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false && !attackMode)
        {
            Attack();
        }

        if (cooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);
        }
    }

    void Move()
    {
        anim.SetBool("Run", true);

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }



    void Attack()
    {
        timer = intTimer;
        attackMode = true;

        anim.SetBool("Run", false);
        anim.SetBool("Attack", true);

    }
    void hitBoxActive()
    {
        playerblock = FindObjectOfType<CombatSystem>().isBlock();
        Debug.Log("Hit Player");
        hitboxCollider.enabled = true;
        if (hitboxCollider)
        {
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(rayCast.position, distance, raycastMask);
            foreach (Collider2D player in hitPlayer)
            {

                if (playerblock == false)
                {
                    player.GetComponent<HealtBar>().LoseHealth(damage);
                    Debug.Log("Hit Player");
                }
                else
                {
                    Debug.Log("PlayerBlock");
                }
            }
        }

    }
    void Cooldown()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
        // Nonaktifkan hitbox saat serangan selesai
        hitboxCollider.enabled = false;
    }

    void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.red);
        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
        }
    }

    public void TriggerCooling()
    {
        cooling = true;
    }

}
