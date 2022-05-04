//창의 움직임을 나타냄 Vector값이 1,0 -1,0이런게 아닌 이유는 스프라이트 자체가 45도로 기울어져있어서 그럼

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    Rigidbody2D spearbody;
    GameObject Player;
    [SerializeField] float SpearSpeed = 8f;
    void Start()
    {
        spearbody = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        spearbody.velocity = new Vector2(Player.transform.localScale.x * SpearSpeed, 0);
        if(Player.transform.localScale.x == -1)
        {
            transform.localScale = new Vector2(-2, -2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
