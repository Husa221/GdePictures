using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FmodsEvents : MonoBehaviour
{
    public static FmodsEvents instance {  get; private set; }

    [field: Header("WallSfx")]
    [field: SerializeField] public EventReference wallInTheWay {  get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one FMODEvents instance in the scene.");
        }
        instance = this;
    }
}
