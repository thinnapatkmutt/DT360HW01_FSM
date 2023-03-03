using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSM : StateMachine
{
    public float speed = 4f;
    public Rigidbody rb;
    //public SpriteRenderer spriteRenderer;

    [HideInInspector]
    public Idle idleState;
    [HideInInspector]
    public Moving movingState;
    [HideInInspector]
    public Jumping jumpState;
    [HideInInspector]
    public SendingTask sendingState;

    private void Awake()
    {
        // _TODO_ :
        // create states
        idleState = new Idle(this);
        movingState = new Moving(this);
        jumpState = new Jumping(this);
        sendingState = new SendingTask(this);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}
