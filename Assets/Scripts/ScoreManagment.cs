using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagment : MonoBehaviour
{
    public static ScoreManagment ins;
    public static int Score;
    public int _score;
    public Transform a2, target , res ;
    private bool pluser;
    private void Awake()
    {
        ins = this;
    }
    private void Update()
    {
        a2.GetComponent<Text>().text = Score.ToString();
        if (res != null)
        {
            res.GetComponent<Text>().text = _score.ToString();
            res.position = Vector2.Lerp(res.position, target.position, Time.deltaTime * 6);
            float des = Vector2.Distance(res.position, target.position);
            if(des <= 1f)
            {
                if (pluser)
                {
                    Score += _score;
                    pluser = false;
                }
                Destroy(res.gameObject);
            }
        }

    }
    public void AnimateText(Transform textScore , Transform target)
    {
       res = Instantiate(textScore, Vector2.zero, Quaternion.identity , transform);
        pluser = true;
    }
} 
