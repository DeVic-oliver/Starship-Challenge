using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI CounterDisplay;
        private long _quantity = 0;

        [Space(15f)]
        [Header("Speed Radar Setup")]
        [SerializeField] private TextMeshProUGUI FastestSpeedTMPro;
        [SerializeField] private TextMeshProUGUI LowestSpeedTMPro;

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
            string text = "Ships Active: " + _quantity.ToString();
            CounterDisplay.text = text;
        }

        public void UpdateFastestSpeed(float speed)
        {
            string text = "Fastest Speed: " + speed.ToString("0.00");
            FastestSpeedTMPro.text = text;
        }

        public void UpdateLowestSpeed(float speed)
        {  
            string text = "Lowest Speed: " + speed.ToString("0.00");
            LowestSpeedTMPro.text = text;
        }

        private void Awake()
        {
            _quantity = 0;
        }
    }
}