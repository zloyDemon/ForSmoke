using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundInfo : MonoBehaviour
{
    private const float Distance = 5f;
    private Vector3 normal;
    
    private RaycastHit[] raycastHits = new RaycastHit[5];

    public Vector3 GroundNormal => normal;
    
    private void Update()
    {
        ThrowRaycastDown();
    }

    private void ThrowRaycastDown()
    {
        int hits = Physics.RaycastNonAlloc(transform.position, Vector3.down, raycastHits, Distance);
        normal = raycastHits[0].normal;
    }
}
