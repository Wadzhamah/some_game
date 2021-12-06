using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour, IWindow
{
    [SerializeField]
    private WindowType type;
    [SerializeField]
    private string key;

    public WindowType Type { get => type; }
    public string Key { get => key;}

    public virtual void Open()
    {
        gameObject.SetActive(true);
    }
    public virtual void Close()
    {
        gameObject.SetActive(false);
    }
}
public enum WindowType
{
    Main,
    LevelSelect,
    Game,
    Win,
}
