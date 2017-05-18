using UnityEngine;

namespace Assets.Scripts
{
    public class DebugController : MonoBehaviour
    {
        public void OnGUI()
        {
            GUI.color = Color.red;
            GUI.Label(new Rect(10, 30, 100, 100), GameScreenController.ActiveGameScreen.ToString());
        }
    }
}
