using System;
using UnityEngine;


    public class Evt
    {
        private event Action _action = delegate {  };


        public void Invoke()
        {
         
            
            if (_action!=null)
            {
                _action.Invoke();
                //RemoveAll();
            }
           
          
        }

       

        public void AddListener(Action listener, bool isExtra = false)
        {
            _action -= listener;
            _action += listener;
            
        }
        
        

        
        public void RemoveListener(Action listener)
        {
            _action -= listener;
        }

        public void RemoveAll()
        {
            _action = null;
        }
    }

public class Evt<T>
{ 
    private event Action<T> _action = delegate {  };


    public void Invoke(T param)
    {
        if (_action!=null)
        {
            
            _action.Invoke(param);
            
        }
      
    }

    public void AddListener(Action<T> listener)
    {
        //_action -= listener;
        _action -= listener;
        _action += listener;
    }
    public void RemoveListener(Action<T> listener)
    {
        _action -= listener;
    }

    public void RemoveAll()
    {
        _action = null;
    }
}
public class Evt<T,C>
{ 
    private event Action<T,C> _action = delegate {  };


    public void Invoke(T param,C parama)
    {
        if (_action!=null)
        {
            
            _action.Invoke(param,parama);
            
            
        }
      
    }

    public void AddListener(Action<T,C> listener)
    {
        //_action -= listener;
        _action -= listener;
        _action += listener;
    }
    public void RemoveListener(Action<T,C> listener)
    {
        _action -= listener;
    }

    public void RemoveAll()
    {
        _action = null;
    }
}