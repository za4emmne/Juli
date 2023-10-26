using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JulyTriggered : MonoBehaviour
{
    [SerializeField] private UnityEvent _enter;
    [SerializeField] private UnityEvent _exit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<July>(out July july))
        {
            _enter?.Invoke();
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            _exit?.Invoke();
        }
    }
}
