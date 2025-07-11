﻿using NPC_Example.FSM;
using UnityEngine;
using UnityEngine.AI;

namespace NPC_Example.Behaviours.BT
{
    /// <summary>
    /// 노드들이 공유해야하는 데이터 컨테이너
    /// </summary>
    public class Blackboard
    {
        public Blackboard(GameObject owner)
        {
            this.transform = owner.transform;
            this.agent = owner.GetComponent<NavMeshAgent>();
            this.motionController = owner.GetComponent<MotionController>();
        }

        // owner
        public Transform transform { get; set; }
        public NavMeshAgent agent { get; set; }
        public MotionController motionController { get; set; }

        // target
        public Transform target { get; set; }
    }
}
