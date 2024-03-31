using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;

#if UNITY_INCLUDE_ARFOUNDATION
using UnityEngine.XR.ARFoundation;
#endif

#if UNITY_INCLUDE_ARFOUNDATION
    [RequireComponent(typeof(ARPlane))]
#endif
public class HackathonPlane : MonoBehaviour
{
    [SerializeField] private GameObject m_Fire;
    
    [ContextMenu("toggle fire")]
    public void ToggleFire()
    {
        m_Fire.SetActive(!m_Fire.activeSelf);
    }
#if UNITY_INCLUDE_ARFOUNDATION || true
    ARPlane m_Plane;

    void OnEnable()
    {
        m_Plane = GetComponent<ARPlane>();
        m_Plane.boundaryChanged += OnBoundaryChanged;
    }

    void OnDisable()
    {
        m_Plane.boundaryChanged -= OnBoundaryChanged;
    }

    void OnBoundaryChanged(ARPlaneBoundaryChangedEventArgs eventArgs)
    {
/*
        m_ClassificationText.text = m_Plane.classification.ToString();
        m_AlignmentText.text = m_Plane.alignment.ToString();
*/
        transform.position = m_Plane.center;
    }
#endif
}