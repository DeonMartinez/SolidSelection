﻿﻿using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private ISelectionResponse _selectionResponse;
    private IRayProvider _rayProvider;
    private ISelector _selector;

    private Transform _currentSelection;

    private void Awake()
    {
        _rayProvider = GetComponent<IRayProvider>();
        _selector = GetComponent<ISelector>();
        _selectionResponse = GetComponent<ISelectionResponse>();
    }

    private void Update()
    {
        //selection
        if(_currentSelection != null)
        {
            _selectionResponse.OnDeselect(_currentSelection);
        }

        //determineSeelection
        _selector.Check(_rayProvider.CreateRay());
        _currentSelection = _selector.GetSelection();

        //selection
        if (_currentSelection != null)
        {
            _selectionResponse.OnSelect(_currentSelection);
        }       
    } 
}
