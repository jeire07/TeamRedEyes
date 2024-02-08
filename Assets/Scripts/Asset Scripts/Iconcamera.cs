using UnityEngine;

public class CaptureScreenshot : MonoBehaviour
{
    public Camera cameraToCapture;
    public int width = 256;
    public int height = 256;
    public string savePath = "Assets/Screenshots/screenshot.png";

    void Start()
    {
        RenderTexture renderTexture = new RenderTexture(width, height, 24);
        cameraToCapture.targetTexture = renderTexture;
        Texture2D screenshot = new Texture2D(width, height, TextureFormat.RGB24, false);

        cameraToCapture.Render();
        RenderTexture.active = renderTexture;
        screenshot.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        cameraToCapture.targetTexture = null;
        RenderTexture.active = null;

        byte[] bytes = screenshot.EncodeToPNG();
        System.IO.File.WriteAllBytes(savePath, bytes);
    }
}
