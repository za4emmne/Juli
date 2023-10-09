using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            TurnLeft();
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            _animator.SetTrigger("run");
        }

        if(Input.GetKey(KeyCode.D))
        {
            TurnRight();
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _animator.SetTrigger("run");
        }

        if(Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
        }
    }

    private void TurnLeft()
    {
        if (transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y);
        }
    }

    private void TurnRight()
    {
        if (transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y);
        }
    }
}
