using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : MonoBehaviour
{
    public Transform playerTransform;
    public Transform PickUpPosition;
    public Transform counterTopPoint;
    private Transform childTransform;
    private Transform childTransform2;
    private bool isInteracting = false;
    private float currentInteractionTime = 0f;
    private float interactionTime = 4f;
    public GameObject Selected;
    public GameObject CookedMeat;
    public GameObject BurnedMeat;
    public GameObject StartCookingEffect;
    // Start is called before the first frame update

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
                GameObject child = childTransform.gameObject;
                if (counterTopPoint.transform.childCount == 0)
                {
                    if (Input.GetKeyDown(KeyCode.G) && (child.CompareTag("Meat") || (child.CompareTag("CookedMeat"))))
                    {
                        childTransform.transform.position = counterTopPoint.transform.position;
                        childTransform.transform.SetParent(counterTopPoint.transform);
                    }
                }
            }
            if (counterTopPoint.transform.childCount == 1)
            {
                Transform childTransform2 = counterTopPoint.transform.GetChild(0);
                GameObject childObject = childTransform2.gameObject;
                if (PickUpPosition.transform.childCount == 0)
                {
                    if (isInteracting)
                    {
                        // Increment the current interaction time
                        currentInteractionTime += Time.deltaTime;
                        Debug.Log(currentInteractionTime);

                        // Check if the interaction time has been reached
                        if ((currentInteractionTime > 2f && currentInteractionTime < interactionTime) && Input.GetKeyUp(KeyCode.E))
                        {
                                Debug.Log("Coocked!!!");
                                Destroy(childObject);
                                Instantiate(CookedMeat, counterTopPoint);
                                isInteracting = false;
                                currentInteractionTime = 0f;
                        }

                        if (currentInteractionTime > interactionTime && Input.GetKeyUp(KeyCode.E))
                        {
                            Debug.Log("Burned!!!");
                            Destroy(childObject);
                            Instantiate(BurnedMeat, counterTopPoint);
                            isInteracting = false;
                            currentInteractionTime = 0f;

                        }
                    }
                    else
                    {
                        // Check if the player presses the "E" key to start interacting
                        if (Input.GetKeyDown(KeyCode.E) && childObject.CompareTag("Meat"))
                        {
                            // Start interacting
                            isInteracting = true;
                            StartCookingEffect.SetActive(true);
                        }
                    }

                    if (Input.GetKeyUp(KeyCode.E))
                    {
                        // Reset the interaction variables
                        isInteracting = false;
                        currentInteractionTime = 0f;
                        StartCookingEffect.SetActive(false);
                    }
                }

                if (Input.GetKeyDown(KeyCode.F))
                    {
                        childTransform2.transform.position = PickUpPosition.transform.position;
                        childTransform2.transform.SetParent(PickUpPosition.transform);
                    }
                }
            }

        else
        {
            Selected.SetActive(false);
        }
    }
}
