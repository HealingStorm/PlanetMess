using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetData", menuName = "ScriptableObjects/PlanetData")]
public class PlanetData : ScriptableObject
{
    [Header("Attributes")]

    [Tooltip("La taille des plan�te est soit 0.04m (petit), 0.08m (moyen) ou 0.12m (grand).")]
    public float[] size = new float[3] { 0.04f, 0.08f, 0.12f };

    [Tooltip("La temp�rature des plan�tes est soit 'Froide', 'Temp�r�e' ou 'Chaude'")]
    public Material[] temperature = new Material[3];

    [Tooltip("La composition des plan�tes est soit 'Gazeuse', 'Rocheuse' ou 'Aquatique'")]
    public string[] composition = new string[3] { "Gaseous", "Rocky", "Aquatic" };
}
