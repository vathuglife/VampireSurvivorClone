using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerBehaviour : ProjectileWeaponBehaviour
{

    HammerController kc;

    protected override void Start()
    {
        base.Start();
        kc = FindObjectOfType<HammerController>();
    }

    void Update()
    {
        transform.position += direction * kc.speed * Time.deltaTime;    //Set the movement of the Hammer
    }
}
