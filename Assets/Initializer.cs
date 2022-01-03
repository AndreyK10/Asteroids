using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] private GameData GameData;
    [SerializeField] private AsteroidController AsteroidController;
    [SerializeField] private UIController UIController;
    [SerializeField] private Player Player;


    private void Awake()
    {
        UIController.SetBackground(GameData.BackgroundTile);

        Player.SetStats(GameData);

        AsteroidController.InstantiateAsteroids(GameData);


    }


}
