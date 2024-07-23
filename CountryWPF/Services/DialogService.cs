using System.Windows;

namespace CountryWPF.Services
{
    public class DialogService
    {
        /// <summary>
        /// Show messages
        /// </summary>
        /// <param name="title">Title</param>
        /// <param name="message">Message</param>
        public void ShowMessage(string title, string message)
        {
           //executa o codigo na thread do interface
            Application.Current.Dispatcher.InvokeAsync(async () =>
            {
                // Pequeno atraso para garantir que a UI esteja pronta
                await Task.Delay(100);

                // Verifique se a aplicação esta a fechar
                if (!App.IsShuttingDown)
                {
                    MessageBox.Show(message, title);

                }
            }, System.Windows.Threading.DispatcherPriority.Background);
            
        }

        
       
    }
}
