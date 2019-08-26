using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GeoTetra.GTTween
{
    public static class RectTransformTweens
    {
        public static IEnumerator ToLocalPosition(
            RectTransform rectTransform, 
            Vector2 targetPosition, 
            float multiplier,
            AnimationCurve easeCurve, 
            Action onFinish)
        {
            float time = 0;
            float easeTime = 0;
            Vector2 startPosition = rectTransform.localPosition;

            while (time < 1)
            {
                time += Time.deltaTime * multiplier;
                easeTime = easeCurve.Evaluate(time);
                rectTransform.localPosition = Vector2.Lerp(startPosition, targetPosition, easeTime);
                yield return null;
            }

            rectTransform.localPosition = targetPosition;

            if (onFinish != null)
            {
                onFinish();
            }
        }
    }
}