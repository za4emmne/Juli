using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;

    private Transform[] _points;
    private int _currentPoint; 
    private float _speed = 1;

    private void Start()
    {
        _points = new Transform[_path.childCount]; 

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }
    private void Update()
    {
        Transform target = _points[_currentPoint]; 
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Point>(out Point point)) 
        {
            _currentPoint++;
            transform.localScale = new Vector3(-1*transform.localScale.x, transform.localScale.y);
            print(_currentPoint);

            if (_currentPoint >= _points.Length) 
            {
                _currentPoint = 0;
            }
        }
    }
}
