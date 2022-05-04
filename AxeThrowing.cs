using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeThrowing : MonoBehaviour
{
    Rigidbody2D AxeRigidbody;
    GameObject Player;

    void Start()
    {
        AxeRigidbody = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        HasThrown();
    }

    void Update()
    {
        if(Time.timeScale == 0f)
            return;
        else
            transform.Rotate(0, 0, 2f);
    }

    void HasThrown()
    {
        float LeftRight = Player.transform.localScale.x;
        AxeRigidbody.velocity = new Vector2(LeftRight * 5f, 3f);
    }

   
}
