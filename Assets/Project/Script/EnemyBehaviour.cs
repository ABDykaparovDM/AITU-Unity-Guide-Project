using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    AnimatorController animatorController;
    Sight sight;
    AttackRange attackRange;
    AttackRange hitRange;

    public Player player;
    public float speed = 3;
    public float health = 45;
    Vector3 scale;
    public Vector2 direction;

    public Healthbar healthbar;
    public Vector2 healthbarOffset;
    Vector2 helathbarPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animatorController = GetComponent<AnimatorController>();
        sight = transform.GetChild(0).GetComponent<Sight>();
        attackRange = transform.GetChild(1).GetComponent<AttackRange>();
        hitRange = transform.GetChild(2).GetComponent<AttackRange>();
        scale = transform.localScale;
        healthbar = transform.GetChild(3).GetChild(0).gameObject.GetComponent<Healthbar>();
        healthbar.SetMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (sight.spoted)
        {
            if (!player)
            {
                player = sight.player;
            }
            InCombat();
            if (health <= 0)
                Death();
        }
        else
        {
            Idle();
        }

        helathbarPos = Camera.main.WorldToScreenPoint(transform.position);
        helathbarPos += healthbarOffset;
        healthbar.transform.position = helathbarPos;
    }

    void Idle()
    {
        rb.velocity = new Vector2();
        animatorController._Idle();
    }

    void InCombat()
    {
        direction = (player.transform.position - transform.position).normalized;
        if (attackRange.inRange)
        {
            animatorController._Attack();
        }
        else
        {
            speed = 3;
            animatorController._Walk();
        }
        
        rb.velocity = direction * speed;
        if (direction.x < 0)
            transform.localScale =
                new Vector3(-Mathf.Abs(scale.x), transform.localScale.y, transform.localScale.z);
        if (direction.x > 0)
            transform.localScale =
                new Vector3(Mathf.Abs(scale.x), transform.localScale.y, transform.localScale.z);
        if (!player.enabled)
            sight.spoted = false;
    }

    void Attack()
    {
        if (attackRange.inRange)
        {
            speed = 1;
            if (hitRange.inRange)
            {
                speed = 0;
                player.Hit(15);
            }
        }
    }

    void Death()
    {
        animatorController._Death();
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        rb.velocity = new Vector2();
        this.enabled = false;
    }
    public void Hit(float dmg)
    {
        health -= dmg;
        healthbar.SetHealth(health);
    }
}
