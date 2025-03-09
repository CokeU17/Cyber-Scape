using UnityEngine;
using UnityEngine.AI;
using NavMeshPlus.Components;

[RequireComponent(typeof(NavMeshSurface))]
public class NavMeshSurface2D : MonoBehaviour
{
    private NavMeshSurface _navMeshSurface;

    void Awake()
    {
        _navMeshSurface = GetComponent<NavMeshSurface>();

        if (_navMeshSurface != null)
        {
            _navMeshSurface.collectObjects = CollectObjects.All;
            _navMeshSurface.overrideTileSize = true;
            _navMeshSurface.tileSize = 16; // Ajusta seg�n el tama�o de tu grid
            _navMeshSurface.overrideVoxelSize = true;
            _navMeshSurface.voxelSize = 0.1f; // Ajusta seg�n la precisi�n deseada
        }
    }

    public void BakeNavMesh()
    {
        if (_navMeshSurface != null)
        {
            _navMeshSurface.BuildNavMesh();
        }
    }

    private void Start()
    {
        BakeNavMesh();
    }
}
