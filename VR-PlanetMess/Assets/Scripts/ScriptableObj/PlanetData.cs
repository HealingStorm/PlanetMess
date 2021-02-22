using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetData", menuName = "ScriptableObjects/PlanetData")]
public class PlanetData : ScriptableObject
{
    [Header("Attributes")]

    [Tooltip("La taille des planète est soit 0.04m (petit), 0.08m (moyen) ou 0.12m (grand).")]
    public float[] size = new float[3] { 0.04f, 0.06f, 0.08f };

    [Tooltip("La température des planètes est soit 'Froide', 'Tempérée' ou 'Chaude'")]
    public Material[] temp = new Material[3];

    [Tooltip("La composition des planètes est soit 'Gazeuse', 'Rocheuse' ou 'Aquatique'")]
    public string[] compo = new string[3] { "Gaseous", "Rocky", "Aquatic" };
}
