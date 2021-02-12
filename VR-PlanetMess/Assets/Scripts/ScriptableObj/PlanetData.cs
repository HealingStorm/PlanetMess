using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetData", menuName = "ScriptableObjects/PlanetData")]
public class PlanetData : ScriptableObject
{
    [Header("Attributes")]

    [Tooltip("La taille des planète est soit 0.05m (petit), 0.1m (moyen) ou 0.15m (grand).")]
    public float[] size = new float[3] { 0.05f, 0.1f, 0.15f };

    [Tooltip("La température des planètes est soit 'Froide', 'Tempérée' ou 'Chaude'")]
    public Material[] temperature = new Material[3];

    [Tooltip("La composition des planètes est soit 'Gazeuse', 'Rocheuse' ou 'Aquatique'")]
    public string[] composition = new string[3] { "Gaseous", "Rocky", "Aquatic" };
}
