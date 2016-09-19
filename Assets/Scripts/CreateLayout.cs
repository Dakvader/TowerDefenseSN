using UnityEngine;
using System.Collections;

public class CreateLayout : MonoBehaviour {
    public Transform parent;

    void Start()
    {
        GameObject node = (GameObject)Resources.Load("Prefabs/Node");
        GameObject hor = (GameObject)Resources.Load("Prefabs/Horizontal");
        GameObject ver = (GameObject)Resources.Load("Prefabs/Vertical");
        GameObject crossleft = (GameObject)Resources.Load("Prefabs/CrossLeft");
        GameObject crossright = (GameObject)Resources.Load("Prefabs/CrossRight");

        for (int x = 0; x < 25; x++)
        {
            for (int y = 0; y < 25; y++)
            {
                InstantiateGO("Node_" + y + "_" + x, new Vector2(x, y), node);

                if (x < 24)
                {
                    InstantiateGO("Horizontal" + y + "_" + x, new Vector2(x + 0.5f, y), hor);
                }
                if (y < 24)
                {
                    InstantiateGO("Vertical" + y + "_" + x, new Vector2(x, y + 0.5f), ver);
                    if (x < 24)
                    {
                        InstantiateGO("CrossLeft_" + y + "_" + x, new Vector2(x + 0.5f, y + 0.5f), crossleft);
                        InstantiateGO("CrossRight_" + y + "_" + x, new Vector2(x + 0.5f, y + 0.5f), crossright);
                    }
                }
            }
        }
    }

    private void InstantiateGO(string name, Vector2 position, GameObject model)
    {
        var go = (GameObject)Instantiate(model, position, Quaternion.identity);
        go.name = name;
        go.transform.parent = parent;
    }

}
