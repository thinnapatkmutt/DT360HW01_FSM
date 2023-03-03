using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    public bool canJump = true;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            canJump = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        canJump = false;
    }
}
