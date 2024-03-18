using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    EnemyStats enemy;
    Transform player;

    Vector2 knockbackVelocity;
    float knockBackDuration;


    void Start()
    {
        enemy = GetComponent<EnemyStats>();
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update()
    {
        if ( knockBackDuration > 0)
        {
            transform.position += (Vector3)knockbackVelocity * Time.deltaTime;
            knockBackDuration -= Time.deltaTime;
        }
        else
        {
            //Constantly move the enemy towards the player
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemy.currentMoveSpeed * Time.deltaTime);    
        }
    }

    public void Knockback(Vector2 velocity, float duration)
    {
        if(knockBackDuration > 0) return;

        knockbackVelocity = velocity;
        knockBackDuration = duration;
    }
}
