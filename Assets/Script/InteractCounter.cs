using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class InteractCounter : MonoBehaviour
{
    public Transform playerTransform;
    public Transform counterTopPoint;
    public Transform PickUpPosition;
    private Transform childTransform2;
    private Transform childTransform;
    public GameObject food;
    public GameObject Selected;
    public GameObject Ui_E;
    public GameObject Ui_F;
    public GameObject Ui_G;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(playerTransform.position, transform.position);
        if (distance <= 2f)
        {
            Selected.SetActive(true);
            if (counterTopPoint.transform.childCount == 0)
            {
                Ui_E.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    animator.SetTrigger("On");
                    Instantiate(food, counterTopPoint);
                }
                    if (PickUpPosition.transform.childCount == 1)
                    {
                        Transform childTransform = PickUpPosition.transform.GetChild(0);
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
                    Ui_E.SetActive(false);
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
            Ui_E.SetActive(false);
            Ui_F.SetActive(false);
            Ui_G.SetActive(false);
        }
    }
}
