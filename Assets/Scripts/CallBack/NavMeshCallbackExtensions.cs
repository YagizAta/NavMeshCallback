using System;
using NavMeshScripts;
using UnityEngine;

namespace CallBack
{
    public static class NavMeshCallbackExtensions
    {
       
           
            public static T OnPathComplete<T>(this T t, Action action) where T : NavMeshAgentWithCallback
            {
                t.OnCompleteAction = action;
                PathCompleteManager.instance.CallFindTime(action);
                //NavmeshProblem.instance.CallTime();
             
                return t;
            }
            public static T OnChange<T>(this T t, Action action) where T : NavMeshAgentWithCallback
            {
                
                return t;
            }
       
        
     
        
    }
}