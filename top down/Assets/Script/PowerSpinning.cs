using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpinning : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 1, 0);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "You")
        {
            Destroy(gameObject);
        }
    }
}
