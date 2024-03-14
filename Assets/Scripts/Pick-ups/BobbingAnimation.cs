using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbingAnimation : MonoBehaviour
{
    public float frequency;
    public float magnitude;
    public Vector3 direction;
    Pickup pickup;
    

    private Vector3 initialPosition;
    // Start is called before the first frame update
     void Start()
     {
         pickup = GetComponent<Pickup>();
        initialPosition = transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        if (pickup && !pickup.hasBeenCollected)
        {
            transform.position = initialPosition + direction * Mathf.Sin(Time.time * frequency) * magnitude;
        }
    }
}
