using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void GOTO(int character)
    {
        animator.SetInteger("Goto", character);
    }

    public void StartMutation()
    {
        animator.SetTrigger("MutateStart");
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public void Die()
    {
        animator.SetTrigger("Die");
    }

    public void Hit()
    {
        animator.SetTrigger("Hit");
    }
}
