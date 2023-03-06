using Lamov.StateMachine.Runtime.States;
using UnityEngine;

namespace Lamov.StateMachineTest.UnityComponents.States
{
    public class CState : IState, IStateEnter, IUpdateState, IStateExit
    {
        public void OnStateEnter()
        {
            Debug.Log("Enter State C");
        }

        public void Update()
        {
            Debug.Log("Update State C");
        }

        public void OnStateExit()
        {
            Debug.Log("Exit State C");
        }
    }
}