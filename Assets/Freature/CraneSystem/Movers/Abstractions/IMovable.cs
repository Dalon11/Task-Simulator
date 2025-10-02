using UnityEngine;

public interface IMovable
{
    public bool IsMove { get; }
    public Vector3 CurrentDirection { get; }

    public void StartMove(Vector3 direction);
    public void Stop();
    public void Move();
}
