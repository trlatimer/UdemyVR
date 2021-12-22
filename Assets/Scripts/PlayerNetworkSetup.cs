using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerNetworkSetup : MonoBehaviourPunCallbacks
{
    public GameObject localXRRigGameObject;
    public GameObject AvatarHeadGameObject;
    public GameObject AvatarBodyGameObject;

    void Start()
    {
        if (photonView.IsMine) // Is this me?
        {
            // The player is me
            localXRRigGameObject.SetActive(true);

            SetLayerRecursively(AvatarBodyGameObject, 7);
            SetLayerRecursively(AvatarHeadGameObject, 6);

            TeleportationArea[] teleportationAreas = GameObject.FindObjectsOfType<TeleportationArea>();
            if (teleportationAreas.Length > 0)
            {
                foreach (var item in teleportationAreas)
                {
                    item.teleportationProvider = localXRRigGameObject.GetComponent<TeleportationProvider>();
                }
            }
        }
        else
        {
            // Player is remote
            localXRRigGameObject.SetActive(false);

            SetLayerRecursively(AvatarBodyGameObject, 0);
            SetLayerRecursively(AvatarHeadGameObject, 0);
        }
    }

    void Update()
    {
        
    }

    void SetLayerRecursively(GameObject go, int layerNumber)
    {
        if (go == null) return;
        foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }
}
