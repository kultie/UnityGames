using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputHandle
{

    static List<string> inputQueue = new List<string>();

    public static void UpdateInput()
    {
        HandleKeyDown();
        HandleKeyUp();
    }

    static void HandleKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            inputQueue.Add("Up");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            inputQueue.Add("Down");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            inputQueue.Add("Left");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            inputQueue.Add("Right");
        }
    }

    static void HandleKeyUp()
    {
        if (inputQueue.Count != 0)
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                ReleaseKey("Up");
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                ReleaseKey("Down");
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                ReleaseKey("Left");
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                ReleaseKey("Right");
            }
        }
    }

    static void ReleaseKey(string keyCode)
    {
        inputQueue.RemoveAll(c => c.Equals(keyCode));
    }

    public static string GetLastInput()
    {
        if (inputQueue.Count != 0)
        {
            return inputQueue[inputQueue.Count - 1];
        }
        return string.Empty;
    }

    public static void ClearInputQueue()
    {
        inputQueue.Clear();
    }
}
