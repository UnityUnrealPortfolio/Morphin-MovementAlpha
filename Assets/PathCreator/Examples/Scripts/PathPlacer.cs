using PathCreation;
using UnityEngine;

namespace PathCreation.Examples {

    [ExecuteInEditMode]
    public class PathPlacer : PathSceneTool {

        public GameObject[] prefab;
        public GameObject holder;
        public float spacing = 3;
        public float maxSpacingDist = 10, minSpacingDist= 2;
        const float minSpacing = .1f;

        void Generate () {
            if (pathCreator != null && prefab != null && holder != null) {
                DestroyObjects ();

                VertexPath path = pathCreator.path;

                spacing = Mathf.Max(minSpacing, maxSpacingDist);
                float dst = 0;

                while (dst < path.length) {
                    int randomModel = Random.Range(0,prefab.Length);
                    Vector3 point = path.GetPointAtDistance (dst);
                    Quaternion rot = path.GetRotationAtDistance (dst);
                    Instantiate(prefab[randomModel], point, rot, holder.transform);
                    spacing = Random.Range(minSpacingDist, maxSpacingDist);
                    dst += spacing;
                }
            }
        }

        void DestroyObjects () {
            int numChildren = holder.transform.childCount;
            for (int i = numChildren - 1; i >= 0; i--) {
                DestroyImmediate (holder.transform.GetChild (i).gameObject, false);
            }
        }

        protected override void PathUpdated () {
            if (pathCreator != null) {
                Generate ();
            }
        }
    }
}