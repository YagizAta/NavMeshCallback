using System;
using CallBack;
using UnityEngine;

namespace NavMeshScripts
{
    public class NavMeshManager : MonoBehaviour
    {
        public static NavMeshManager instance;
        public NavMeshAgentWithCallback agent;
        public Transform target;
        private void Awake()
        {
            if (!instance)
            {
                instance = this;
            }
        }

        void Start()
        {
            agent.SetDestination(target.position).OnPathComplete(Write);
        }

        private void Write()
        {
            Debug.Log("we are done");
            UnityEditor.EditorApplication.isPaused = true;
        }
    }
}