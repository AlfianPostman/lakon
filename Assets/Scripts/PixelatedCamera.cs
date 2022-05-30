using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PixelatedCamera : MonoBehaviour
{
    public enum PixelScreenMode { Resize, Scale }

    [System.Serializable]
    public struct ScreenSize
    {
        // Basically an integer Vector2 to store screen size information
        public float width;
        public float height;
    }

    public static PixelatedCamera main;

    private Camera renderCamera;
    private RenderTexture renderTexture;
    private int screenWidth, screenHeight;

    [Header("Screen scaling settings")]
    public PixelScreenMode mode;
    public ScreenSize targetScreenSize = new ScreenSize { width = 256f, height = 144f };  // Only used with PixelScreenMode.Resize
    public float screenScaleFactor = 1f;  // Only used with PixelScreenMode.Scale

    
    [Header("Display")]
    public RawImage display;

    private void Awake()
    {
        // Try to set as main pixel camera
        if (main == null) main = this;
    }

    private void Start()
    {
        // Initialize the system
        Init();
    }

    private void Update()
    {
        // Re initialize system if the screen has been resized
        if (CheckScreenResize()) Init();
    }

    public void Init() {

        // Initialize the camera and get screen size values
        if (!renderCamera) renderCamera = GetComponent<Camera>();
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        // Prevent any error
        if (screenScaleFactor < 1f) screenScaleFactor = 1f;
        if (targetScreenSize.width < 1f) targetScreenSize.width = 1f;
        if (targetScreenSize.height < 1f) targetScreenSize.height = 1f;

        // Calculate the render texture size
        float width = mode == PixelScreenMode.Resize ? (float)targetScreenSize.width : screenWidth / (float)screenScaleFactor;
        float height = mode == PixelScreenMode.Resize ? (float)targetScreenSize.height : screenHeight / (float)screenScaleFactor;

        // Initialize the render texture
        renderTexture = new RenderTexture((int)width, (int)height, 24) {
            filterMode = FilterMode.Point,
            antiAliasing = 1
        };

        // Set the render texture as the camera's output
        renderCamera.targetTexture = renderTexture;

        // Attaching texture to the display UI RawImage
        display.texture = renderTexture;
    }

    public bool CheckScreenResize() {
        // Check whether the screen has been resized
        return Screen.width != screenWidth || Screen.height != screenHeight;
    }
}