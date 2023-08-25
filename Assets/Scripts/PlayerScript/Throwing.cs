using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{ 
    public void Throw_Hold(Animator anim)
    {
        anim.SetLayerWeight(1, 1);
        anim.SetBool("_isThrowing", true);      
    }  
}
