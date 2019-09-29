using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class GameImputManager
{
    public static Dictionary<KeyCode, KeyCode> keyMapping;
    public static KeyCode[] keyMovsP1 = new KeyCode[4] { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D };
    public static KeyCode[] keysP1 = new KeyCode[4] { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D };

    public static KeyCode[] keyMovsP2 = new KeyCode[4] { KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow };
    public static KeyCode[] keysP2 = new KeyCode[4] { KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow };

    static GameImputManager()
    {
        InitKeys();
        Debug.Log("keys ready");
    }

    private static void InitKeys()
    {
        keyMapping = new Dictionary<KeyCode, KeyCode>();

        for (int i = 0; i < keysP1.Length; ++i)
        {
            keyMapping.Add(keysP1[i], keyMovsP1[i]);
        }

        for (int i = 0; i < keysP2.Length; ++i)
        {
            keyMapping.Add(keysP2[i], keyMovsP2[i]);
        }
        randomiseKeys();
        ShowKeys();
    }

    static void randomiseKeys()
    {
        List<KeyCode> usedValues = new List<KeyCode>(); 

        for (int i = 0; i < keysP1.Length; ++i)
        {
            KeyCode newVal;
            do
            {
                newVal = keysP1[(int)Random.Range(0, 4)];
                
            } while (usedValues.Contains(newVal));
            keyMapping[keysP1[i]] = newVal;
            usedValues.Add(newVal);
        }

        for (int i = 0; i < keysP2.Length; ++i)
        {
            KeyCode newVal;
            do
            {
                newVal = keysP2[(int)Random.Range(0, 4)];
            } while (usedValues.Contains(newVal));
            keyMapping[keysP2[i]] = newVal;
            usedValues.Add(newVal);
        }

        foreach (KeyCode item in usedValues)
        {
            Debug.Log(item);
        }
        
    }

    public static void swap(this GameObject objectRef)
    {
        // Acting on objectRef which is the reference to the calling object
        randomiseKeys();
    }

    public static void SetKeyMap(KeyCode key, KeyCode newMov)
    {
        keyMapping[key] = newMov;
    }

    public static bool GetKey(KeyCode keyMap)
    {
        return Input.GetKey(keyMap);
        
    }

    static void ShowKeys()
    {
        foreach (KeyValuePair<KeyCode, KeyCode> item in keyMapping)
        {
            Debug.Log(item.Value +" => " + item.Key);
        }
    }
}
