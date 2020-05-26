using UnityEngine;

namespace InputHandlers {
    public static class Raycaster {
        public static void castRay(int layerMask = 0) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hit, float.PositiveInfinity, layerMask)) {
                Transform parent = hit.transform.parent;
                GridController.markNewTileAsActive(parent.name);
            }
        }
    }
}