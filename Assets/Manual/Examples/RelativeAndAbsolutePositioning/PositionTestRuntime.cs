using UnityEngine;
using UnityEngine.UIElements;

namespace Manual.Examples.RelativeAndAbsolutePositioning
{
    public class PositioningTestRuntime : MonoBehaviour
    {
        private void OnEnable()
        {
            GetComponent<UIDocument>();
        }
    }
}
