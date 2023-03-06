﻿using Lamov.StateMachine.Runtime.States;
using Lamov.StateMachine.Runtime.TransitionStateMachineModule;

namespace Lamov.StateMachine.Runtime.SubStateMachines
{
    public class TransitionSubStateMachine : SimpleSubStateMachine<TransitionStateMachine>, IUpdateState
    {
        public void Update() =>_stateMachine.Update();
    }
}