using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _path; // путь
    private Transform[] _points; // точки пут€
    private int _currentPoint; // текуща€ точка
    private float _speed = 1;

    void Start()
    {
        _points = new Transform[_path.childCount]; //массив по количеству всех точек

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }
    void Update()
    {
        Transform target = _points[_currentPoint]; // присваиваем положение текущего объекту нашей цели
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime); // двигаем€ к цели
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Point>(out Point point)) //провер€ем то с чем сталкиваетс€ объект
        {
            _currentPoint++;
            transform.localScale = new Vector3(-1*transform.localScale.x, transform.localScale.y);
            print(_currentPoint);

            if (_currentPoint >= _points.Length) // если достигли мах обнул€ем
            {
                _currentPoint = 0;
            }
        }

    }
}
