using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour
{
    Animator anim;
    public int index;


    void Start()
    {
        anim = GetComponent<Animator>();

        int n = Random.Range(0, index);
        anim.SetInteger("anim", n);
    }



}
