using UnityEngine;
using TMPro;
using System;

public class RedLineManager : MonoBehaviour
{
    [SerializeField] Transform _redLineTransform;
    [SerializeField] int _pricePerDistance = 100;
    int _actualCost;
    TMP_Text _textTMP;
    string _text = "$";

    GridSystem _grid;
    int _gridWidth, _gridHeight;
    int _lineHeight;
    int _cellHeight = 1;

    public int ActualCost => _actualCost;

    private void Awake()
    {
        _textTMP = _redLineTransform.GetComponentInChildren<TMP_Text>();
    }
    void Update()
    {
        int maxHeight = GetGridMaxHeight();
        if (_lineHeight == maxHeight) return;
        _lineHeight = maxHeight;
        SetLineHeight();
        UpdateActualCost();
        SetPriceText();
    }

    public void SetGrid(GridSystem grid)
    {
        _grid = grid;
        _grid.GetGridDimensions(out _gridWidth, out _gridHeight);
    }

    void SetLineHeight() => _redLineTransform.position = new Vector3(0,_lineHeight);
    int GetGridMaxHeight() 
    {
        for (int y = _gridHeight-1; y >= 0 ; y--)
        {
            for (int x = 0; x < _gridWidth; x++)
            {
                if (_grid.GetValue(x, y) != 0) return y + _cellHeight;
            }
        }
        return 0;
    }
    void UpdateActualCost() => _actualCost = _lineHeight * _pricePerDistance;
    private void SetPriceText()
    {
        _text = "$" + _actualCost;
        _textTMP.text = _text;
    }

}
