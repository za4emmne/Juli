using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EventOfAlarm : MonoBehaviour
{
    [SerializeField] private GameObject _bear;
    [SerializeField] private BoxCollider2D _walls;
    [SerializeField] private GameObject _textExt;
    [SerializeField] private TilemapRenderer _door;

    private BoxCollider2D _doorCollider;

    private void Start()
    {
        _door = GetComponent<TilemapRenderer>();
        _doorCollider = GetComponent<BoxCollider2D>();
    }

    public void EnterInDoor()
    {
        _bear.SetActive(false);
        _door.enabled = false;
        _walls.isTrigger = false;
        _textExt.SetActive(true);
        _doorCollider.enabled = false;
    }

    public void ExitDoor()
    {
        _bear.SetActive(true);
         _door.enabled = true;
        _walls.isTrigger = true;
        _textExt.SetActive(false);
        _doorCollider.enabled = true; 
    }
}

