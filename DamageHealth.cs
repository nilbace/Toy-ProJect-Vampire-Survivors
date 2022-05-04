using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHealth : MonoBehaviour
{
    [SerializeField] Color32 red;
    [SerializeField] Color32 original;
    [SerializeField] public int health = 50;
    [SerializeField] int Damage = 25;
    [SerializeField] bool isWeapon = false;
    
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isWeapon && health < 0)
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(!isWeapon)
        {
            int collisonDamage = other.GetComponent<DamageHealth>().GetDamage();
            RedColor();
            health -= collisonDamage;
        }
        else
            Destroy(gameObject);
    }

    void RedColor()
    {
        spriteRenderer.color = red;
        Invoke("ReturnColor", 0.2f);
    }

    void ReturnColor()
    {
        spriteRenderer.color = original;
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetDamage()
    {
        return Damage;
    }
}
