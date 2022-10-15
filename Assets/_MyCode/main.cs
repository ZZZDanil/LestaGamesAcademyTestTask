using UnityEngine;

public class main : MonoBehaviour
{

    private RaycastHit hit;
    private Ray ray;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                GameRuleMiniGame.newSelectedCell = hit.transform?.GetComponentInParent<Cell>();
            }
            else
            {
                GameRuleMiniGame.newSelectedCell = null;
            }

            GameRuleMiniGame.DoRule();
        }
    }
}
