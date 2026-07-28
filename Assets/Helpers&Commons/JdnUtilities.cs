using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

 namespace JdnUtilities
{
    class Swizzle
    {
        public static Vector3 XOZ(Vector3 input)
        {
            return new Vector3(input.x, 0, input.z);
        }

        public static Vector3 XOX(float x)
        {
            return new Vector3(x, 0, x);
        }

        public static Vector2 XZ(Vector3 input)
        {
            return new Vector2(input.x, input.z);
        }

        public static Vector3 XOY(Vector2 input)
        {
            return new Vector3(input.x, 0, input.y);
        }

        public static Vector2 XX(float input)
        {
            return new Vector2(input, input);
        }

        public static Vector3 XXX(float input)
        {
            return new Vector3(input, input, input);
        }

        public static Vector2 VFloor(Vector2 input)
        {
            return new Vector2(Mathf.Floor(input.x), Mathf.Floor(input.y));
        }
         public static Vector3 VFloor(Vector3 input)
        {
            return new Vector3(Mathf.Floor(input.x), Mathf.Floor(input.y), Mathf.Floor(input.z));
        }
    }

    class JdnValidate
    {
        public static void ValidateInterface<T>(MonoBehaviour _mono, out T interfaceRef) where T : class
        {
            
            if(_mono == null)
            {
                Debug.LogException(new System.Exception($"Monobehaviour invalidated due to null reference for interface {typeof(T).Name}."));
                interfaceRef = null;
                return;
            }
            else if (_mono is T)
            {
                interfaceRef = _mono as T;
                Debug.Log($"Monobehaviour validated for interface {typeof(T).Name}.");
            }
            else
            {
                Debug.LogError($"Monobehaviour invalidated as it is not of type {typeof(T).Name}.");
                interfaceRef = null;
            }
            
        }

        public static void ValidateInterface<T>(ScriptableObject scriptableObject, out T interfaceRef) where T : class
        {

            if (scriptableObject == null)
            {
                Debug.LogException(new System.Exception($"Scriptable Object invalidated due to null reference for interface {typeof(T).Name}."));
                interfaceRef = null;
                return;
            }
            else if (scriptableObject is T)
            {
                interfaceRef = scriptableObject as T;
                Debug.Log($"Scriptable Object validated for interface {typeof(T).Name}.");
            }
            else
            {
                Debug.LogError($"Scriptable Object invalidated as it is not of type {typeof(T).Name}.");
                interfaceRef = null;
            }

        }
    }

    class JdnCoroutines
    {
        public static AnimationCurve F4ToCurve(float4 f4)
        {
            AnimationCurve curve = new AnimationCurve();
            curve.AddKey(0f, 0f);
            curve.AddKey(.2f, f4.x);
            curve.AddKey(.4f, f4.y);
            curve.AddKey(.6f, f4.z);
            curve.AddKey(.8f, f4.w);
            curve.AddKey(1f, 1f);
            return curve;
        }

        public static IEnumerator Interpolate<T>(
        Func<T> getter,                    // Get current value
        Action<T> setter,                  // Set interpolated value
        T targetValue,                     // Target value to reach
        float duration,                    // Time to reach target
        AnimationCurve curve,              // Curve shaping progress
        Func<T, T, float, T> lerpFunc,     // Lerp function for T
        Action EndFucntion = null,         // calls when interpolation ends
        bool useUnscaledTime = false,      // whether to use unscaled time
        Action<bool> statusFlagSetter = null  // optional setter for end flag
    )
        {
            statusFlagSetter?.Invoke(true); // Set start flag if provided
            float time = 0f;
            T startValue = getter();

            while (time < duration)
            {
                float t = time / duration;
                float curvedT = curve.Evaluate(t);
                T current = lerpFunc(startValue, targetValue, curvedT);
                setter(current);
                time += useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
                yield return null;
            }

            // Snap exactly to target at end
            setter(targetValue);
            statusFlagSetter?.Invoke(false); // Set end flag if provided
            EndFucntion?.Invoke();
        }

        public static IEnumerator CallAfterTime(Action action,float time)
        {
            yield return new WaitForSeconds(time);
            action();
        }
    }

    class BoundsProcessing
    {
        public static float4 rectTransformToF4(RectTransform rectTransform)
        {
            return new float4
                    (
                        -rectTransform.rect.width / 2,
                        -rectTransform.rect.height / 2,
                        rectTransform.rect.width / 2,
                        rectTransform.rect.height / 2
                    );
        }

        public static float4 rectTransformToF4Recentered(RectTransform rectTransform)
        {
            return new float4
                    (
                        rectTransform.anchoredPosition.x + -rectTransform.rect.width / 2,
                        rectTransform.anchoredPosition.y +  - rectTransform.rect.height / 2,
                        rectTransform.anchoredPosition.x + rectTransform.rect.width / 2,
                        rectTransform.anchoredPosition.y + rectTransform.rect.height / 2
                    );
        }
    }

    class Importer
    {
        public static string[,] CSVImportString(TextAsset textAsset)
        {
            string[] lines = textAsset.text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int rowCount = lines.Length;
            int columnCount = lines[0].Split(',').Length;
            string[,] result = new string[rowCount, columnCount];
            for (int i = 0; i < rowCount; i++)
            {
                string[] columns = lines[i].Split(',');
                for (int j = 0; j < columnCount; j++)
                {
                    result[i, j] = columns[j].Trim();
                }
            }
            return result;
        }

        public static string[,] CSVImportString(TextAsset textAsset,char delimiter)
        {
            string[] lines = textAsset.text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int rowCount = lines.Length;
            int columnCount = lines[0].Split(delimiter).Length;
            string[,] result = new string[rowCount, columnCount];
            for (int i = 0; i < rowCount; i++)
            {
                string[] columns = lines[i].Split(delimiter);
                for (int j = 0; j < columnCount; j++)
                {
                    result[i, j] = columns[j].Trim();
                }
            }
            return result;
        }
    }

    [Serializable]
    struct JdnKeyValue<Tkey,TValue>
    {
        public Tkey Key;
        public TValue Value;

        public JdnKeyValue(Tkey key,TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}
