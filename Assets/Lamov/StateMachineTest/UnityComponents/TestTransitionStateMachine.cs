using Lamov.StateMachine.Runtime.TransitionStateMachineModule;
using Lamov.StateMachineTest.UnityComponents.States;
using UnityEngine;

namespace Lamov.StateMachineTest.UnityComponents
{
    public class TestTransitionStateMachine : MonoBehaviour
    {
        [SerializeField] private bool _aState;
        [SerializeField] private bool _bState;
        [SerializeField] private bool _cState;

        private TransitionStateMachine _stateMachine;
        
        private void Awake()
        {
            var aState = new AState();
            var bState = new BState();
            var cState = new CState();
            
            _stateMachine = new TransitionStateMachine();
            
            _stateMachine.AddState(aState);
            _stateMachine.AddState(bState);
            _stateMachine.AddState(cState);
            
            _stateMachine.AddTransition(aState, new StateTransition(bState, () => !_aState && _bState));
            _stateMachine.AddTransition(bState, new StateTransition(aState, () => !_bState && _aState));
            
            _stateMachine.Enter(aState);
        }

        private void Update()
        {
            _stateMachine.Update();
        }
    }
}