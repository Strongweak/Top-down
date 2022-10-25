using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private Rigidbody enemyrb;
    public float moveSpeed;

    public PlayerControl thePlayer;

    private Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        enemyrb = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerControl>();

    }
    void FixedUpdate()
    {
        enemyrb.velocity = (transform.forward * moveSpeed);
    }
    // Update is called once per frame
    void Update()
    {
        //face to player position (but not using y axis)
        transform.LookAt(new Vector3(thePlayer.transform.position.x, transform.position.y, thePlayer.transform.position.z));

        if(thePlayer.transform.position == null)
        {
            anim.Play("Dance");
        }

        //face to player position (all axis)
        //transform.LookAt(thePlayer.transform.position);
    }
}
