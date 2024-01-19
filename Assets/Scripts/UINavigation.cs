using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UINavigation : MonoBehaviour
{
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private Button continueButton;
    [SerializeField] private Transform scrollview;
    [SerializeField] private string debugTag;
    [SerializeField] private bool didFix;
    private void Awake()
    {
        // Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Debug.Log();
        FixUINavigation();
        
    }

    public void FixUINavigation()
    {
        if (!IsAnyChildObjectWithTagActive())
        {
            Debug.Log("kaas");
            eventSystem.SetSelectedGameObject(continueButton.gameObject);
            didFix = false;
        }
        else
        {
            GameObject tmp = null;
            
            Transform[] childTransforms = scrollview.GetComponentsInChildren<Transform>(true);
            foreach (Transform childTransform in childTransforms)
            {
                if (childTransform != scrollview) // Exclude the parent itself
                {
                    GameObject childObject = childTransform.gameObject;

                    if (!childObject.CompareTag(debugTag) || !childObject.activeSelf) continue;
                    tmp = childObject;
                    break;
                }
            }

            if (tmp != null && !didFix)
            {
                eventSystem.SetSelectedGameObject(tmp);
                didFix = true;
            }
        }

    }
    
    public bool IsAnyChildObjectWithTagActive()
    {
        if (scrollview == null)
        {
            Debug.LogWarning("Parent object not assigned.");
            return false;
        }

        // Find children with the specified tag
        Transform[] childTransforms = scrollview.GetComponentsInChildren<Transform>(true);

        foreach (Transform childTransform in childTransforms)
        {
            if (childTransform != scrollview) // Exclude the parent itself
            {
                GameObject childObject = childTransform.gameObject;

                if (childObject.CompareTag(debugTag) && childObject.activeSelf)
                {
                    return true; // At least one active child with the specified tag found
                }
            }
        }

        return false; // No active child with the specified tag found
    }
}