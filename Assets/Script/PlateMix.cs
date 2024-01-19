using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateMix : MonoBehaviour
{
    public Transform TomatoPoint;
    public Transform CheesePoint;
    public Transform BreadPoint;
    public Transform MeatPoint;
    private GameObject TomatoSlice;
    private GameObject CheeseSlice;
    private GameObject Bread;
    private GameObject CookedMeat;
    private GameObject PickUpPosition;
    private GameObject BurgerBread;
    // Update is called once per frame
    void Update()
    {
        TomatoOnPlate();
        CheeseOnPlate();
        MeatOnPlate();
        BreadOnPlate();
    }

    private void TomatoOnPlate()
    {
        GameObject TomatoSlice = GameObject.FindWithTag("TomatoSlice");
        GameObject PickUpPosition = GameObject.FindWithTag("PickUpPosition");
        if (TomatoSlice != null && gameObject != null)
        {
            float distance = Vector3.Distance(TomatoSlice.transform.position, gameObject.transform.position);
            if (distance < 2.5f)
            {
                if (gameObject.transform.IsChildOf(PickUpPosition.transform))
                {
                    Debug.Log("Yes The Plate Is on Your Hand!");
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Destroy(TomatoSlice);
                        Instantiate(TomatoSlice, TomatoPoint);
                    }
                }
            }
        }
    }

    private void CheeseOnPlate()
    {
        GameObject CheeseSlice = GameObject.FindWithTag("CheeseSlice");
        GameObject PickUpPosition = GameObject.FindWithTag("PickUpPosition");
        if (CheeseSlice != null && gameObject != null)
        {
            float distance = Vector3.Distance(CheeseSlice.transform.position, gameObject.transform.position);
            if (distance < 2.5f)
            {
                if (gameObject.transform.IsChildOf(PickUpPosition.transform))
                {
                    Debug.Log("Yes The Plate Is on Your Hand!");
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Destroy(CheeseSlice);
                        Instantiate(CheeseSlice, CheesePoint);
                    }
                }
            }
        }
    }

    private void MeatOnPlate()
    {
        GameObject CookedMeat = GameObject.FindWithTag("CookedMeat");
        GameObject PickUpPosition = GameObject.FindWithTag("PickUpPosition");
        if (CookedMeat != null && gameObject != null)
        {
            float distance = Vector3.Distance(CookedMeat.transform.position, gameObject.transform.position);
            if (distance < 2.5f)
            {
                if (gameObject.transform.IsChildOf(PickUpPosition.transform))
                {
                    Debug.Log("Yes The Plate Is on Your Hand!");
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Destroy(CookedMeat);
                        Instantiate(CookedMeat, MeatPoint);
                    }
                }
            }
        }
    }

    private void BreadOnPlate()
    {
        GameObject Bread = GameObject.FindWithTag("Bread");
        GameObject PickUpPosition = GameObject.FindWithTag("PickUpPosition");
        if (Bread != null && gameObject != null)
        {
            float distance = Vector3.Distance(Bread.transform.position, gameObject.transform.position);
            if (distance < 2.5f)
            {
                if (gameObject.transform.IsChildOf(PickUpPosition.transform))
                {
                    Debug.Log("Yes The Plate Is on Your Hand!");
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Destroy(Bread);
                        Instantiate(Bread, BreadPoint);
                    }
                }
            }
        }
    }
}
