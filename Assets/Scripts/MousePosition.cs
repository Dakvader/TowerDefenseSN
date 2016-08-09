using UnityEngine;
using System.Collections;

public class MousePosition : MonoBehaviour {

    public Plane plane;

    public Grid grid;

    void Awake()
    {
       plane.SetNormalAndPosition(Vector3.up, Vector3.zero);
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float rayDst;
        if(plane.Raycast(ray, out rayDst))
        {
            // this.transform.position = ray.GetPoint(rayDst);
            this.transform.position = grid.SnapToGrid(ray.GetPoint(rayDst));
        }
    }
}
