using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image[] _backgroundTiles;

    public void SetBackground(Sprite sprite)
    {
        foreach (var item in _backgroundTiles)
        {
            item.sprite = sprite;
        }
    }




}
