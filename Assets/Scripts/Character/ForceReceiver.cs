using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceReceiver : MonoBehaviour
{

    [SerializeField] private CharacterController controller;
    [SerializeField] private float drag = 0.3f;

    private Vector3 DampingVelocity;
    private Vector3 Impact;
    private float VerticalVelocity;

    public Vector3 Movement => Impact + Vector3.up * VerticalVelocity;

    void Update()
    {
        if (VerticalVelocity < 0 && controller.isGrounded)
        {
            VerticalVelocity = Physics.gravity.y * Time.deltaTime;
            Impact = Vector3.zero; 
        }
        else
        {
            VerticalVelocity += Physics.gravity.y * Time.deltaTime;
        }

        Impact = Vector3.SmoothDamp(Impact, Vector3.zero, ref DampingVelocity, drag);
    }

    public void Reset()
    {
        Impact = Vector3.zero; 
        VerticalVelocity = 0;
    }

    public void AddForce(Vector3 force)
    {
        Impact += force;
    }

    public void Jump(float jumpforce)
    {
        VerticalVelocity += jumpforce;
    }
}
