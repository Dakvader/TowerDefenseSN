using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour
{

    public Grid buildGrid;

    public static GameMaster GM;

    void Awake()
    {
        if (GM != null)
        {
            GameObject.Destroy(GM);
        }
        else
        {
            GM = this;
        }

        DontDestroyOnLoad(this);
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            
        }

        if(Input.GetKeyDown(KeyCode.G))
        {
            var newBuilding = (GameObject)Resources.Load("Prefabs\\2x2");
            GameObject go = GameObject.Instantiate(newBuilding, Vector3.zero, Quaternion.identity) as GameObject;
            MousePosition mp = go.GetComponent<MousePosition>();
            mp.enabled = true;
            mp.grid = buildGrid;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            var newBuilding = (GameObject)Resources.Load("Prefabs\\3x3");
            GameObject go = GameObject.Instantiate(newBuilding, Vector3.zero, Quaternion.identity) as GameObject;
            MousePosition mp = go.GetComponent<MousePosition>();
            mp.enabled = true;
            mp.grid = buildGrid;
        }
    }    
}
