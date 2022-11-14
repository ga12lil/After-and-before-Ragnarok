using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SetRunAnim()
    {
        anim.SetBool("IsRun", true);
    }
    public void SetStayAnim()
    {
        anim.SetBool("IsRun", false);
    }
}
