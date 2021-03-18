using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlanetScript : MonoBehaviour
{
    [HideInInspector]
    public bool interactionSecurity;
    public void OnPlanetDrop()
    {
        interactionSecurity = true;
    }

    private void OnTriggerStay(Collider other)
    {
        //Snap des planètes sur un orbite//

        //sécurité
        if (interactionSecurity == true)
        {
            if (other.gameObject.tag == "SmallOrbit")
            {
                Transform smallOrbitTransform = other.transform.parent.parent.Find("Small Orbit Planet").transform;
                //Si on a aucun enfant on peut placer la planète qui a collidé
                if (smallOrbitTransform.childCount == 0)
                {
                    Debug.Log("OnSmallOrbit");
                    transform.parent = smallOrbitTransform;
                    transform.position = new Vector3(smallOrbitTransform.position.x, smallOrbitTransform.position.y, smallOrbitTransform.position.z);
                }
            }
            if (other.gameObject.tag == "MediumOrbit")
            {
                Transform mediumOrbitTransform = other.transform.parent.parent.Find("Medium Orbit Planet").transform;
                //Si on a aucun enfant on peut placer la planète qui a collidé
                if (mediumOrbitTransform.childCount == 0)
                {
                    Debug.Log("OnMediumOrbit");
                    transform.parent = mediumOrbitTransform;
                    transform.position = new Vector3(mediumOrbitTransform.position.x, mediumOrbitTransform.position.y, mediumOrbitTransform.position.z);
                }
            }
            if (other.gameObject.tag == "BigOrbit")
            {
                Transform bigOrbitTransform = other.transform.parent.parent.Find("Big Orbit Planet").transform;
                //Si on a aucun enfant on peut placer la planète qui a collidé
                if (bigOrbitTransform.childCount == 0)
                {
                    Debug.Log("OnBigOrbit");
                    transform.parent = bigOrbitTransform;
                    transform.position = new Vector3(bigOrbitTransform.position.x, bigOrbitTransform.position.y, bigOrbitTransform.position.z);
                }
            }
            interactionSecurity = false;
        }
        
    }
}
