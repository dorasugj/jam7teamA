using UnityEngine;
using System;
using System.Collections;

public class ResultSecne : MonoBehaviour {
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private int enemyCount = 500;

    void Start () {
        int red_count = Singleton.Instance.misocount;
        int white_count = enemyCount;
        animator.SetInteger("red_miso", red_count);
        animator.SetInteger("white_miso", white_count);

        Debug.Log(red_count);
        Debug.Log(white_count);

        if (red_count >= white_count) {
            animator.SetBool("result", true);
        }
        else {
            animator.SetBool("result", false);
        }
    }

}
