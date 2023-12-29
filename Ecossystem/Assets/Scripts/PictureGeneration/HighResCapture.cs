using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class HighResCapture : MonoBehaviour
{
    public Camera captureCamera; // Make sure this is an orthographic camera
    public RenderTexture renderTexture;
    private string downloadsFolderPath;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        
        if (Input.GetKeyDown(KeyCode.S)) // You can change the condition to trigger the capture
        {
            downloadsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            captureCamera.targetTexture = renderTexture;
            string fileName = "my_image.png"; // Change the file name and format as needed
            string filePath = Path.Combine(downloadsFolderPath, fileName);

            RenderTexture.active = renderTexture;

            Texture2D capture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            capture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            capture.Apply();

            byte[] bytes = capture.EncodeToPNG(); // or EncodeToJPG() for JPEG
            File.WriteAllBytes(filePath, bytes);

            RenderTexture.active = null;
        }
    }
}
