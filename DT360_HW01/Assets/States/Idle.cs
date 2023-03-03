using UnityEngine;

public class Idle : BaseState
{
    // Input to specify horizontal distance
    // - moves left
    // 0 idles
    // + moves right
    private float _horizontalInput;
    private float _verticalInput;
    private float _jumpInput;
    private JumpTrigger _jp;

    private CoinSpawner _cs;
    private CoinArea _ca;

    public Idle (MovementSM stateMachine) : base("Idle", stateMachine) {}

    public override void Enter()
    {
        // _TODO_ :
        // set idle appearance : black & clear input
        base.Enter();
        _cs = GameObject.Find("GameManager").GetComponent<CoinSpawner>();
        _ca = GameObject.Find("CoinReturnArea").GetComponent<CoinArea>();
        _jp = GameObject.Find("Player").GetComponent<JumpTrigger>();
        //((MovementSM)stateMachine).spriteRenderer.color = Color.black;
        _horizontalInput = 0f;
        _verticalInput = 0f;
    }

    public override void UpdateLogic()
    {
        // _TODO_ :
        // when to change state 
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _jumpInput = Input.GetAxis("Jump");
        //Debug.Log(_jumpInput);
        if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon || Mathf.Abs(_verticalInput) > Mathf.Epsilon)
        {
            stateMachine.ChangeState(((MovementSM)stateMachine).movingState);
            
        }

        //if (Mathf.Abs(_jumpInput) > Mathf.Epsilon && _jp.canJump == true)
        //{
        //    Debug.Log("Jump");
        //    stateMachine.ChangeState(((MovementSM)stateMachine).jumpState);
        //}
        if (_cs.currentCoin == 10 && _ca.enter == true)
        {
            Debug.Log("Send");
            stateMachine.ChangeState(((MovementSM)stateMachine).sendingState);
        }
    }
}
