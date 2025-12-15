using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius = 0.5f;
    public float chunkSize = 20f;
    public LayerMask terrainMask;

    Vector3 noTerrainPosition;
    PlayerMovement pm;

    void Awake()
    {
        pm = FindFirstObjectByType<PlayerMovement>(); // Unity 6
        // Mejor aún: [SerializeField] PlayerMovement pm; y lo asignas en Inspector.
    }

    void Update()
    {
        ChunkChecker();
    }

    void ChunkChecker()
    {
        if (pm == null || player == null) return;

        Vector2 dir = pm.moveDir;
        if (dir.sqrMagnitude < 0.0001f) return;

        // Convertimos a dirección -1/0/1 para soportar analógico
        int sx = (Mathf.Abs(dir.x) > 0.1f) ? (dir.x > 0 ? 1 : -1) : 0;
        int sy = (Mathf.Abs(dir.y) > 0.1f) ? (dir.y > 0 ? 1 : -1) : 0;

        if (sx == 0 && sy == 0) return;

        Vector3 offset = new Vector3(sx * chunkSize, sy * chunkSize, 0f);
        Vector3 checkPos = player.transform.position + offset;

        // IMPORTANTE: spawn cuando NO hay terreno
        if (Physics2D.OverlapCircle(checkPos, checkerRadius, terrainMask) == null)
        {
            noTerrainPosition = checkPos;
            SpawnChunk();
        }
    }

    void SpawnChunk()
    {
        if (terrainChunks == null || terrainChunks.Count == 0) return;
        int rand = Random.Range(0, terrainChunks.Count);
        Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);
    }
}
