namespace FlorianMan.UI.Textbox
{
    public class BananaPeelMorning : TextBoxUI
    {
        public static BananaPeelMorning Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            
            ActivateButton();
            Hide();
        }
    }
}