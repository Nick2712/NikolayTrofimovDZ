using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCell
{
    public WorldCell _leftNeighbor;
    public WorldCell _upNeighbor;
    public WorldCell _rightNeighbor;
    public WorldCell _downNeighbor;
    public WorldCell _upLeftNeighbor;
    public WorldCell _upRightNeighbor;
    public WorldCell _downLeftNeighbor;
    public WorldCell _downRightNeighbor;

    float _cellSize;

    public float XPositoin { get; private set; }
    public float YPosition { get; private set; }

    public void SetWorldCell (WorldCell leftNeighbor, WorldCell upNeighbor, WorldCell rightNeighbor, 
        WorldCell downNeighbor, WorldCell upLeftNeighbor, WorldCell upRightNeighbor,
        WorldCell downLeftNeighbor, WorldCell downRightNeighbor, float cellSize)
    {
        _leftNeighbor = leftNeighbor;
        _upNeighbor = upNeighbor;
        _rightNeighbor = rightNeighbor;
        _downNeighbor = downNeighbor;
        _upLeftNeighbor = upLeftNeighbor;
        _upRightNeighbor = upRightNeighbor;
        _downLeftNeighbor = downLeftNeighbor;
        _downRightNeighbor = downRightNeighbor;
        _cellSize = cellSize;
    }

    public void OutputCellAsMain()
    {
        XPositoin = 0;
        YPosition = 0;
        _leftNeighbor.SetCellPositionInWorld(XPositoin - _cellSize, YPosition);
        _upNeighbor.SetCellPositionInWorld(XPositoin, YPosition + _cellSize);
        _rightNeighbor.SetCellPositionInWorld(XPositoin + _cellSize, YPosition);
        _downNeighbor.SetCellPositionInWorld(XPositoin, YPosition - _cellSize);
        _upLeftNeighbor.SetCellPositionInWorld(XPositoin - _cellSize, YPosition + _cellSize);
        _upRightNeighbor.SetCellPositionInWorld(XPositoin + _cellSize, YPosition + _cellSize);
        _downLeftNeighbor.SetCellPositionInWorld(XPositoin - _cellSize, YPosition - _cellSize);
        _downRightNeighbor.SetCellPositionInWorld(XPositoin + _cellSize, YPosition - _cellSize);
    }

    public void SetCellPositionInWorld(float xPosition, float yPosition)
    {
        XPositoin = xPosition;
        YPosition = yPosition;
    }
}
