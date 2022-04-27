using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float Speed = 20f;
    public Rigidbody2D rb;

    public int Damage = 20;

    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * Speed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        var enemy = collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(Damage);
        }
        Debug.Log(collider.name);
    }
}