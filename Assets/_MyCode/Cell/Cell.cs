using UnityEngine;

public class Cell : MonoBehaviour
{
    public enum CELL_TYPE { EMPTY, BLOCK, INITED }

    public CELL_TYPE status;
    public int value;
    public Vector2Int pos;

    public CellFaces cellFaces;
    private SpriteRenderer face;

    private void Awake()
    {
        face = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        ChangeCellByNewData(status, value);
    }

    public void ChangeCellByNewData(CELL_TYPE newStatus, int newValue)
    {
        status = newStatus;
        value = newValue;

        switch (status)
        {
            case CELL_TYPE.EMPTY:
                UpdateFaceByReference(cellFaces.empty);
                break;
            case CELL_TYPE.INITED:
                UpdateFaceByReference(cellFaces.cells[value]);
                break;
            default:
                UpdateFaceByReference(cellFaces.block);
                break;

        }
    }
    private void UpdateFaceByReference(SpriteRenderer newFace)
    {
        face.sprite = newFace.sprite;
        face.color = newFace.color;
    }
}
