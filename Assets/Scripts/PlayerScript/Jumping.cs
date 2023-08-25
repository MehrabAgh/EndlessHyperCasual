using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    private float timeJumper;
    public float timeLeftJump;
    public bool AvailableJump;
    public void Jump(float speed, Rigidbody rb , Animator _anim)
    {
        _anim.SetBool("isJumping", true);
        rb.AddForce(transform.up * speed);
        timeJumper = timeLeftJump;
        AvailableJump = false;
    }
    public void UpdateJump()
    {
        if (timeJumper > 0)
        {
            timeJumper -= Time.deltaTime;
        }
        else
        {
            AvailableJump = true;
        }
    }
}
