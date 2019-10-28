using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageBehindScript : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        anim.SetBool("Stop", false);
    }

    public void StopAnimation()
    {
        anim.SetBool("Stop", true);
    }

    void Update()
    {
        
    }
}
