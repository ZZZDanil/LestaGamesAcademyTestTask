using UnityEngine;

public class Field : MonoBehaviour
{
    public Cell[] cellsLeft;
    public Cell[] cellsCenter;
    public Cell[] cellsRight;
    public Cell[] cellsEmpty;
    public Cell[] cellsBlock;

    private int cellsLeftCount;
    private int cellsCenterCount;
    private int cellsRightCount;

    private void Awake()
    {
        GameRuleMiniGame.miniGameField = this;
    }
    private void Start()
    {
        Generate();
    }

    private void Generate()
    {
        InitCellCounts();
        UpdateColumn(cellsLeft);
        UpdateColumn(cellsCenter);
        UpdateColumn(cellsRight);
    }
    public void EasyGenerate()
    {
        for (int row = 0; row < 5; row++)
        {
            cellsLeft[row].ChangeCellByNewData(Cell.CELL_TYPE.INITED, 0);
            cellsCenter[row].ChangeCellByNewData(Cell.CELL_TYPE.INITED, 1);
            cellsRight[row].ChangeCellByNewData(Cell.CELL_TYPE.INITED, 2);
        }
        foreach(Cell c in cellsEmpty)
        {
            c.ChangeCellByNewData(Cell.CELL_TYPE.EMPTY, 0);
        }
        foreach (Cell c in cellsBlock)
        {
            c.ChangeCellByNewData(Cell.CELL_TYPE.BLOCK, 0);
        }

        cellsCenter[3].ChangeCellByNewData(Cell.CELL_TYPE.INITED, 2);
        cellsRight[1].ChangeCellByNewData(Cell.CELL_TYPE.INITED, 1);
    }

    public bool IsColumnsAreFull()
    {
        for (int row = 0; row < 5; row++)
        {
            if (cellsLeft[row].value != 0 ||
                cellsCenter[row].value != 1 ||
                cellsRight[row].value != 2)
                return false;
        }
        return true;
    }

    private void UpdateColumn(Cell[] cells)
    {
        for (int row = 0; row < 5; row++)
        {
            cells[row].ChangeCellByNewData(Cell.CELL_TYPE.INITED, RandomNewCellValue());
        }
    }
    private int RandomNewCellValue()
    {
        int r = Random.Range(0, cellsLeftCount + cellsCenterCount + cellsRightCount);

        if (r < cellsLeftCount)
        {
            cellsLeftCount--;
            return 0;
        }
        else if (r >= cellsLeftCount + cellsCenterCount)
        {
            cellsRightCount--;
            return 2;
        }
        else
        {
            cellsCenterCount--;
            return 1;
        }
    }
    private void InitCellCounts()
    {
        cellsLeftCount = 5;
        cellsCenterCount = 5;
        cellsRightCount = 5;
    }

}
