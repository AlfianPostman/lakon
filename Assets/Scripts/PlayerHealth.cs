using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHP = 10f;
    public float currentHP;
    Animator anim;

    // public Image hp;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        currentHP = MaxHP;
    }

    void Update()
    {
        // hp.fillAmount = 1f - (currentHP / MaxHP);
    }

    public float TakeDamage(float damage)
    {
        currentHP -= damage;

        Debug.Log("Player Health: " + currentHP);
        return currentHP;
    }
}
