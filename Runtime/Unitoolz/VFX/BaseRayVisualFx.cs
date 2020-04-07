using UnityEngine;

namespace DeBox.Unitoolz.VFX
{

    public abstract class BaseRayVisualFx : MonoBehaviour
    {
        public abstract void StartPlay(Vector2 position, float rotation, float length, float normalizedLength, float width, float strength);
        public abstract void StopPlay();
    }
}
