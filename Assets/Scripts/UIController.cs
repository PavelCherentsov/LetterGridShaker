using UnityEngine;
using TMPro;
using System;

public class UIController : MonoBehaviour
{
    private GridConfiguration _gridConfiguration;
    private GridScaler _gridScaler;
    private GridFiller _gridFiller;

    [SerializeField] private TMP_InputField _widthText;
    [SerializeField] private TMP_InputField _heightText;

    private bool isBusy;

    private void Start()
    {
        _gridConfiguration = FindObjectOfType<GridConfiguration>();
        _gridScaler = FindObjectOfType<GridScaler>();
        _gridFiller = FindObjectOfType<GridFiller>();

        _gridFiller.OnChangeState += Free;

        Generete();
    }

    private void Free()
    {
        isBusy = false;
    }

    public void Generete()
    {
        if (isBusy)
            return;

        var width = 0;
        var height = 0;

        try
        {
            width = int.Parse(_widthText.text);
            height = int.Parse(_heightText.text);
        } 
        catch
        {
            SetDefautValues(ref width, ref height);
        }

        if (width <= 0 || height <= 0 || width <= height/2)
        {
            SetDefautValues(ref width, ref height);
        }

        _gridConfiguration.CountColumn = width;
        _gridConfiguration.CountRow = height;

        _gridFiller.Regenerate();
        _gridScaler.Rescale();
    }

    public void Shuffle()
    {
        if (isBusy)
            return;

        isBusy = true;

        _gridFiller.Shuffle();
    }

    private void SetDefautValues(ref int width, ref int height)
    {
        _widthText.text = "4";
        _heightText.text = "4";
        width = 4;
        height = 4;
    }
}
