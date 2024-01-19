using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutting : MonoBehaviour
{
    public Transform playerTransform;
    public Transform PickUpPosition;
    public Transform counterTopPoint;
    private Transform childTransform;
    private Transform childTransform2;
    public GameObject Selected;
    public GameObject TomatoSlice;
    public GameObject CheeseSlice;
    private GameObject childObject;
    private float CountTouch = 0f;
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
            // DRAG
            if (PickUpPosition.transform.childCount == 1)
            {
                Transform childTransform = PickUpPosition.transform.GetChild(0);
                GameObject child = childTransform.gameObject;
                if (counterTopPoint.transform.childCount == 0 && (child.CompareTag("Tomato") || child.CompareTag("Cheese")))
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
            // PickUp
            if (counterTopPoint.transform.childCount == 1)
            {
                Transform childTransform2 = counterTopPoint.transform.GetChild(0);
                GameObject childObject = childTransform2.gameObject;
                if (childObject.CompareTag("Tomato") || childObject.CompareTag("Cheese"))
                {
                    Ui_E.SetActive(true);
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (childObject.CompareTag("Tomato"))
                    {
                        CountTouch++;
                        Debug.Log(CountTouch);
                        animator.SetTrigger("Cut");
                        if (CountTouch == 3f)
                        {
                            Destroy(childObject);
                            Instantiate(TomatoSlice, counterTopPoint);
                            Ui_E.SetActive(false);
                            CountTouch = 0f;
                        }
                    }

                    if (childObject.CompareTag("Cheese"))
                    {
                        CountTouch++;
                        Debug.Log(CountTouch);
                        animator.SetTrigger("Cut");
                        if (CountTouch == 3f)
                        {
                            Destroy(childObject);
                            Instantiate(CheeseSlice, counterTopPoint);
                            Ui_E.SetActive(false);
                            CountTouch = 0f;
                        }
                    }

                }
                if (PickUpPosition.transform.childCount == 0)
                {
                    if (!childObject.CompareTag("Tomato") && !childObject.CompareTag("Cheese"))
                    {
                        Ui_F.SetActive(true);
                    }
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
            Ui_G.SetActive(false);
            Ui_F.SetActive(false);
            Ui_E.SetActive(false);
        }
    }
}

