using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHP = 10f;
    public float currentHP;
    Animator anim;

    public GameObject DeathMenu;
    PlayerController pc;
    public Image hp;

    public ParticleSystem hit;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        pc = GetComponent<PlayerController>();
        currentHP = MaxHP;
    }

    void Update()
    {
        hp.fillAmount = 1f - (currentHP / MaxHP);

        if(currentHP <= 0) {
            pc.StartCoroutine("Dead");
            DeathMenu.SetActive(true);
        }
    }

    public float TakeDamage(float damage)
    {
        hit.Play();
        currentHP -= damage;

        Debug.Log("Player Health: " + currentHP);
        return currentHP;
    }
}
