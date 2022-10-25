using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Health;
    public int currentHealth;

    public float flashLength;
    private float flashCountdown;
   
    public GameManager manager;
    //make player change color when taking hit
    private Renderer rend;
    private Color storeColor;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = Health;
        //get current object color material
        rend = GetComponent<Renderer>();
        storeColor = rend.material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            manager.GameOver();
        }
        if(flashCountdown > 0)
        {
            flashCountdown-= Time.deltaTime;
            if(flashCountdown <= 0)
            {
                rend.material.SetColor("_Color", storeColor);
            }
        }
    }
    public void hurtPlayer(int damagetaken)
    {
        currentHealth -= damagetaken;
        flashCountdown = flashLength;
        //change current object color material to white material
        rend.material.SetColor("_Color", Color.blue); 
    }
}
