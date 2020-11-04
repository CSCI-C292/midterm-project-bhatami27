﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfHitScript : MonoBehaviour
{
    Renderer rend;
    Color c;
    public PlayerControl playerControl;

    

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer> ();
        c = rend.material.color;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name.Equals("Enemy") && playerControl.playerHealth >0){
            StartCoroutine("GetInvulnerable");
            
        }
    }

    IEnumerator GetInvulnerable(){
        Physics2D.IgnoreLayerCollision(8,9,true);
        c.a =1f;
        rend.material.color = c;
        yield return new WaitForSeconds(3f);
        Physics2D.IgnoreLayerCollision(8,9,false);
        c.a=1f;
        rend.material.color=c;
    }
}