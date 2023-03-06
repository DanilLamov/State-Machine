using Lamov.StateMachine.Runtime.States;
using UnityEngine;

namespace Lamov.StateMachineTest.UnityComponents.States
{
    public class AState : IState, IStateEnter, IUpdateState, IStateExit
    {
        public void OnStateEnter()
        {
            Debug.Log("Enter State A");
        }

        public void Update()
        {
            Debug.Log("Update State A");
        }

        public void OnStateExit()
        {
            Debug.Log("Exit State A");
        }
    }
}