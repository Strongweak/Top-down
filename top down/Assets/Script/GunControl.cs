using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    public bool isFiring;

    public BullletControl bullet;
    public float bulletSpeed;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFiring)
        {
            if (shotCounter > 0)
            {
                shotCounter = -Time.deltaTime;
            }
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots * Time.deltaTime;
                BullletControl newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BullletControl;
                newBullet.speed = bulletSpeed;
            }
        }
        else
        {
            shotCounter = 0;
        }
    }
}
