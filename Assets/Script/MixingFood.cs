using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MixingFood : MonoBehaviour
{
    public Transform playerTransform;
    public Transform PickUpPosition;
    public Transform counterTopPoint;
    private Transform childPlayerTransform;
    private Transform childCounterTransform;
    public Transform TomatoPoint;
    public GameObject TomatoSlice;
    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(playerTransform.position, transform.position);
        if (distance <= 2f)
        {
            if (PickUpPosition.transform.childCount == 1)
            {
                Transform childPlayerTransform = PickUpPosition.transform.GetChild(0);
                GameObject childOnPlayer = childPlayerTransform.gameObject;
                if (childOnPlayer.CompareTag("Plate") && counterTopPoint.transform.childCount == 1)
                {
                    Transform childCounterTransform = PickUpPosition.transform.GetChild(0);
                    GameObject childOnCounter = childCounterTransform.gameObject;
                    if (childOnCounter.CompareTag("TomatoSlice") && Input.GetKeyDown(KeyCode.E))
                    {
                        Destroy(childCounterTransform);
                        Instantiate(TomatoSlice, TomatoPoint);
                    }
                }
            }
            if (counterTopPoint.transform.childCount == 1)
            {
                Transform childCounterTransform = PickUpPosition.transform.GetChild(0);
                GameObject childOnCounter = childCounterTransform.gameObject;
            }
        }
    }
}
