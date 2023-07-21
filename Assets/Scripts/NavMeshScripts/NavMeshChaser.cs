using CallBack;
using UnityEngine;

namespace NavMeshScripts
{
    public class NavMeshChaser : MonoBehaviour
    {
        
        public NavMeshAgentWithCallback agent;
        public Transform target;
       

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