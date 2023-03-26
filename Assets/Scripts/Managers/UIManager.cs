using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class UIManager : MonoBehaviour
    {
        public TextMeshProUGUI CounterDisplay;

        private long _quantity = 0;
        
        public void DecrementActiveSpaceShips()
        {
            _quantity--;
            UpdateDisplayText();
        }

        public void IncrementActiveSpaceShips()
        {
            _quantity++;
            UpdateDisplayText();
        }

        private void UpdateDisplayText()
        {
            CounterDisplay.text = _quantity.ToString();
        }

        private void Awake()
        {
            _quantity = 0;
        }

        private void Start()
        {
        }
    }
}