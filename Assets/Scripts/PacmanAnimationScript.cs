using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanAnimationScript : MonoBehaviour
{
    public Animator animatorController;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            animatorController.SetTrigger("WKeyDown");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animatorController.SetTrigger("SKeyDown");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            animatorController.SetTrigger("DKeyDown");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            animatorController.SetTrigger("AKeyDown");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animatorController.SetTrigger("isDead");
        }
    }
}
