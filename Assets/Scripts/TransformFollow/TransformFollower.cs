using System;
using CallBack;
using NavMeshScripts;
using UnityEngine;

using UnityEngine.AI;

public class TransformFollower : MonoBehaviour
{
        public NavMeshAgentWithCallback agent;
        private Vector3 firstPos;

        public float distChecker;
        private void Start()
        {
            firstPos = transform.position;
           
            InvokeRepeating("CheckIfWeMove",0.2f,0.1f);
        }

        private void MoveAgain()
        {
            agent.SetDestination(transform.position).OnPathComplete(agent.OnCompleteAction);
        }

        private void CheckIfWeMove()
        {
            float dist = Vector3.Distance(firstPos, transform.position);
            if (dist>distChecker)
            {
                MoveAgain();
                firstPos = transform.position;
            }
        }
        
    }
