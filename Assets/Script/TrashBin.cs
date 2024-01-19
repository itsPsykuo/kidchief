using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject Selected;
    public Transform PickUpPosition;
    private Transform childTransform;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(playerTransform.position, transform.position);
        if (distance <= 2f)
        {
            Selected.SetActive(true);
            if (PickUpPosition.transform.childCount >= 1)
            {
                Transform childTransform = PickUpPosition.transform.GetChild(0);
                GameObject childObject = childTransform.gameObject;
                {
                    if (Input.GetKeyDown(KeyCode.G))
                    {
                        Destroy(childObject);
                    }
                }
            }
        }
        else
        {
            Selected.SetActive(false);
        }
    }
}
