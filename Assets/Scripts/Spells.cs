using UnityEngine;
using UnityEngine.Events;

public class Spells : MonoBehaviour
{
    private const string FIRE_BUTTON = "Fire1";
    public Transform FirePoint;
    public GameObject fireballPrefab;

    public bool CanShootFire = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CanShootFire && Input.GetButton(FIRE_BUTTON))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(fireballPrefab, FirePoint.position, FirePoint.rotation);
    }

    public void HandleUnlockFire() 
    {
        this.CanShootFire = true;
    }

}
