using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    BaseState currentState;

    void Start()
    {
        // _TODO_ :
        // set initial state
        currentState = GetInitialState();
        if(currentState != null)
        {
            currentState.Enter();
        }
   }

    void Update()
    {
        if (currentState != null)
            currentState.UpdateLogic();
    }

    void LateUpdate()
    {
        if (currentState != null)
            currentState.UpdatePhysics();
    }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }

    public void ChangeState(BaseState newState)
    {
        // _TODO_
        // 
        //newState.name = "Idle";
        currentState.Exit();
        currentState = newState;
        newState.Enter();
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10f, 10f, 300f, 100f));
        string content = currentState != null ? currentState.name : "(no current state)";
        GUILayout.Label($"<color='white'><size=20>{content}</size></color>");
        GUILayout.EndArea();
    }
}
