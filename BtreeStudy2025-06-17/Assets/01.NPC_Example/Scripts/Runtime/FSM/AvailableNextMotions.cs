using UnityEngine;

namespace NPC_Example.FSM
{
    [CreateAssetMenu(fileName = "AvailableNextMotions", menuName = "Scriptable Objects/AvailableNextMotions")]
    public class AvailableNextMotions : ScriptableObject
    {
        [field: SerializeField] public State[] _availalbes { get; private set; }
    }
}