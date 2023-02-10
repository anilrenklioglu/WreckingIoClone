using System;
using UnityEngine;
using UnityEngine.UI;
namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject mainPanel;
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject losePanel;

        private void Initialize()
        {
            if (mainPanel == null)
            {
                mainPanel = GameObject.Find("MainPanel");
            }
            if (winPanel == null)
            {
                winPanel = GameObject.Find("WinPanel");
            }
            if (losePanel == null)
            {
                losePanel = GameObject.Find("LosePanel");
            }
        }

        private void Awake()
        {
            Initialize();
        }

        private void Start()
        {
           ShowMainPanel();
        }

        private void OnEnable()
        {
            EventManager.GameStarted += HideMainPanel;
            EventManager.LevelFinished += ShowWinPanel;
            EventManager.LevelFailed += ShowLosePanel;
        }

        private void OnDisable()
        {
            EventManager.GameStarted -= HideMainPanel;
            EventManager.LevelFinished -= ShowWinPanel;
            EventManager.LevelFailed -= ShowLosePanel;
        }
        
        public void HideMainPanel()
        {
            mainPanel.SetActive(false);
            
        }

        public void ShowMainPanel()
        {
            
            if (mainPanel !=null)
            {
                mainPanel.SetActive(true);                
            }
        }
        
        public void ShowWinPanel()
        {
            winPanel.SetActive(true);
        }
        
        public void ShowLosePanel()
        {
            losePanel.SetActive(true);
        }
    }
}