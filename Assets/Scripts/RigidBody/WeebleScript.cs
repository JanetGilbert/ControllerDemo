using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Move the center of gravity down to make a weeble.
public class WeebleScript : MonoBehaviour
{
    [SerializeField] private Vector3 centerOfMass;

    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;
    }

   
    void Update()
    {
        
    }
}
