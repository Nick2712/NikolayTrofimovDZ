using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private float _width = 90;
    [SerializeField] private float _height = 90;
    [SerializeField] private float _playerSpeed = 5;

    [SerializeField] GameObject _object1;
    [SerializeField] GameObject _object2;
    [SerializeField] GameObject _object3;
    [SerializeField] GameObject _object4;
    [SerializeField] GameObject _object5;
    [SerializeField] GameObject _object6;
    [SerializeField] GameObject _object7;
    [SerializeField] GameObject _object8;
    [SerializeField] GameObject _object9;

    private WorldCell _cell1;
    private WorldCell _cell2;
    private WorldCell _cell3;
    private WorldCell _cell4;
    private WorldCell _cell5;
    private WorldCell _cell6;
    private WorldCell _cell7;
    private WorldCell _cell8;
    private WorldCell _cell9;
    readonly float _worldCellSize = 8;

    private WorldCell _playerCurrentCell;
    private float _playerXPositionInCell;
    private float _playerYPositionInCell;

    private Vector2 _playerPositionInWorld;

    // Start is called before the first frame update
    void Start()
    {
        _cell1 = new WorldCell();
        _cell2 = new WorldCell();
        _cell3 = new WorldCell();
        _cell4 = new WorldCell();
        _cell5 = new WorldCell();
        _cell6 = new WorldCell();
        _cell7 = new WorldCell();
        _cell8 = new WorldCell();
        _cell9 = new WorldCell();

        _cell1.SetWorldCell(_cell3, _cell7, _cell2, _cell4, _cell9, _cell8, _cell6, _cell5 ,_worldCellSize);
        _cell2.SetWorldCell(_cell1, _cell8, _cell3, _cell5, _cell7, _cell9, _cell4, _cell6, _worldCellSize);
        _cell3.SetWorldCell(_cell2, _cell9, _cell1, _cell6, _cell8, _cell7, _cell5, _cell4, _worldCellSize);
        _cell4.SetWorldCell(_cell6, _cell1, _cell5, _cell7, _cell3, _cell2, _cell9, _cell8, _worldCellSize);
        _cell5.SetWorldCell(_cell4, _cell2, _cell6, _cell8, _cell1, _cell3, _cell7, _cell9, _worldCellSize);
        _cell6.SetWorldCell(_cell5, _cell3, _cell4, _cell9, _cell2, _cell1, _cell8, _cell7, _worldCellSize);
        _cell7.SetWorldCell(_cell9, _cell4, _cell8, _cell1, _cell6, _cell5, _cell3, _cell2, _worldCellSize);
        _cell8.SetWorldCell(_cell7, _cell5, _cell9, _cell2, _cell4, _cell6, _cell1, _cell3, _worldCellSize);
        _cell9.SetWorldCell(_cell8, _cell6, _cell7, _cell3, _cell5, _cell4, _cell2, _cell1, _worldCellSize);

        _playerCurrentCell = _cell5;
        _cell5.OutputCellAsMain();
        _playerXPositionInCell = _worldCellSize / 2;
        _playerYPositionInCell = _worldCellSize / 2;

        _playerPositionInWorld = new Vector2(_playerXPositionInCell, _playerYPositionInCell);
        transform.position = _playerPositionInWorld;
    }

    // Update is called once per frame
    void Update()
    {
        PlaceObjectInCels(_object1, _cell1);
        PlaceObjectInCels(_object2, _cell2);
        PlaceObjectInCels(_object3, _cell3);
        PlaceObjectInCels(_object4, _cell4);
        PlaceObjectInCels(_object5, _cell5);
        PlaceObjectInCels(_object6, _cell6);
        PlaceObjectInCels(_object7, _cell7);
        PlaceObjectInCels(_object8, _cell8);
        PlaceObjectInCels(_object9, _cell9);

        if (Input.GetKey(KeyCode.W)) MoveUp();
        if (Input.GetKey(KeyCode.S)) MoveDown();
        if (Input.GetKey(KeyCode.A)) MoveLeft();
        if (Input.GetKey(KeyCode.D)) MoveRight();
        CheckForLimits();
    }

    void PlaceObjectInCels(GameObject gameObject, WorldCell worldCell)
    {
        Vector2 position = new Vector2(worldCell.XPositoin + _worldCellSize / 2,
            worldCell.YPosition + _worldCellSize / 2);
        gameObject.transform.position = position;
    }

    void CheckForLimits()
    {
        if(_playerXPositionInCell > _worldCellSize)
        {
            float hui = _playerXPositionInCell - _worldCellSize;
            _playerPositionInWorld.x = hui;
            _playerXPositionInCell = hui;
            _playerCurrentCell = _playerCurrentCell._rightNeighbor;
            _playerCurrentCell.OutputCellAsMain();
        }
        if (_playerXPositionInCell < 0)
        {
            float hui = _worldCellSize + _playerXPositionInCell;
            _playerPositionInWorld.x = hui;
            _playerXPositionInCell = hui;
            _playerCurrentCell = _playerCurrentCell._leftNeighbor;
            _playerCurrentCell.OutputCellAsMain();
        }
        if (_playerYPositionInCell > _worldCellSize)
        {
            float hui = _playerYPositionInCell - _worldCellSize;
            _playerPositionInWorld.y = hui;
            _playerYPositionInCell = hui;
            _playerCurrentCell = _playerCurrentCell._upNeighbor;
            _playerCurrentCell.OutputCellAsMain();
        }
        if (_playerYPositionInCell < 0)
        {
            float hui = _worldCellSize + _playerYPositionInCell;
            _playerPositionInWorld.y = hui;
            _playerYPositionInCell = hui;
            _playerCurrentCell = _playerCurrentCell._downNeighbor;
            _playerCurrentCell.OutputCellAsMain();
        }
        transform.position = _playerPositionInWorld;
    }

    void MoveUp()
    {
        _playerYPositionInCell += _playerSpeed * Time.deltaTime;
        _playerPositionInWorld.y = _playerYPositionInCell;
    }

    void MoveDown()
    {
        _playerYPositionInCell -= _playerSpeed * Time.deltaTime;
        _playerPositionInWorld.y = _playerYPositionInCell;
    }

    void MoveLeft()
    {
        _playerXPositionInCell -= _playerSpeed * Time.deltaTime;
        _playerPositionInWorld.x = _playerXPositionInCell;
    }

    void MoveRight()
    {
        _playerXPositionInCell += _playerSpeed * Time.deltaTime;
        _playerPositionInWorld.x = _playerXPositionInCell;
    }
}
