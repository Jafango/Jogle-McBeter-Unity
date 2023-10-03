using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToolTipManager : MonoBehaviour
{
    public static ToolTipManager _instance;

    [SerializeField] private TextMeshProUGUI textComponentName;
    [SerializeField] private TextMeshProUGUI textComponentDescription;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void SetAndShowToolTips(string name, string description)
    {
        gameObject.SetActive(true);
        textComponentName.text = name;
        textComponentDescription.text = description;
    }

    public void HideToolTips()
    {
        gameObject.SetActive(false);
        textComponentName.text = string.Empty;
        textComponentDescription.text = string.Empty;
    }
}
