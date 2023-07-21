using System;
using System.Collections.Generic;
using NavMeshScripts;
using UnityEngine;

namespace Que
{
    public class QueManager : MonoBehaviour
    {
        // We need this for be able to handle navmesh agents

        public List<NavMeshQueMovement> navMeshQueMovements = new List<NavMeshQueMovement>();
        public Transform mainQueTarget;
        
        private NavMeshQueMovement leaderAgent;
        private QueInfo _queInfo;

        private void Awake()
        {
            _queInfo = GetComponent<QueInfo>();
        }

        private void Start()
        {
            SetQue();
        }

        private void SetQue()
        {
            navMeshQueMovements.Sort(CompareDistanceToBox);
            for (int i = 0; i < navMeshQueMovements.Count; i++)
            {
                navMeshQueMovements[i].SetForQue(_queInfo.GetQuePosition());

            }
        }
        
        private int CompareDistanceToBox(NavMeshQueMovement a, NavMeshQueMovement b)
        {
           
            
            float distanceA = Mathf.Abs( Vector3.Distance(a.transform.localPosition, mainQueTarget.position));
            float distanceB = Mathf.Abs( Vector3.Distance(b.transform.localPosition, mainQueTarget.position));

           
            if (distanceA < distanceB)
            {
                return 1; 
            }
            else if (distanceA > distanceB)
            {
                return -1; 
            }
            else
            {
                return 0; 
            }
        }
    }
}