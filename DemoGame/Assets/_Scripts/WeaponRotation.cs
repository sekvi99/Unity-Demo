using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 500f;
    
    [SerializeField] private Rigidbody2D rb2d;

    // Update is called once per frame
    void Update()
    {
        rb2d.MoveRotation(rb2d.rotation + rotationSpeed * Time.fixedDeltaTime);
    }
}
