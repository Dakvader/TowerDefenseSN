using UnityEngine;
using System.Collections;

public class MousePosition : MonoBehaviour
{
    private Plane plane;
    public Grid grid;
    public bool even = true;

    void Start()
    {
        plane.SetNormalAndPosition(Vector3.up, Vector3.zero);
        GameObjectToGrid();
    }

    void Update()
    {
        GameObjectToGrid();

        if (Input.GetMouseButtonUp(0))
        {
            PlaceObject();
        }
    }

    private void GameObjectToGrid()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float rayDst;
        if (plane.Raycast(ray, out rayDst))
        {
            if (even)
            {
                this.transform.position = grid.SnapToIntersection(ray.GetPoint(rayDst));
            }
            else
            {
                this.transform.position = grid.SnapToGrid(ray.GetPoint(rayDst)); 
            }
        }
    }

    private void PlaceObject()
    {
        //TODO: Set GameObject, Make Grid Unwalkable

        this.enabled = false;
    }
}
