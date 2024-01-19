using UnityEngine;
using UnityEngine.InputSystem;

public class ScreenActivation : PlayerInputManager
{
    private void Start() {
        playerJoinedEvent.AddListener(SetPlayerMonitor);
        Display.displays[0].Activate();
        Display.displays[1].Activate();
    }

    private static void SetPlayerMonitor(PlayerInput arg0)
    {
        Debug.Log($"Set player monitor: {arg0.playerIndex}, Displays: {Display.displays.Length}, {arg0.GetComponentsInChildren<Canvas>().Length}");

        arg0.camera.targetDisplay = arg0.playerIndex;
        arg0.GetComponentInChildren<Canvas>().targetDisplay = arg0.playerIndex;
    }
}