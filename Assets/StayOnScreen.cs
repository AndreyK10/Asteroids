using UnityEngine;

public class StayOnScreen : MonoBehaviour
{
    private Vector2 _tempPosition;

    public void StayOnGameScreen()
    {
        _tempPosition = transform.position;
        _tempPosition *= -1;
        transform.position = _tempPosition;
    }

    private void OnBecameInvisible()
    {
        StayOnGameScreen();
    }


}
