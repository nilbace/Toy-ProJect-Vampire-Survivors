using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeThrowing : MonoBehaviour
{
    Rigidbody2D AxeRigidbody;
    GameObject Player;//플레이어가 바라보는 방향을 참조하기 위함

    void Start()
    {
        AxeRigidbody = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        HasThrown();
    }

    void Update()
    {
        if(Time.timeScale == 0f)//일시정지상태일때 도끼의 회전을 멈춤
            return;
        else
            transform.Rotate(0, 0, 2f);
    }

    void HasThrown()
    {
        float LeftRight = Player.transform.localScale.x;//플레이어가 어느방향을 바라보는지 확인
        AxeRigidbody.velocity = new Vector2(LeftRight * 5f, 3f);
    }

   
}
