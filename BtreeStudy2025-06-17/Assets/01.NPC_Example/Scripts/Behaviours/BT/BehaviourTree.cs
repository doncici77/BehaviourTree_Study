using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace NPC_Example.Behaviours.BT
{
    public class BehaviourTree : MonoBehaviour
    {
        public Blackboard blackboard { get; private set; }
        public Root root { get; set; }
        private bool _isRunning;
        private Stack<Node> _stack;

        private void Awake()
        {
            blackboard = new Blackboard(gameObject);
            root = new Root(this);
            _stack = new Stack<Node>();
        }

        private void Update()
        {
            if (_isRunning)
            {
                return;
            }

            _isRunning = true;
            StartCoroutine(C_Tick());
        }

        private IEnumerator C_Tick()
        {
            _stack.Push(root);

            while (_stack.Count > 0)
            {
                Node node = _stack.Pop();
                Result result = node.Invoke();

                if (result == Result.Running)
                {
                    _stack.Push(node);
                    yield return null;
                }
            }

            _isRunning = false;
        }

        private void OnDrawGizmos()
        {
            if(_stack != null && _stack.Count > 0)
            {
                _stack.Peek().OnDrawGizmos();
            }
        }
    }
}
