using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
