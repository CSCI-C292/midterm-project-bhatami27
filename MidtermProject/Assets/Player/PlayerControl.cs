﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
   

    public float moveSpeed = 3f;
    float velX;
    float velY;
    bool facingRight = true;
    Rigidbody2D rigBody;
    public float JumpForce = 1;
    public GameObject bulletToRight, bulletToLeft, gameOverText, restartButton, s1, s2, s3, hPU, bulletToRight2, bulletToLeft2, fbPU, gameWonText, restartButtonWon;
    public static int playerHealth = 3;
    //int playerLayer, enemyLayer;
    Color color;
    Renderer rend;



    Vector2 bulletPos;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;

    public float DashForce;
    public float StartDashTime;
    float CurrentDashTimer;
    float DashDirection;

    bool isDashing;
    bool oneLife = false;
    



    // Start is called before the first frame update
    void Start()
    {
        
        s1 = GameObject.Find("s1");
        s2 = GameObject.Find("s2");
        s3 = GameObject.Find("s3");
        s1.gameObject.SetActive(true);
        s2.gameObject.SetActive(true);
        s3.gameObject.SetActive(true);

        hPU = GameObject.Find("HealthPowerUp");
        hPU.gameObject.SetActive(false);

        fbPU= GameObject.Find("FBPowerUp");
        fbPU.gameObject.SetActive(false);

        

        gameOverText.SetActive(false);
        restartButton.SetActive(false);

        gameWonText.SetActive(false);
        restartButtonWon.SetActive(false);
        
        rigBody = GetComponent<Rigidbody2D>();

        



    }

    // Update is called once per frame
    void Update()
    {
        velX = Input.GetAxisRaw("Horizontal");
        velY = rigBody.velocity.y;
        rigBody.velocity = new Vector2(velX * moveSpeed, velY);

        if(Input.GetKeyUp (KeyCode.UpArrow) && Mathf.Abs(rigBody.velocity.y)<0.001f)
        {
            rigBody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        
        if(Input.GetKeyUp (KeyCode.Space) && Time.time>nextFire)
        {
           nextFire = Time.time + fireRate;
           fire();
        }

        if(Input.GetKeyUp (KeyCode.Z)){
            isDashing = true;
            CurrentDashTimer = StartDashTime;
            rigBody.velocity = Vector2.zero;
            DashDirection = (int)velX;
        }

        if(isDashing){
            rigBody.velocity = -transform.right * DashDirection*DashForce;
            CurrentDashTimer -= Time.deltaTime;
            if(CurrentDashTimer <=0){
                isDashing = false;
            }

        }

        if(BossScript.bossHealth == 0){
            gameWonText.SetActive(true);
            restartButtonWon.SetActive(true);
        }

        

    }

    void LateUpdate() 
    {
        Vector3 localScale = transform.localScale;
        if(velX > 0){
            facingRight = true;
        }else if(velX<0){
            facingRight = false;
        }
        if(((facingRight)&& (localScale.x<0))||((!facingRight)&&(localScale.x>0))){
            localScale.x*=-1;
        }
        transform.localScale = localScale;
    }

     void fire()
    {
        bulletPos=transform.position;
        if(facingRight)
        {
            bulletPos+= new Vector2 (+1.5f,-0.3f);
            Instantiate(bulletToRight, bulletPos, Quaternion.identity);
        }else{
            bulletPos+= new Vector2 (-1.5f,-0.3f);
            Instantiate(bulletToLeft, bulletPos, Quaternion.identity);
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag.Equals("Enemy") || col.gameObject.tag.Equals("Boss") || col.gameObject.tag.Equals("BossFB")){
            

            playerHealth -= 1;
            switch(playerHealth){
                case 2:
                    s1.gameObject.SetActive(false);
                    break;

                case 1:
                    s2.gameObject.SetActive(false);
                    oneLife = true;
                    break;

                case 0:
                    s3.gameObject.SetActive(false);
                    break;
            }

            if(playerHealth < 1){
                gameOverText.SetActive(true);
                restartButton.SetActive(true);
                gameObject.SetActive(false); 
            }

         }

         
         if(col.gameObject.tag.Equals("HPowerUp")){
             playerHealth+=1;
             if(oneLife == true){
                 s2.gameObject.SetActive(true);
             }
             else{s1.gameObject.SetActive(true);}
             Destroy(col.gameObject);
         }


         if(ScoreScript.scoreValue == 12){
            
            hPU.gameObject.SetActive(true);
         }

         if(col.gameObject.tag.Equals("FBPowerUp")){
             Destroy(col.gameObject);
             bulletToLeft = bulletToLeft2;
             bulletToRight = bulletToRight2;
         }

         if(ScoreScript.scoreValue == 30){
            
            fbPU.gameObject.SetActive(true);
         }
         
    }

}
