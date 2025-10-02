using System;
using UnityEngine;

public class CraneSystem : MonoBehaviour
{
    [Header("Controllers")]
    [SerializeField] private CraneHoistController _hoistController;
    [SerializeField] private CraneHookController _hookController;
    [SerializeField] private CraneBeamHolderController _beamHolderController;
    [Space]
    [SerializeField] private AbstractCraneButtonInput _input;
    [Space]
    [SerializeField] private AbstractCraneMovementModel _model;

    private void Awake() => Subscribe();

    private void Start() => Init();

    private void OnDestroy() => Unsubscribe();

    private void Init()
    {
        _hoistController?.Construct(_model);
        _hookController?.Construct(_model);
        _beamHolderController?.Construct(_model);
    }


    #region OnButton
    private void OnUpButton(bool isStart)
    {
        if (!_hookController)
            return;

        HandleMovement(isStart, _hookController.UpMoveStart, _hookController.StopMovement);
    }

    private void OnDownButton(bool isStart)
    {
        if (!_hookController)
            return;

        HandleMovement(isStart, _hookController.DownMoveStart, _hookController.StopMovement);
    }

    private void OnLeftButton(bool isStart)
    {
        if (!_hoistController)
            return;

        HandleMovement(isStart, _hoistController.LeftMoveStart, _hoistController.StopMovement);
    }

    private void OnRightButton(bool isStart)
    {
        if (!_hoistController)
            return;

        HandleMovement(isStart, _hoistController.RightMoveStart, _hoistController.StopMovement);
    }

    private void OnForwardButton(bool isStart)
    {
        if (!_beamHolderController)
            return;

        HandleMovement(isStart, _beamHolderController.ForwardMoveStart, _beamHolderController.StopMovement);
    }

    private void OnBackButton(bool isStart)
    {
        if (!_beamHolderController)
            return;

        HandleMovement(isStart, _beamHolderController.BackMoveStart, _beamHolderController.StopMovement);
    }

    private void HandleMovement(bool isStart, Action startAction, Action stopAction)
    {
        if (isStart)
            startAction.Invoke();
        else
            stopAction.Invoke();
    }
    #endregion

    #region Subscribe/Unsubscribe
    private void Subscribe()
    {
        _input.onUpButton += OnUpButton;
        _input.onDownButton += OnDownButton;
        _input.onLeftButton += OnLeftButton;
        _input.onRightButton += OnRightButton;
        _input.onForwardButton += OnForwardButton;
        _input.onBackButton += OnBackButton;
    }

    private void Unsubscribe()
    {
        _input.onUpButton -= OnUpButton;
        _input.onDownButton -= OnDownButton;
        _input.onLeftButton -= OnLeftButton;
        _input.onRightButton -= OnRightButton;
        _input.onForwardButton -= OnForwardButton;
        _input.onBackButton -= OnBackButton;
    }
    #endregion

}