using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float MaxHP = 10f;
    public float currentHP;
    bool attackButton;
    Animator anim;
    Unit unit;

    public Image hp;
    public ParticleSystem hit;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        unit = GetComponentInParent<Unit>();
        currentHP = MaxHP;
    }

    void Update()
    {
        hp.fillAmount = 1f - (currentHP / MaxHP);
    }

    public float TakeDamage(float damage)
    {
        unit.Hurt();
        hit.Play();
        currentHP -= damage;

        return currentHP;
    }
}
