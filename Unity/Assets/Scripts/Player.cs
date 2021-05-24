using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private Rigidbody _rigibody;

    private void Awake()
    {
        _rigibody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float direction = Input.GetAxis("Vertical");

        _rigibody.velocity += Vector3.forward * direction;
    }
}
