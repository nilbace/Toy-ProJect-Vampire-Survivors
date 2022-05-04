using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    Rigidbody2D enemyRigidbody2d;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float magnitude = 0.3f;
    [SerializeField] float waittime = 0.2f;
    [Header("Jewel")]
    [SerializeField] GameObject jewel;
    GameObject Player;
    bool once = true;

    DamageHealth damageHealth;
    void Start()
    {
        enemyRigidbody2d = GetComponent<Rigidbody2D>();
        damageHealth = GetComponent<DamageHealth>();
        Player = GameObject.Find("Player");
        StartCoroutine(ShiverMove());
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        int health = damageHealth.GetHealth();

        if(health <= 0 && once)
        {
            Instantiate(jewel, transform.position, Quaternion.identity);
            once = false;
        }
    }

    void FollowPlayer()
    {
        float delta = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, delta);
        if(Player.transform.position.x >= transform.position.x)
            transform.localScale = new Vector2 (-1, 1);
        else
            transform.localScale = new Vector2(1, 1);
    }

    IEnumerator ShiverMove()
    {
        while(true)
        {
            transform.position += (Vector3)Random.insideUnitCircle * magnitude;
            yield return new WaitForSeconds(waittime);
        }
    }

}
