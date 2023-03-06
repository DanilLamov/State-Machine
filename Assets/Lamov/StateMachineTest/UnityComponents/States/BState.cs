using Lamov.StateMachine.Runtime.States;
using UnityEngine;

namespace Lamov.StateMachineTest.UnityComponents.States
{
    public class BState : IState, IStateEnter, IUpdateState, IStateExit
    {
        public void OnStateEnter()
        {
            Debug.Log("Enter State B");
        }

        public void Update()
        {
            Debug.Log("Update State B");
        }

        public void OnStateExit()
        {
            Debug.Log("Exit State B");
        }
    }
}