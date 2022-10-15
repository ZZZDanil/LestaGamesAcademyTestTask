using UnityEngine;

public static class GameRuleMiniGame
{
    public enum MINI_GAME_STATE { EMPTY, SELECT_SECOND_CELL_AND_SWAP }
    public static MINI_GAME_STATE state = MINI_GAME_STATE.EMPTY;
    public static Cell newSelectedCell;

    private static Cell firstSelectedCell;

    /**/
    public static Field miniGameField;
    public static EndWindow endWindow;

    /*
    1) клик по первому объекту (если не пустой и не блок)
    2) клик по второму объекту и переместить(если второй объект не блок)
    2.5) проверить на победу 

   */
    public static void DoRule()
    {
        switch (state)
        {
            case MINI_GAME_STATE.EMPTY:
                {
                    if (newSelectedCell != null && newSelectedCell.status == Cell.CELL_TYPE.INITED)
                    {
                        firstSelectedCell = newSelectedCell;
                        state = MINI_GAME_STATE.SELECT_SECOND_CELL_AND_SWAP;
                    }
                    break;
                }
            case MINI_GAME_STATE.SELECT_SECOND_CELL_AND_SWAP:
                {
                    if (newSelectedCell != null && newSelectedCell.status != Cell.CELL_TYPE.BLOCK
                        && IsNearest(firstSelectedCell.pos, newSelectedCell.pos))
                    {
                        CellSwap(newSelectedCell, firstSelectedCell);

                        CheckEndGame();
                    }
                    else
                    {
                        firstSelectedCell = null;
                    }
                    state = MINI_GAME_STATE.EMPTY;
                    break;
                }
        }
    }

    private static bool IsNearest(Vector2Int first, Vector2Int second)
    {
        Vector2Int normal = first - second;
        if ((normal.y == 0 && (normal.x == 1 || normal.x == -1)) ||
            (normal.x == 0 && (normal.y == 1 || normal.y == -1)))
            return true;
        else
            return false;
    }

    private static void CellSwap(Cell first, Cell second)
    {
        Cell.CELL_TYPE bufStatus = first.status;
        int bufValue = first.value;
        first.ChangeCellByNewData(second.status, second.value);
        second.ChangeCellByNewData(bufStatus, bufValue);
    }
    private static void CheckEndGame()
    {
        if (miniGameField.IsColumnsAreFull())
        {
            Debug.Log("Win");
            endWindow.ShowResultWindow();
        }
    }

}
