using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadShotControl : MonoBehaviour
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
        Quaternion rotate = firePoint.rotation;
        rotate.y = firePoint.position.y + 15;
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
                BullletControl newBullet2 = Instantiate(bullet, firePoint.position, rotate) as BullletControl;
                newBullet.speed = bulletSpeed;
                newBullet2.speed = bulletSpeed;
            }
        }
        else
        {
            shotCounter = 0;
        }
    }
}

