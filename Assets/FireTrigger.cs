using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(UDP_Listener))]
public class FireTrigger : MonoBehaviour
{
    private UDP_Listener m_UdpListener;
    //[SerializeField] private GameObject m_Confetti;
    void Start()
    {
        m_UdpListener = GetComponent<UDP_Listener>();
        
        UDP_Listener.OnShoot += OnShoot;
    }

    private void OnShoot(Pose poseShot)
    {
        var planes = FindObjectsOfType<HackathonPlane>();
        foreach (var plane in planes)
        {
            if (plane == null) continue;
            plane.ToggleFire();
        }
        //HackathonPlane.OnFireTriggered?.Invoke();
        //m_Confetti.SetActive(!m_Confetti.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
