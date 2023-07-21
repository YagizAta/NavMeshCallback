using System.Collections.Generic;
using UnityEngine;

namespace Que
{
    public class QueInfo : MonoBehaviour
    {
        public List<Transform> quePoses = new List<Transform>();

        private int indexOfAvailableQue;


        public Transform GetQuePosition()
        {
            return quePoses[indexOfAvailableQue];
        }
        
        
    }
}