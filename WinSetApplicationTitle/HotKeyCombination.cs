using System.Configuration;
using System.Text;
using System.Windows.Forms;

namespace WinSetApplicationTitle
{
    public class HotKeyCombination :  ApplicationSettingsBase
    {
        private Keys key;

        private ModifierKeys modifierKeys;

        public HotKeyCombination(ModifierKeys modifierKeys, Keys key)
        {
            this.key = key;
            this.modifierKeys = modifierKeys;
        }

        [UserScopedSetting()]
        [SettingsSerializeAs(System.Configuration.SettingsSerializeAs.Xml)]
        public Keys Key
        {
            get
            {
                return key;
            }
        }

        [UserScopedSetting()]
        [SettingsSerializeAs(System.Configuration.SettingsSerializeAs.Xml)]
        public ModifierKeys ModifierKeys
        {
            get
            {
                return modifierKeys;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (this.modifierKeys.HasFlag(ModifierKeys.Shift))
            {
                sb.Append("Shift + ");
            }

            if (this.modifierKeys.HasFlag(ModifierKeys.Alt))
            {
                sb.Append("Alt + ");
            }

            if (this.modifierKeys.HasFlag(ModifierKeys.Control))
            {
                sb.Append("Control + ");
            }

            sb.Append(this.key.ToString());

            return sb.ToString();
        }
    }
}
