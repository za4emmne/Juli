using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _enter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<July>(out July july))
        {
            _enter?.Invoke();
        }
    }
}
