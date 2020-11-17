using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{
    public float moveSpeed = 3f;
    Transform leftWayPoint, rightWayPoint;
    Vector3 localScale;
    bool movingRight = true;
    Rigidbody2D rb;
    public static int bossHealth = 10;
    public GameObject s1, s2, s3, s4, s5;

    // Start is called before the first frame update
    void Start()
    {
        s1 = GameObject.Find("sB1");
        s2 = GameObject.Find("sB2");
        s3 = GameObject.Find("sB3");
        s4 = GameObject.Find("sB4");
        s5 = GameObject.Find("sB5");
        s1.gameObject.SetActive(true);
        s2.gameObject.SetActive(true);
        s3.gameObject.SetActive(true);
        s4.gameObject.SetActive(true);
        s5.gameObject.SetActive(true);
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        leftWayPoint = GameObject.Find("LeftWayPoint23").GetComponent<Transform>();
        rightWayPoint = GameObject.Find("RightWayPoint23").GetComponent<Transform>();
        
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
            Destroy(col.gameObject);
            bossHealth -= 1;
            switch(bossHealth){
                case 9:
                    s1.gameObject.SetActive(false);
                    
                    break;
                case 8:
                    s2.gameObject.SetActive(false);
                    
                    break;
                case 7:
                    s3.gameObject.SetActive(false);
                    
                    break;
                case 6:
                    s4.gameObject.SetActive(false);
                   
                    break;
                case 5:
                    s5.gameObject.SetActive(false);
                    s1.gameObject.SetActive(true);
                    s2.gameObject.SetActive(true);
                    s3.gameObject.SetActive(true);
                    s4.gameObject.SetActive(true);
                    s5.gameObject.SetActive(true);
                    break;
                case 4:
                    s1.gameObject.SetActive(false);
                    
                    break;
                case 3:
                    s2.gameObject.SetActive(false);
                    
                    break;
                case 2:
                    s3.gameObject.SetActive(false);
                    
                    break;
                case 1:
                    s4.gameObject.SetActive(false);
                    
                    break;
                case 0:
                    s5.gameObject.SetActive(false);
                    Destroy(gameObject);
                    break;
            }
        }
            //if(bossHealth < 1){
            //    
            //}

         
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
