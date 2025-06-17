using NPC_Example.Behaviours.BT;
using UnityEngine;
using UnityEngine.AI;

namespace NPC_Example.Controllers
{
    [RequireComponent(typeof(NavMeshAgent), typeof(BehaviourTree))]
    public class NPC : MonoBehaviour
    {
        private BehaviourTree _tree;

        [Header("Seek")]
        [SerializeField] private float _seekAngle = 90f;
        [SerializeField] private float _seekRadius = 5f;
        [SerializeField] private float _seekHeight = 1f;
        [SerializeField] private float _seekMaxDistance = 8f;
        [SerializeField] private LayerMask _seekTargetMask;
        [SerializeField] private LayerMask _seelObstacleMask;

        private void Start()
        {
            _tree = GetComponent<BehaviourTree>();
            Sequence sequence1 = new Sequence(_tree);
            _tree.root.AttachChild(sequence1);

            sequence1.AttachChild(new Seek(_tree,
                                           _seekAngle,
                                           _seekRadius,
                                           _seekHeight,
                                           _seekMaxDistance,
                                           _seekTargetMask,
                                           _seelObstacleMask));
        }
    }
}
