using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SelectedCounter : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject Selected;
    public Transform PickUpPosition;
    public Transform counterTopPoint;
    private Transform childTransform;
    private Transform childTransform2;
    public GameObject Ui_F;
    public GameObject Ui_G;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(playerTransform.position, transform.position);
        if (distance <= 2f)
        {
            Selected.SetActive(true);
            if (PickUpPosition.transform.childCount == 1)
            {
                Transform childTransform = PickUpPosition.transform.GetChild(0);
                if (counterTopPoint.transform.childCount == 0)
                {
                    Ui_G.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.G))
                    {
                        childTransform.transform.position = counterTopPoint.transform.position;
                        childTransform.transform.SetParent(counterTopPoint.transform);
                        Ui_G.SetActive(false);
                    }
                }
            }
            if (counterTopPoint.transform.childCount == 1)
            {
                Transform childTransform2 = counterTopPoint.transform.GetChild(0);
                if (PickUpPosition.transform.childCount == 0)
                {
                    Ui_F.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        childTransform2.transform.position = PickUpPosition.transform.position;
                        childTransform2.transform.SetParent(PickUpPosition.transform);
                        Ui_F.SetActive(false);
                    }
                }
            }
        }
        else
        {
            Selected.SetActive(false);
            Ui_F.SetActive(false);
            Ui_G.SetActive(false);
        }
    }
}
