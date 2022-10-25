using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public InputSystem input;
    AnimatorController animatorController;

    Vector3 scale;

    public float speed;
    public float health = 100;

    public Healthbar healthbar;

    public GameObject currentDoor;
    public bool isAttacking;

    AttackRange attackRange;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animatorController = GetComponent<AnimatorController>();
        scale = transform.localScale;

        healthbar.SetMaxHealth(health);
        attackRange = transform.GetChild(0).gameObject.GetComponent<AttackRange>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking)
            Attack();
        else
            Movement();

        if (health <= 0)
            Death();
    }

    void Movement()
    {
        rb.velocity = input.direction * speed;
        if (rb.velocity != new Vector2())
        {

            animatorController._Walk();
            if (input.direction.x < 0)
                transform.localScale = 
                    new Vector3(-scale.x, transform.localScale.y, transform.localScale.z);
            if (input.direction.x > 0)
                transform.localScale = 
                    new Vector3(scale.x, transform.localScale.y, transform.localScale.z);
        }
        else
            Idle();
    }
    void Idle()
    {
        animatorController._Idle();
    }
    void Death()
    {
        rb.velocity = new Vector2();
        animatorController._Death();
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
    public void Hit(float dmg)
    {
        health -= dmg;
        healthbar.SetHealth(health);
    }

    public void Heal(float hp)
    {
        health += hp;
        healthbar.SetHealth(health);
    }

    public void Attack()
    {
        rb.velocity = new Vector2();
        isAttacking = true;
        
        animatorController._Attack();
    }
    void AttackPerformance()
    {
        if (attackRange.inRange)
            attackRange.target.GetComponent<EnemyBehaviour>().Hit(15);
    }
    public void AttackEnd()
    {
        isAttacking = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
            currentDoor = collision.gameObject;
    }
}
