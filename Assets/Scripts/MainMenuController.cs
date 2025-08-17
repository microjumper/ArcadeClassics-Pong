using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{
    private VisualElement root;
    private Button playButton;
    
    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        
        playButton = root.Q<Button>("play__button");
    }

    private void OnEnable()
    {
        playButton.clicked += OnPlayClicked;
    }

    private void OnDisable()
    {
        playButton.clicked -= OnPlayClicked;
    }

    private void Start()
    {
        // Pause game until player starts
        Time.timeScale = 0f;
    }
    
    private void OnPlayClicked()
    {
        Time.timeScale = 1f;
        
        gameObject.SetActive(false);
    }
}
