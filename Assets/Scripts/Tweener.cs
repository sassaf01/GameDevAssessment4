using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tweener : MonoBehaviour
{
    private Tween activeTween;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        {
            if (activeTween != null)
            {
                if (Vector3.Distance(activeTween.Target.position, activeTween.EndPos) > 0.001f)
                {
                    var timePassed = Time.time - activeTween.StartTime;
                    //float timeAv = (float)Math.Pow(timePassed / activeTween.Duration, 3);
                    activeTween.Target.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, timePassed / activeTween.Duration);
                }
                else
                {
                    activeTween.Target.position = activeTween.EndPos;
                    activeTween = null;
                }
            }
        }   
    }

    public void AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {

        if (activeTween == null)
        {
            activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration);
        }

    }

    public bool HasTween(GameObject target)
    {
        if (activeTween == null)
        {
            return false;
        }
        return true;
    }

    public void SetToNull()
    {
        activeTween = null;
    }
}
