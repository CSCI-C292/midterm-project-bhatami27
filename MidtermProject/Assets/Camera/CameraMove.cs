using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    
    public Transform player1;
    
    void FixedUpdate() 
    {
        transform.position = new Vector3(player1.position.x, player1.position.y, transform.position.z);
    }
}
