using UnityEngine;

public class Moving : BaseState
{
    private float _horizontalInput;
    private float _verticalInput;
    private float _jumpInput;
    private MovementSM _sm;
    private CoinSpawner _cs;
    private CoinArea _ca;

    public Moving(MovementSM stateMachine) : base("Moving", stateMachine) 
    {
	    _sm = (MovementSM)stateMachine;
    }

    public override void Enter()
    {
        // _TODO_ :
        // set idle appearance : red & clear input
        base.Enter();
        _cs = GameObject.Find("GameManager").GetComponent<CoinSpawner>();
        _ca = GameObject.Find("CoinReturnArea").GetComponent<CoinArea>();
        //((MovementSM)stateMachine).spriteRenderer.color = Color.red;wdd
        _horizontalInput = 0f;
        _verticalInput = 0f;
    }

    public override void UpdateLogic()
    {
        // _TODO_ :
        // when to change state ???
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _jumpInput = Input.GetAxis("Jump");
        if (Mathf.Abs(_horizontalInput) <= 0f && Mathf.Abs(_verticalInput) <= 0f)
        {
            stateMachine.ChangeState(((MovementSM)stateMachine).idleState);
        }
        //if (Mathf.Abs(_jumpInput) > Mathf.Epsilon)
        //{
        //    stateMachine.ChangeState(((MovementSM)stateMachine).jumpState);
        //}
        if(_cs.currentCoin >= 10 && _ca.enter == true)
        {
            Debug.Log("Send");
            stateMachine.ChangeState(((MovementSM)stateMachine).sendingState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Vector3 vel = _sm.GetComponent<Rigidbody>().velocity;
        vel.x = _horizontalInput * ((MovementSM)stateMachine).speed;
        vel.z = _verticalInput * ((MovementSM)stateMachine).speed;
        _sm.GetComponent<Rigidbody>().velocity = vel;
    }

}
