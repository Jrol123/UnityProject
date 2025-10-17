using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CoinTilePair
{
    public GameObject tile;
    [Range(0f, 1f)]
    public float probability;
}

[CreateAssetMenu(fileName = "CoinTilesPair", menuName = "Scriptable Objects/CoinTilesPair")]
public class Coin_class : ScriptableObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Probability of spawning on tiles")]
    [SerializeField] List<CoinTilePair> probabilities;
    public List<CoinTilePair> Probability
    {
        get => probabilities;
    }

    public String Name
    {
        get => name;
    }

    /// <summary>
    /// Получение вероятности заспавниться на тайле
    /// </summary>
    /// <param name="typeName">Название типа тайла</param>
    /// <returns>Вероятность заспавниться на тайле</returns>
    public float GetProbability(string typeName)
    {
        var pair = probabilities.Find(x => x.tile.name == typeName);
        return pair.probability;
    }
}
