using System.Collections.Generic;
using UnityEngine;

public class Instance_Placer : MonoBehaviour
{
    [SerializeField] List<Mesh> meshes;
    [SerializeField] List<Material> mats;
    private List<Matrix4x4[]> matrices;
    [SerializeField] int numberOfFans = 1000;
    [SerializeField] float range = 20f;
    void Awake()
    {
        matrices = new List<Matrix4x4[]>();
        int total_count_poses = mats.Count * meshes.Count;
        for (int i = 0; i < total_count_poses; i++)
        {
            matrices.Add(new Matrix4x4[numberOfFans / total_count_poses]);

            Vector4[] colors = new Vector4[1];

            for (int j = 0; j < numberOfFans / total_count_poses; j++)
            {
                // Random position and rotation
                Vector3 position = new Vector3(Random.Range(-range, range), 5f, Random.Range(-range, range));
                RaycastHit hit;
                Physics.Raycast(position, Vector3.down, out hit, 5);
                position.y = hit.point.y - 0.45f;
                matrices[i][j] = Matrix4x4.TRS(
                    position,
                    Quaternion.Euler(90, 0, 0),
                    Vector3.one * 2
                );

            }

        }
    }

    void Update()
    {
        for (int j = 0; j < meshes.Count; j++)
        {
            for (int i = 0; i < mats.Count; i++)
            {
                Graphics.DrawMeshInstanced(
                    meshes[j],
                    0,
                    mats[i],
                    matrices[i + mats.Count * j]
                );
            }
        }
    }
}
