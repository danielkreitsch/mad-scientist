using UnityEngine;

namespace Utility
{
    public static class MathUtilty
    {
        public static float WrapAngle(float value, float min, float max)
        {
            max -= min;
            if (max == 0)
            {
                return min;
            }

            return value - max * Mathf.Floor((value - min) / max);
        }

        public static Vector3 SmoothDampEuler(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime)
        {
            return new Vector3(
                Mathf.SmoothDampAngle(current.x, target.x, ref currentVelocity.x, smoothTime),
                Mathf.SmoothDampAngle(current.y, target.y, ref currentVelocity.y, smoothTime),
                Mathf.SmoothDampAngle(current.z, target.z, ref currentVelocity.z, smoothTime)
            );
        }

        public static Quaternion SmoothDampQuaternion(Quaternion current, Quaternion target, ref Vector3 currentVelocity, float smoothTime)
        {
            Vector3 c = current.eulerAngles;
            Vector3 t = target.eulerAngles;
            return Quaternion.Euler(
                Mathf.SmoothDampAngle(c.x, t.x, ref currentVelocity.x, smoothTime),
                Mathf.SmoothDampAngle(c.y, t.y, ref currentVelocity.y, smoothTime),
                Mathf.SmoothDampAngle(c.z, t.z, ref currentVelocity.z, smoothTime)
            );
        }
    }
}