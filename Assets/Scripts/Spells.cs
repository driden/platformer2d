using UnityEngine;

public class Spells : MonoBehaviour
{
    private const string FIRE_BUTTON = "Fire1";
    public Transform FirePoint;
    public GameObject fireballPrefab;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton(FIRE_BUTTON))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(fireballPrefab, FirePoint.position, FirePoint.rotation);
    }


}
