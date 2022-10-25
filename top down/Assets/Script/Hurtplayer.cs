using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtplayer : MonoBehaviour
{
    public int damageToGive;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "You")
        {
            other.gameObject.GetComponent<PlayerHealth>().hurtPlayer(damageToGive);
        }
    }
}
