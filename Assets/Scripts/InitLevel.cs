using UnityEngine;
using System.Collections;

public class InitLevel : MonoBehaviour {

    public Texture2D levelMap;

    // Einstellungen vom Bild: Texture Type: Advanced.
    // Power of 2: NOne
    // Ganz Unten: Max Size: Max (8192). Format: RGBA 32 Bit
    // Read/Write Enabled: True; Generate Bitmaps: false; Filter Mode: Point (no filter)
    // Rest egal glaube ich

    public void LoadMap(Node[,] grid)
    {
        Color32[] allPixels = levelMap.GetPixels32();
        int width = levelMap.width;
        int height = levelMap.height;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (allPixels[x + (y * width)].Equals(new Color32(0, 0, 0, 255)))
                {
                    grid[width - 1 - x, height -1 - y].walkable = false;
                }
            }
        }
    }
}
