using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{

    [SerializeField]
    private GameObject item;
    private Tweener tweener;
    private string phase = "a";
    private IEnumerator coroutine;
    public Animator animatorController;

    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
    }

    // Update is called once per frame
    void Update()
    {
        coroutine = MovePacman();
        StartCoroutine(coroutine);
    }

    private IEnumerator MovePacman()
    {
        WaitForSeconds waitTime = new WaitForSeconds(0.01f);

        if (!tweener.HasTween(item))
        {
            if (phase == "a")
            {
                animatorController.SetTrigger("DKeyDown");
                tweener.AddTween(item.transform, item.transform.position, new Vector3(5.299f, 2.388f, 0.0f), 2.5f);
                phase = "b";
            }

            else if (phase == "b")
            {
                animatorController.SetTrigger("SKeyDown");
                tweener.AddTween(item.transform, item.transform.position, new Vector3(5.299f, 1.134f, 0.0f), 2.5f);
                phase = "c";
            }

            else if (phase == "c")
            {
                animatorController.SetTrigger("AKeyDown");
                tweener.AddTween(item.transform, item.transform.position, new Vector3(3.711f, 1.134f, 0.0f), 2.5f);
                phase = "d";
            }

            else if (phase == "d")
            {
                animatorController.SetTrigger("WKeyDown");
                tweener.AddTween(item.transform, item.transform.position, new Vector3(3.711f, 2.388f, 0.0f), 2.5f);
                phase = "a";
            }
        }

        yield return waitTime;
    }
}

