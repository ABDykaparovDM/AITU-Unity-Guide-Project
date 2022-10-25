using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        _Idle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void _Idle()
    {
        animator.Play("Idle");
    }
    public void _Walk()
    {
        animator.Play("Walk");
    }
    public void _Block()
    {
        animator.Play("Block");
    }
    public void _Dodge()
    {
        animator.Play("Dodge");
    }
    public void _Attack()
    {
        animator.Play("Attack");
    }
    public void _Attack1()
    {
        animator.Play("Attack0");
    }
    public void _Attack2()
    {
        animator.Play("Attack1");
    }
    public void _Hit()
    {
        animator.Play("Hit");
    }
    public void _Death()
    {
        animator.Play("Death");
    }
}
