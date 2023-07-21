using CallBack;
using UnityEngine;

namespace NavMeshScripts
{
    public class NavMeshMove : MonoBehaviour
    {
        public static NavMeshMove instance;
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
            Events.onTargetMove.AddListener(Move);
            Move();
        }

        private void Move()
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