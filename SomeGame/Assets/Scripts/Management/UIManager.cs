using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    [SerializeField]
    private List<Window> windows;

    public static UIManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

    }

    public void OpenWindow(WindowType type)
    {
        Window foundWindow = windows.Find(window => window.Type == type);
        if (foundWindow != null)
        {
            foundWindow.Open();
        }
    }

    public void CloseWindow(WindowType type)
    {
        Window foundWindow = windows.Find(window => window.Type == type);
        if (foundWindow != null)
        {
            CloseWindow(foundWindow);
        }
    }

    public void CloseWindow(Window window)
    {
        window.Close();
    }
}
