using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EFFV2 : MonoBehaviour
{
    public AudioSource deathSound;
   public float moveSpeed = 3f;
    Transform leftWayPoint, rightWayPoint;
    Vector3 localScale;
    bool movingRight = true;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        leftWayPoint = GameObject.Find("LeftWayPoint10").GetComponent<Transform>();
        rightWayPoint = GameObject.Find("RightWayPoint10").GetComponent<Transform>();
        
        deathSound = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > rightWayPoint.position.x){
            movingRight = false;
        }
        if(transform.position.x < leftWayPoint.position.x){
            movingRight = true;
        }
        if(movingRight){
            moveRight();
        }else{
            moveLeft();
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag.Equals("FB")){
            deathSound.Play ();
            ScoreScript.scoreValue+=1;
            Destroy(col.gameObject);
            moveSpeed = 0f;
            Destroy(gameObject, deathSound.clip.length);
        }
        
    }


    void moveLeft(){
        movingRight = false;
        localScale.x = -1;
        transform.localScale = localScale;
        rb.velocity = new Vector2(localScale.x* moveSpeed, rb.velocity.y);

    }

    void moveRight(){
        movingRight = true;
        localScale.x = 1;
        transform.localScale = localScale;
        rb.velocity = new Vector2(localScale.x* moveSpeed, rb.velocity.y);
    }

}