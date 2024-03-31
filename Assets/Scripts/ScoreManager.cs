using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static float topScore = -1.0f;
    public static float score = -1.0f;

    public TMP_Text Text;

    public void ScoreEvent(Pose pose)
    {
        if (pose == null) return;
        Debug.LogWarning("Pose = " + pose);
      //  Text.text = pose.ToString();
    }
}