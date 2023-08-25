using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform Ammo , pivot;
    public List<Transform> SpawnedAmmo;
    public int ammoCount;
    public Transform DefaultTransform;
    public Vector3 defPosition;
    public void Attacking(Transform target , Animator _anim)
    {
        _anim.SetFloat("Xmove", 0);
        RotationTarget(target);        
    }
    public void CheckRemove()
    {
        SpawnedAmmo.RemoveAll(item => item == null);
    }
    public void CreateAmmo()
    {
        var maxAmmo = GameManagment.instance.GroundCurrent.GetComponentInParent<SpawnRandomTarget>().SpawnedTarget.Count;
        for (int i = 0; i < maxAmmo; i++)
        {
            var p = Instantiate(Ammo , pivot.position , pivot.rotation);
            SpawnedAmmo.Add(p);
        }
    }
    public void RotationTarget(Transform target)
    {
        Vector3 lookAtPosition = target.position;
        lookAtPosition.y = transform.position.y;
        transform.LookAt(lookAtPosition);
    }       
    public void DefaultRotation(Animator _anim)
    {
        _anim.SetFloat("Xmove", 1);
        DefaultTransform.position = defPosition;
        DefaultTransform.rotation = Quaternion.identity;
        RotationTarget(DefaultTransform);
    }
}
