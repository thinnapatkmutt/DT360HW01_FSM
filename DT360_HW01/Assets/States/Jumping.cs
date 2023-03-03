using UnityEngine;

public class Jumping : BaseState
{
    private float _jumpInput;
    private MovementSM _sm;

    public Jumping (MovementSM stateMachine) : base("Floating", stateMachine)
    {
        _sm = (MovementSM)stateMachine;
    }

    public override void Enter()
    {
        // _TODO_ :
        // set idle appearance : red & clear input
        base.Enter();

        //((MovementSM)stateMachine).spriteRenderer.color = Color.green;
        _jumpInput = 0f;
    }

    public override void UpdateLogic()
    {
        // _TODO_ :
        // when to change state ???
        _jumpInput = Input.GetAxis("Jump");
        Debug.Log(_jumpInput);
        if (Mathf.Abs(_jumpInput) <= 0f)
        {
            stateMachine.ChangeState(((MovementSM)stateMachine).idleState);
        }
        //else
        //{
        //    stateMachine.ChangeState(((MovementSM)stateMachine).jumpState);
        //}
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Vector2 vel = _sm.GetComponent<Rigidbody>().velocity;
        vel.y = _jumpInput * (((MovementSM)stateMachine).speed - 3);
        _sm.GetComponent<Rigidbody>().velocity = vel;
    }

}
