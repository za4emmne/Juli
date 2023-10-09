using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Exit : MonoBehaviour
{
    [SerializeField] private UnityEvent _exit;

    private void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            _exit?.Invoke();
        }
    }
}
