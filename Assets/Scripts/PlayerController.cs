using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Throwing))]
[RequireComponent(typeof(Jumping))]
[RequireComponent(typeof(PlayerAttack))]
public class PlayerController : MonoBehaviour
{
    public float PowerJump;
    public Animator _anim;
    private Rigidbody _rb;
    public Transform HandPivot;

    private Throwing throwing;
    private Jumping jumping;
    public PlayerAttack playerAttack;

    private Vector2 touchPos;
    private bool _touchdown;
    private int dist = 20;
    
    private void Awake()
    {       
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        throwing = GetComponent<Throwing>();
        jumping = GetComponent<Jumping>();
        playerAttack = GetComponent<PlayerAttack>();        
    }

    #region byTouch
    //if (!_touchdown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
    //{
    //    touchPos = Input.touches[0].position;
    //    _touchdown = true;
    //}
    //if (_touchdown)
    //{
    //    if (Input.touches[0].position.y >= touchPos.y + dist)
    //    {
    //        _touchdown = false;
    //        print("Up");
    //    }
    //    if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
    //    {
    //        _touchdown = false;
    //    }
    //}

    #endregion
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "killzone")
        {
            //GameManagment.instance._EndGame = true;
            Application.LoadLevel("SampleScene");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _anim.SetBool("isJumping", false);
        if (collision.gameObject.tag == "Ground")
        {
            GameManagment.instance.GroundCurrent = collision.gameObject.transform;
            var parent = collision.gameObject.GetComponentInParent<SpawnRandomTarget>();
            if (parent.SpawnedTarget != null && parent.SpawnedTarget.Count > 0 )
            {
                GameManagment.instance._isAttack = true;
                GameManagment.instance.player.playerAttack.CreateAmmo();
            }
        }
    }

    private void Update()
    {
        if (!_touchdown && Input.GetMouseButtonDown(0))
        {
            touchPos = Input.mousePosition;
            _touchdown = true;
        }
        if (_touchdown)
        {
            if (Input.mousePosition.y >= touchPos.y + dist)
            {
                if (jumping.AvailableJump)
                {
                    if (!GameManagment.instance._isAttack)
                    {
                        jumping.Jump(PowerJump, _rb , _anim);
                    }
                    else
                    {
                        throwing.Throw_Hold(_anim);                      
                    }
                }                   
            }
            if (Input.GetMouseButtonUp(0))
            {
                _touchdown = false;
            }
        }
        jumping.UpdateJump();
    }

}
