using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedHammer = Instantiate(prefab);
        spawnedHammer.transform.position = transform.position; //Assign the position to be the same as this object which is parented to the player
        spawnedHammer.GetComponent<HammerBehaviour>().DirectionChecker(pm.lastMovedVector);   //Reference and set the direction
    }
}
