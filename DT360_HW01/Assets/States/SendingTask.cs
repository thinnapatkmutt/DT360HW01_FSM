using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendingTask : BaseState
{
    private float _horizontalInput;
    private float _verticalInput;
    private float _jumpInput;
    private MovementSM _sm;
    private CoinSpawner _cs;
    private float startTime = 0;
    private float waitTime = 2.0f;
    private bool timerStart = false;

    public SendingTask(MovementSM stateMachine) : base("Sending Task", stateMachine)
    {
        _sm = (MovementSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _cs = GameObject.Find("GameManager").GetComponent<CoinSpawner>();
        _horizontalInput = 0f;
        _verticalInput = 0f;
        waitTime = 2.0f;
    }

    public override void UpdateLogic()
    {
        // _TODO_ :
        // when to change state ???
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _jumpInput = Input.GetAxis("Jump");
        _cs.currentCoin = 0;
        if (_cs.GetCurCoin() <= 0 && waitTime <= 0)
        {
            _cs.happyTrigger();
            _cs.SpawnCoin();
            stateMachine.ChangeState(((MovementSM)stateMachine).movingState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        if(waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }
    }
}
