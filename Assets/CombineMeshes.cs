using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;

public class CombineMeshes : MonoBehaviour
{

    [Button("Combine")]
    void CombineMeshesByMaterial()
    {
        // Dictionary to store meshes grouped by their material
        Dictionary<Material, List<MeshFilter>> materialGroups = new Dictionary<Material, List<MeshFilter>>();

        // Get all MeshFilters inside this GameObject
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();

        foreach (MeshFilter mf in meshFilters)
        {
            if (mf.sharedMesh == null) continue; // Skip empty meshes

            MeshRenderer renderer = mf.GetComponent<MeshRenderer>();
            if (renderer == null || renderer.sharedMaterial == null) continue; // Skip if no renderer or material

            Material material = renderer.sharedMaterial;

            // Add to corresponding material group
            if (!materialGroups.ContainsKey(material))
            {
                materialGroups[material] = new List<MeshFilter>();
            }
            materialGroups[material].Add(mf);
        }

        // Process each material group separately
        foreach (var entry in materialGroups)
        {
            Material material = entry.Key;
            List<MeshFilter> filters = entry.Value;

            CombineInstance[] combine = new CombineInstance[filters.Count];

            for (int i = 0; i < filters.Count; i++)
            {
                combine[i].mesh = filters[i].sharedMesh;
                combine[i].transform = filters[i].transform.localToWorldMatrix;

                // Disable original objects (optional)
                filters[i].gameObject.SetActive(false);
            }

            // Create new GameObject for the combined mesh
            GameObject combinedObject = new GameObject("Combined_" + material.name);
            combinedObject.transform.SetParent(transform);
            combinedObject.AddComponent<MeshFilter>().mesh = new Mesh();
            combinedObject.GetComponent<MeshFilter>().mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32; // Support large meshes
            combinedObject.GetComponent<MeshFilter>().mesh.CombineMeshes(combine, true, true);

            // Assign material to new MeshRenderer
            MeshRenderer combinedRenderer = combinedObject.AddComponent<MeshRenderer>();
            combinedRenderer.sharedMaterial = material;
        }

        Debug.Log("Meshes Combined by Material! Batches Reduced.");
    }
}
