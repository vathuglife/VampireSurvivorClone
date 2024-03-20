using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicBehaviour : MeleeWeaponBehaviour
{
    List<GameObject> markedEnemies;

    protected override void Start()
    {
        base.Start();
        markedEnemies = new List<GameObject>();
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") && !markedEnemies.Contains(col.gameObject))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(GetCurrentDamage(), transform.position);

            markedEnemies.Add(col.gameObject);  //Mark the enemy
        }
        else if (col.CompareTag("Prop") && !markedEnemies.Contains(col.gameObject))
        {
            if (col.gameObject.TryGetComponent(out BreakableProps breakable))
            {
                breakable.TakeDamge(GetCurrentDamage());

                markedEnemies.Add(col.gameObject);
            }
        }
    }
}
