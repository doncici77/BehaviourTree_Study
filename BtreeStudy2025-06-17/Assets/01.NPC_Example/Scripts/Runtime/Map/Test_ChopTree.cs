using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_ChopTree : MonoBehaviour
{
    [SerializeField] Terrain _terrain;
    [SerializeField] GameObject _stumpPrefab;
    [SerializeField] LayerMask _terrainMask;
    TerrainData _data;

    private void Awake()
    {
        _data = _terrain.terrainData;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryChop();
        }
    }

    void TryChop()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit, float.PositiveInfinity, _terrainMask))
        {
            Debug.Log($"Hit {hit.collider.gameObject.name}");

            int index = FindTreeIndex(hit.point, 0.001f);

            if (index < 0)
                return;

            TreeInstance removed = _data.GetTreeInstance(index);
            RemoveTree(index);

            Instantiate(_stumpPrefab,
                        TerrainLocalToWorld(removed.position),
                        Quaternion.Euler(0, Random.Range(0, 360f), 0));
        }
    }

    void RemoveTree(int index)
    {
        List<TreeInstance> trees = new List<TreeInstance>(_data.treeInstances);
        trees.RemoveAt(index);
        _data.SetTreeInstances(trees.ToArray(), true);

        /*TreeInstance tree = _data.GetTreeInstance(index);
        tree.prototypeIndex = 1;
        _data.SetTreeInstance(index, tree);*/
    }

    int FindTreeIndex(Vector3 worldPos, float maxDistance)
    {
        Vector3 terrainPos = worldPos - _terrain.transform.position;

        Vector3 terrainPosNormalizedXZ = new Vector3(terrainPos.x / _data.size.x,
                                                   0f,
                                                   terrainPos.z / _data.size.z);

        TreeInstance[] instances = _data.treeInstances;
        int nearestIndex = -1;
        float nearestDistance = maxDistance * maxDistance;

        for (int i = 0; i < instances.Length; i++)
        {
            Vector2 deltaPos = new Vector2(instances[i].position.x - terrainPosNormalizedXZ.x, 
                                           instances[i].position.z - terrainPosNormalizedXZ.z);

            float sq = deltaPos.sqrMagnitude * _data.size.x * _data.size.z;

            if (sq < nearestDistance)
            {
                nearestDistance = sq; 
                nearestIndex = i;
            }
        }

        return nearestIndex;
    }

    Vector3 TerrainLocalToWorld(Vector3 nomalizedPos)
    {
        Vector3 pos = Vector3.Scale(nomalizedPos, _data.size);
        pos.y = _terrain.SampleHeight(pos) + _terrain.transform.position.y;
        return pos + _terrain.transform.position;
    }
}
