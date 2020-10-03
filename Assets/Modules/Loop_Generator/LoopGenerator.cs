using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExpPlus.LD47.WorldBuilding {

    public class LoopGenerator : MonoBehaviour {

        [Tooltip("The image used to generate the loop.")]
        public Texture2D blueprint;
        public GameObject pixelPrefab;
        public float scaling = 1;

        [ContextMenu("Generate Loop")]
        private void GenerateLoop() {

            GameObject parent = new GameObject("Loop");

            for(int y =0; y < blueprint.height; y++) {

                for(int x = 0; x < blueprint.width; x++) {

                    if(blueprint.GetPixel(x,y).a == 1) {

                        GameObject cube = Instantiate(pixelPrefab);
                        cube.name = "Loop_Pixel_" + x + "_" + y; 
                        cube.transform.position = new Vector3(x*scaling, y*scaling);
                        cube.transform.localScale = cube.transform.localScale * scaling;
                        cube.transform.SetParent(parent.transform);
                    }
                }
            }
        }
    }
}