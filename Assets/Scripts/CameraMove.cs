using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform pivot;
    public bool _moveAmmo = false;
    public float speed;
    private Vector3 posShoot = new Vector3(0f, 1.23f, -6.34f);
    private Quaternion rotShoot = Quaternion.Euler(7.5f, 0f, 0f);

    private Vector3 posDef = new Vector3(0.05f, 21.76f, -29.49f);
    private Quaternion rotDef = Quaternion.Euler(12.5f, 0f, 0f);
    private void Start()
    {
        StartCoroutine(updateFrame(0.01f));
    }
    //
    //Vector3(7.49655294,0,0)
    IEnumerator updateFrame(float time)
    {       
        while (true)
        {
            yield return new WaitForSeconds(time);
            if (GameManagment.instance._isAttack)
            {
                transform.position = Vector3.Lerp(transform.position, pivot.position, Time.deltaTime * speed);
                transform.rotation = Quaternion.Slerp(transform.rotation, pivot.rotation, Time.deltaTime * speed );

                if (!_moveAmmo)
                {
                    pivot.SetParent(GameManagment.instance.player.transform);
                    pivot.localPosition = Vector3.Lerp(pivot.localPosition, posDef, Time.deltaTime * speed);
                    pivot.localRotation = Quaternion.Slerp(pivot.localRotation, rotDef, Time.deltaTime * speed);
                }
                else
                {
                    //pivot.SetParent(GameManagment.instance.lp.ThisObject);
                    //pivot.localPosition = Vector3.Lerp(pivot.localPosition, posShoot, Time.deltaTime * speed);
                    //pivot.localRotation = Quaternion.Slerp(pivot.localRotation, rotShoot, Time.deltaTime * speed);
                }
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(0,25f, -215f), Time.deltaTime * speed);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(45f,0,0), Time.deltaTime * speed);
            }
        }
    }
}
