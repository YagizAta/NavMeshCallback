using System;
using UnityEngine;
using UnityEngine.AI;


public class PathCompleteManager : MonoBehaviour
{
        public static PathCompleteManager instance;

        public NavMeshAgent agent;
        public Action _action;
        public float rotIntensity = 100;
        
        private Coroutine lastCoroutine;
        private WaitForSeconds _waitForSeconds;
        private void Awake()
        {
            if (!instance)
            {
                instance = this;
            }
        }

        public void CallFindTime(Action action)
        {
            _action = action;
            Invoke("FindTime",1.2f);
        }
        public void FindTime()
        {
            CancelInvoke();
            float totalTime = 0f;
            int cornerCount = agent.path.corners.Length;
            if (agent.path.corners.Length>=2)
            {
                for (int i = 1; i < agent.path.corners.Length-1; i++)
                {
                    float dist = Vector3.Distance(agent.path.corners[i], agent.path.corners[i-1]);
                    float time = dist / (agent.speed-agent.speed/10);
                    
                    Vector3 dir = agent.path.corners[i] - agent.path.corners[i - 1];
                    Debug.Log(dir);
                    float degree = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
                    degree /= rotIntensity;
                    Debug.Log(degree);
                    float rotTime = Mathf.Abs( degree / agent.angularSpeed);
                    
                    Debug.Log(rotTime);
                    totalTime += time;
                    totalTime += rotTime;
                }
                Invoke("CalculateLastOne",totalTime);
            }
            else
            {
                float dist = Vector3.Distance(agent.path.corners[0], transform.position);
                float time = dist / (agent.speed-agent.speed/10);
                totalTime += time;
            }
        }

        private void CalculateLastOne()
        {
            float dist = Vector3.Distance(agent.path.corners[agent.path.corners.Length-1], transform.position);
            float time = dist / (agent.speed-agent.speed/10);
            Invoke("CallAction",time);
        }

        private void CallAction()
        {
            _action.Invoke();
        }
    }
