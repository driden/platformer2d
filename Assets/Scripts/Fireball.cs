using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float Speed = 200f;
    public Rigidbody2D rb;
    public int Damage = 1;

    public float lifeTime = 6f;

    void Start()
    {
        rb.velocity = transform.right * Speed;
    }

    void Update() {
        this.lifeTime -= Time.deltaTime;
        if (this.lifeTime <= 0){
            Destroy(this.gameObject);
        } 
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name.Equals("Player")) return;

        var enemy = collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(Damage);
        }
        
        Destroy(this.gameObject);
    }
}
