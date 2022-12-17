using System;
using UnityEngine;
using UnityEngine.AI;

namespace NavMeshScripts
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NavMeshAgentWithCallback : MonoBehaviour
    {
      private NavMeshAgent agent;

        #region NavMeshAgentVariables

        public Vector3 velocity => agent.velocity;
        public Vector3 destination => agent.destination;
        public Vector3 desiredVelocity => agent.desiredVelocity;
        public Vector3 nextPosition => agent.nextPosition;
        public Vector3 steeringTarget => agent.steeringTarget;
        public Vector3 pathEndPosition => agent.pathEndPosition;
        public float acceleration => agent.acceleration;
        public float remainingDistance => agent.remainingDistance;
        public float height => agent.height;
        public float radius => agent.radius;
        public float speed => agent.speed;
        public float angularSpeed => agent.angularSpeed;
        public int areaMask => agent.areaMask;
        public int avoidancePriority => agent.avoidancePriority;
        public int agentTypeID => agent.agentTypeID;
        public NavMeshPath path => agent.path;
        public bool autoBraking => agent.autoBraking;
        public bool autoRepath => agent.autoRepath;

        #endregion

        public Action OnCompleteAction;

        private Action call;

        private Vector3 firstPos;
        private bool isChanged = true;
        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        public NavMeshAgentWithCallback SetDestination(Vector3 target)
        {
            agent.SetDestination(target);
            return this;
        }
    }
}