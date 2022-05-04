using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowPlayerHp : MonoBehaviour
{
    GameObject Player;
    [SerializeField] Slider Hpbar;
    [SerializeField] float down = -1f;
    int PlayerHP;
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        PlayerHP = Player.GetComponent<DamageHealth>().health;
        Hpbar.value = PlayerHP/100f;
        Hpbar.transform.position = Player.transform.position + new Vector3(0, down, 0);
    }
}
