using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoLife : MonoBehaviour
{
    private Color _color;
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "target")
        {
            GameManagment.instance.player.playerAttack.ammoCount++;
            Camera.main.GetComponent<CameraMove>().pivot.SetParent(GameManagment.instance.player.transform);
            Camera.main.GetComponent<CameraMove>()._moveAmmo = false;
            var clone = collision.gameObject.transform.GetChild(0).transform;
            var mCollide = clone.gameObject.GetComponent<MeshRenderer>().material;
            _color = GameManagment.instance.colors[Random.Range(0, GameManagment.instance.colors.Length)];
            mCollide.color = _color;
            clone.SetParent(GameManagment.instance.destroyTargets);
            ScoreManagment.ins.AnimateText(ScoreManagment.ins.a2, ScoreManagment.ins.target);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
