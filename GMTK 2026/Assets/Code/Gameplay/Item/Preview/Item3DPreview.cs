using TMPro;
using UnityEngine;

namespace Core
{
    public class Item3DPreview : MonoBehaviour
    {
        [SerializeField] private TMP_Text _expiryDateLabel;

        public void Init(Item item)
        {
            var expiryText = ExpiryDateUtils.FormatExpiration(item.ExpiresOnDate);
            _expiryDateLabel.text = expiryText;
        }
    }
}