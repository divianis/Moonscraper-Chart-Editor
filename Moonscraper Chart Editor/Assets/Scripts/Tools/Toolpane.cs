﻿using UnityEngine;
using System.Collections;
//using System.Windows.Forms;
//using System.Threading;
using System.Runtime.InteropServices;

public class Toolpane : MonoBehaviour {
    public static Tools currentTool = Tools.Cursor;
    ToolObject currentToolObject;
    [Header("Tool Use Screen Area")]
    public RectTransform area;

    void Start()
    {
        if (currentToolObject)
            SetTool(currentToolObject);
    }

    void Update()
    {
        if (currentToolObject)
        {
            if (Globals.applicationMode == Globals.ApplicationMode.Editor)
            {
                Rect toolScreenArea = area.GetScreenCorners();
                // Range check
                if (Mouse.world2DPosition == null ||
                    Input.mousePosition.x < toolScreenArea.xMin ||
                    Input.mousePosition.x > toolScreenArea.xMax ||
                    Input.mousePosition.y < toolScreenArea.yMin ||
                    Input.mousePosition.y > toolScreenArea.yMax)
                {
                    currentToolObject.gameObject.SetActive(false);
                }
                else
                {
                    currentToolObject.gameObject.SetActive(true);
                    if (Input.GetMouseButton(1))
                        currentToolObject.gameObject.SetActive(false);
                    else if (!Input.GetMouseButton(1))
                        currentToolObject.gameObject.SetActive(true);
                }
            }
            else
                currentToolObject.gameObject.SetActive(false);
        }
    }

    public void SetTool(ToolObject toolObject)
    {
        if (currentToolObject)
        {
            currentToolObject.ToolDisable();
            currentToolObject.gameObject.SetActive(false);
        }

        currentToolObject = toolObject;
            
        if (currentToolObject)
        {            
            currentTool = currentToolObject.GetTool();
            currentToolObject.gameObject.SetActive(true);
            currentToolObject.ToolEnable();
        }
        else
            currentTool = Tools.Cursor;
    }

    public enum Tools
    {
        Cursor, Eraser, Note
    }
}