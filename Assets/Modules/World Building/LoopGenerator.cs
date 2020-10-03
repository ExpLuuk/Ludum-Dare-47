using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExpPlus.LD47.WorldBuilding {

    public class LoopGenerator : MonoBehaviour {

        [Tooltip("The image used to generate the loop.")]
        public Texture2D mapBluepring;

        [Tooltip("This value can be used to control the scaling of the pixels. Scaling down a big loop can make for a higher resolution loop")]
        public float mapScaling = 1;

        public GameObject defaultPrefab;
        public List<ColorPrefabCombo> legend = new List<ColorPrefabCombo>();

        [ContextMenu("Generate Loop")]
        private void GenerateLoop() {

            DestroyImmediate(GameObject.Find("Loop"));

            GameObject parent = new GameObject("Loop");

            for(int y =0; y < mapBluepring.height; y++) {

                for(int x = 0; x < mapBluepring.width; x++) {

                    Color pixelColor = mapBluepring.GetPixel(x, y);

                    if (pixelColor.a > 0) {

                        GameObject prefabToSpawn = GetPrefabForColor(pixelColor);

                        if (prefabToSpawn == null)
                            prefabToSpawn = defaultPrefab;

                        GameObject cube = Instantiate(prefabToSpawn);

                        cube.name = "Loop_Pixel_" + x + "_" + y; 
                        cube.transform.position = new Vector3(x*mapScaling, y*mapScaling);
                        cube.transform.localScale = cube.transform.localScale * mapScaling;
                        cube.transform.SetParent(parent.transform);
                    }
                }
            }
        }

        private GameObject GetPrefabForColor(Color color) {

            for(int i =0; i < legend.Count; i++) {

                if (legend[i].color == color)
                    return legend[i].prefab;
            }

            return null;
        }
    }
}