using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SunData", menuName = "ScriptableObjects/SunData")]
public class SunData : ScriptableObject
{
    [Header("Attributes")]

    [Tooltip("La taille des soleils est soit 0.08m (petit), 0.14m (moyen) ou 0.18m (grand).")]
    public float[] size = new float[3] { 0.08f, 0.14f, 0.18f };
}
