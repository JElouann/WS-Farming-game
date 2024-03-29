using System;
using UnityEngine;

public class MoneyHandler : MonoBehaviour
{
    public event Action OnMoneyUpdate;

    [field: SerializeField]
    public int MoneyCount { get; set; }

    /// <summary>
    /// This method increases or decreases the money count by a given value. Invoke the event handling money UI.
    /// </summary>
    public void UpdateMoneyCount(int value)
    {
        this.MoneyCount += value;
        this.OnMoneyUpdate?.Invoke();
    }
}
