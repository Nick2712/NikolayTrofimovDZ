using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private float _width = 90;
    [SerializeField] private float _height = 90;
    [SerializeField] private float _playerSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) MoveUp();
        if (Input.GetKey(KeyCode.S)) MoveDown();
        if (Input.GetKey(KeyCode.A)) MoveLeft();
        if (Input.GetKey(KeyCode.D)) MoveRight();
        CheckForLimits();
    }

    void CheckForLimits()
    {
        if(transform.position.x > _width)
        {
            Vector2 position = transform.position;
            float hui = position.x - _width;
            position.x = hui;
            transform.position = position;
        }
        if (transform.position.x < 0)
        {
            Vector2 position = transform.position;
            float hui = _width + position.x;
            position.x = hui;
            transform.position = position;
        }
        if (transform.position.y > _height)
        {
            Vector2 position = transform.position;
            float hui = position.y - _height;
            position.y = hui;
            transform.position = position;
        }
        if (transform.position.y < 0)
        {
            Vector2 position = transform.position;
            float hui = _height + position.y;
            position.y = hui;
            transform.position = position;
        }
    }

    void MoveUp()
    {
        Vector2 position = transform.position;
        position.y += _playerSpeed * Time.deltaTime;
        transform.position = position;
    }

    void MoveDown()
    {
        Vector2 position = transform.position;
        position.y -= _playerSpeed * Time.deltaTime;
        transform.position = position;
    }

    void MoveLeft()
    {
        Vector2 position = transform.position;
        position.x -= _playerSpeed * Time.deltaTime;
        transform.position = position;
    }

    void MoveRight()
    {
        Vector2 position = transform.position;
        position.x += _playerSpeed * Time.deltaTime;
        transform.position = position;
    }
}
