//플레이어, 무기, 적 모두에게 붙어있는 스크립트

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHealth : MonoBehaviour
{
    [SerializeField] Color32 red;  //빨간색
    [SerializeField] Color32 original;  //원래 색
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
        if(!isWeapon)  //피격당할시(무기가 아니라면)
        {
            int collisonDamage = other.GetComponent<DamageHealth>().GetDamage();
            RedColor();
            health -= collisonDamage; 
        }
        else   //무기는 적과 닿을시 사라짐
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
