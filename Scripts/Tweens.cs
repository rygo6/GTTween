using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GeoTetra.GTTween
{
    public static class Tweens
    {
        public static IEnumerator ToFloat(
            float start,
            float target,
            float multiplier,
            AnimationCurve easeCurve,
            Action<float> onStep,
            Action onFinish)
        {
            float time = 0;
            float easeTime = 0;
            while (time < 1)
            {
                time += Time.deltaTime * multiplier;
                easeTime = easeCurve.Evaluate(time);
                onStep?.Invoke(Mathf.Lerp(start, target, easeTime));
                yield return null;
            }
            onStep?.Invoke(target);
            onFinish?.Invoke();
        }
    }
}