using System;
using TMPro;
using UnityEngine.XR.Hands.Gestures;

namespace UnityEngine.XR.Hands.Samples.Gestures.DebugTools
{
    /// <summary>
    /// Updates the text label that denotes the currently detected hand gesture
    /// </summary>
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class XRSelectedHandShapeDebugUI : MonoBehaviour
    {
        /// <summary>
        /// The string displayed when no gesture is detected
        /// </summary>
        const string k_NoGestureDetectedString = "";

        float score = -1;
        float topscore = -1;

        [SerializeField]
        [Tooltip("The label that will be used to display the name of the hand shape.")]
        TextMeshProUGUI m_HandShapeNameLabel;

        [SerializeField]
        [Tooltip("The score")]
        TextMeshProUGUI m_Score;

        [SerializeField]
        [Tooltip("Object to enable")]
        GameObject m_flame;

        /// <summary>
        /// The text label that denotes and displays the currently detected hand gesture
        /// </summary>
        public TextMeshProUGUI handShapeNameLabel
        {
            get => m_HandShapeNameLabel;
            set => m_HandShapeNameLabel = value;
        }

        void Start()
        {
            m_HandShapeNameLabel.text = k_NoGestureDetectedString;
        }

        string previousText = "";

        private int timeinseconds = 0;
        private DateTime scoretime;
        private TimeSpan finalTiming;

        private DateTime tp1;
        /// <summary>
        /// Update the text label that denotes the currently detected hand gesture
        /// </summary>
        /// <param name="handPoseOrShape">The pose or shape whose name will be displayed</param>
        public void UpdateSelectedHandshapeTextUI(ScriptableObject handPoseOrShape)
        {
            var handShape = handPoseOrShape as XRHandShape;
            var handPose = handPoseOrShape as XRHandPose;

            if (handShape)
            {
                m_HandShapeNameLabel.text = handShape.name;
                Debug.LogWarning("===> new shape=" + m_HandShapeNameLabel.text);
            }
            else if (handPose)
            {
                m_HandShapeNameLabel.text = handPose.name;
                Debug.LogWarning("===> new pose=" + m_HandShapeNameLabel.text);
                Debug.LogWarning("===> prev pose=" + previousText);
               // if (m_HandShapeNameLabel.text.Equals("Thumbs Up"))
              //  {
               //     Debug.LogWarning("===> reset time");
               //     scoretime = DateTime.Now;
               // }
                if (m_HandShapeNameLabel.text.Equals("Thumbs Up"))
                {
                    m_flame.SetActive(true);
                //    finalTiming = DateTime.Now - scoretime;
                //    timeinseconds = finalTiming.Seconds;
                //    m_Score.text = "Score: " + timeinseconds;
                //    Debug.LogWarning("===> score=" + timeinseconds);
                }
                else if (m_HandShapeNameLabel.text.Equals("Open Palm Up")) 
                {
                    m_flame.SetActive(false);
                }
                previousText = m_HandShapeNameLabel.text;
            }
        }

        /// <summary>
        /// Update the text label that denote that no hand gesture is currently detected
        /// </summary>
        public void ResetUI()
        {
            m_HandShapeNameLabel.text = k_NoGestureDetectedString;
        }
    }
}
