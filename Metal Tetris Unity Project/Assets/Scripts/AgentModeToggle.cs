using UnityEngine;

public class AgentModeToggle : MonoBehaviour
{
    public bool IsInAgentMode = true;
    [SerializeField] PlayerController _playerController;
    [SerializeField] AgentController _agentController;

    bool _wasInAgentMode;

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
