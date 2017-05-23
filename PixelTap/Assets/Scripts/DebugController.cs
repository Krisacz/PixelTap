using UnityEngine;

namespace Assets.Scripts
{
    [ExecuteInEditMode]
    public class DebugController : MonoBehaviour
    {
        public void OnGUI()
        {
            GUI.color = Color.red;
            GUI.Label(new Rect(10, 30, 100, 100), GameController.ActiveGameScreen.ToString());
            if (GUI.Button(new Rect(10, 47, 50, 15), "Reset")) GameSave.Reset();
        }
    }
}
