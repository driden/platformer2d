using UnityEngine;
using UnityEngine.Events;

public class Spells : MonoBehaviour
{
    private const string FIRE_BUTTON = "Fire1";
    public Transform FirePoint;
    public GameObject fireballPrefab;
    public SFXManager sfx;

    public bool CanShootFire = false;

    public float maxCooldown = 2.1f;
    public float cooldown = -1;
    
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CanShootFire && Input.GetButton(FIRE_BUTTON))
        {
            TryShoot();
        }
    }

    void Update()
    {
	this.cooldown -= Time.deltaTime;
    }


    void TryShoot() 
    {
        if (this.cooldown <= 0) Shoot();	
    }


    void Shoot()
    {
        Instantiate(fireballPrefab, FirePoint.position, FirePoint.rotation);
        this.cooldown = this.maxCooldown;
        this.sfx.playFireBall();
	
    }

    public void HandleUnlockFire() 
    {
        this.CanShootFire = true;
        sfx.playUnlock();
    }

}
