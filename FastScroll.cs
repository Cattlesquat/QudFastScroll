using System;
using System.Collections.Generic;
using HarmonyLib;
using XRL.UI;
using Qud.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using XRL.UI.Framework;
using System.Text;
using System.Linq;

namespace Cattlesquat_FastScroll.HarmonyPatches
{
    [HarmonyPatch(typeof(Qud.UI.TradeLine))]
    class Cattlesquat_FastScroll
    {
        [HarmonyPrefix]
        [HarmonyPatch(nameof(Qud.UI.TradeLine.OnScroll), new Type[] { typeof(PointerEventData) } )]
        static async void Prefix(TradeLine __instance, PointerEventData eventData)
        {
            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) return;

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                ExecuteEvents.ExecuteHierarchy(__instance.gameObject.transform.parent.gameObject, eventData, ExecuteEvents.scrollHandler);
                ExecuteEvents.ExecuteHierarchy(__instance.gameObject.transform.parent.gameObject, eventData, ExecuteEvents.scrollHandler);
                ExecuteEvents.ExecuteHierarchy(__instance.gameObject.transform.parent.gameObject, eventData, ExecuteEvents.scrollHandler);
            }
        }
    }
}