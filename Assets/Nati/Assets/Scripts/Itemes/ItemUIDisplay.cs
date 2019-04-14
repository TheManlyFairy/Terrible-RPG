using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIDisplay : MonoBehaviour
{

    public ConsumableIteme consumableIteme;
    public Text copyCountText;
    private int copyCount;

    // Start is called before the first frame update
    void Start()
    {
        if (consumableIteme != null)
        {
            UpdateCopycount();
            UpdateItemIcon();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (consumableIteme != null)
        {
            if (copyCount != consumableIteme.copyCount)
            {
                UpdateCopycount();
            }
        }
    }

    void UpdateCopycount()
    {
        copyCount = consumableIteme.copyCount;
        copyCountText.text = "" + copyCount;
    }

    void UpdateItemIcon()
    {
        Image icon = GetComponent<Image>();
        icon.sprite = consumableIteme.Icon;           
    }
}
