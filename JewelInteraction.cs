using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelInteraction : MonoBehaviour
{
    GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) //플레이어가 보석을 먹으면은 경험치 증가
    {
        if(other.tag == "Player")
        {
            gameManager.expPoint += 10f;
            Destroy(gameObject);
        }
    }
}
