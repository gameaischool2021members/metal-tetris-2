using UnityEngine;

public class AgentModeToggle : MonoBehaviour
{
    public bool IsInAgentMode = false;
    [SerializeField] PlayerController _playerController;
    [SerializeField] AgentController _agentController;

    bool _wasInAgentMode;

    private void Start()
    {
        //IsInAgentMode = false;
        if (!IsInAgentMode)
        {
            _playerController.enabled = true;
            _agentController.enabled = false;
        }
        else
        {
            _playerController.enabled = false;
            _agentController.enabled = true;
        }
    }

    private void Update()
    {
        if (IsInAgentMode != _wasInAgentMode)
        {
            _wasInAgentMode = IsInAgentMode;
            UpdateSettings();
        }
    }

    private void UpdateSettings()
    {
        if (IsInAgentMode)
        {
            _playerController.enabled = false;
            _agentController.enabled = true;
        }
        else
        {
            _playerController.enabled = true;
            _agentController.enabled = false;
        }
    }
}
