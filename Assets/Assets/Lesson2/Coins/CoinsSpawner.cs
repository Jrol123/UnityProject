using UnityEngine;

[DefaultExecutionOrder(100)]
public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] Vector2Int grid;
    [SerializeField] Coin_class probabilities;
    [SerializeField] GameObject Coin;
    [SerializeField] WaveCollaps gridTiles;

    void Awake()
    {
        SpawnCoins();
    }

    void SpawnCoins()
    {
        int y;
        for (int x = 1; x < grid.x; x++)
        {
            for (y = 0; y < grid.y; y++)
            {
                string tileType = gridTiles.gridTypes[x, y];
                float probability = probabilities.GetProbability(tileType);

                if (Random.value < probability)
                {
                    Instantiate(Coin, new Vector3(x, 0.5f, y), transform.rotation).transform.parent = transform;;
                }
            }
        }

        y = 0;

        for (int x = 0; x < grid.x; x++)
        {
            string tileType = gridTiles.gridTypes[x, y];
            float probability = probabilities.GetProbability(tileType);

            if (Random.value < probability)
            {
                Instantiate(Coin, new Vector3(x, 0.5f, y), transform.rotation).transform.parent = transform;;
            }
        }
    }

}
