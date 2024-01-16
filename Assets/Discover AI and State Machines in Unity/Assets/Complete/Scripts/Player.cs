using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Health health;
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        health = GetComponent<Health>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        health.SetHealth(20);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Hurt(2, 2);
        }
    }

    public void Hurt(int amount, int delay = 0)
    {
        StartCoroutine(health.TakeDamageDelayed(amount, delay));
    }
}
