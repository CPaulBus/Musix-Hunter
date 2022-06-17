using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _GUI_information;
    [SerializeField] private GameObject _ComboObject;
    [SerializeField] private GUI_Information _gUI;
    [SerializeField] private Animator _comboAnim;

    private int _combo, _score,_multiplier;
    private bool _ReadyToUpdate=false;

    public void SetReadyToUpdate(bool value)
    {
        _ReadyToUpdate = value;
    }

    public void UpdateUIDisplay()
    {
        if (_ReadyToUpdate)
        {
            SetScoreText();
            SetMultiplierText();
            SetComboText();

            if (_combo > 10)
            {
                _GUI_information[2].color = Color.yellow;
            }
            else
            {
                _GUI_information[2].color = Color.white;
            }


            _ReadyToUpdate = false;
        }        
    }

    private void SetScoreText()
    {
        _score = _gUI.GetCurrentScore();
        _GUI_information[0].text = _score.ToString();
        if(_ComboObject.activeInHierarchy)
            _comboAnim.SetTrigger("ScaleUP");
    }

    private void SetMultiplierText()
    {
        _multiplier = _gUI.GetCurrentMultiplier();
        _GUI_information[1].text = _multiplier.ToString() + "x";
    }

    private void SetComboText()
    {
        _combo = _gUI.GetCombo();

        if (_combo > 0)
        {
            _ComboObject.SetActive(true);
            _GUI_information[2].text = _combo.ToString();
        }
        else
        {
            _ComboObject.SetActive(false);
        }        
    }
}
