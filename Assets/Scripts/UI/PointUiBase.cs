using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PointUiBase : Interaction
{
    [SerializeField] public GameObject UiTamplate;
    [SerializeField] public Vector3 Offset;
    [SerializeField] public float Scale = 1f;
    [SerializeField] protected Sprite Image;

    [HideInInspector] public Canvas CanvasOverlay;
    [HideInInspector] public Camera CameraMain;
    [HideInInspector] public GameObject CreatedUI;
    

    public bool IsInteracting = false;

    public virtual void Awake()
    {
        CanvasOverlay = GameObject.FindGameObjectWithTag(Tags.CanvasOverlay.ToString()).GetComponent<Canvas>();
        CameraMain = Camera.main;
    }

    private void Start()
    {
        CreateUI();
        HideUI();
    }

    public virtual void FixedUpdate()
    {
        if (!IsInteracting) return;

        SetUIPosOffset();
    }


    public override void Interact()
    {
        IsInteracting = true;

        ShowUI();
        SetUIPosOffset();
    }

    public void InteractOut()
    {
        IsInteracting = false;

        HideUI();
    }

    private void CreateUI()
    {
        CreatedUI = Instantiate(UiTamplate.gameObject);
        CreatedUI.transform.GetChild(0).GetComponent<Image>().sprite = Image;

        CreatedUI.transform.parent = CanvasOverlay.transform;
        CreatedUI.transform.localScale = new Vector3(Scale, Scale, Scale);
    }

    private void SetUIPosOffset()
    {
        CreatedUI.transform.position = CameraMain.WorldToScreenPoint(transform.position);

        CreatedUI.transform.position += Offset;
    }

    private void ShowUI()
    {
        CreatedUI.SetActive(true);
    }

    public void HideUI()
    {
        CreatedUI.SetActive(false);
    }
}
