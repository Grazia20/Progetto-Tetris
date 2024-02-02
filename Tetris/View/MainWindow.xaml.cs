using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tetris.ViewModel;

namespace Tetris.View
{
    public partial class MainWindow : Window
    {
        // ViewModel associato alla finestra
        private readonly MainWindowViewModel mainWindowVM;

        public MainWindow()
        {
            InitializeComponent();

            // Inizializza il ViewModel passando i controlli necessari alla sua costruzione
            mainWindowVM = new MainWindowViewModel(GameCanvas,
                                                    ScoreText,
                                                    NextImage,
                                                    HoldImage,
                                                    GameOverMenu,
                                                    FinalScoreText,
                                                    UsernameTextBox,
                                                    PasswordTextBox,
                                                    LoginPage,
                                                    MuteButton);

            // Imposta il DataContext del MainWindow al ViewModel
            DataContext = mainWindowVM;

            // Aggiunge un gestore dell'evento Loaded per il GameCanvas_Loaded
            Loaded += GameCanvas_Loaded;
        }

        // Gestore dell'evento KeyDown per la finestra
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Richiama il metodo Window_KeyDown del ViewModel per gestire l'input del gioco
            mainWindowVM.Window_KeyDown(sender, e);
        }

        // Gestore dell'evento Click per il pulsante MuteButton
        private void MuteButton_Click(object sender, RoutedEventArgs e)
        {
            // Richiama il metodo MuteButton_Click del ViewModel per gestire il mute/unmute della musica
            mainWindowVM.MuteButton_Click(sender, e);
        }

        // Gestore dell'evento Click per il pulsante ExitButton
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            // Richiama il metodo ExitButton_Click del ViewModel per chiudere l'applicazione
            mainWindowVM.ExitButton_Click(sender, e);
        }

        // Gestore dell'evento Click per il pulsante PlayAgain
        private async void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            // Richiama il metodo PlayAgain_Click del ViewModel per iniziare una nuova partita
            await mainWindowVM.PlayAgain_Click(sender, e);
        }

        

        // Gestore dell'evento Click per il pulsante RegisterButton
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Richiama il metodo RegisterButton_Click del ViewModel per gestire la registrazione dell'utente
            mainWindowVM.RegisterButton_Click(sender, e);
        }

        // Gestore dell'evento Click per il pulsante LoginButton
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Richiama il metodo LoginButton_Click del ViewModel per gestire il login dell'utente
            mainWindowVM.LoginButton_Click(sender, e);
        }

        // Gestore dell'evento Loaded per il GameCanvas
        private async void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            // Rimuove il gestore dell'evento Loaded per evitare chiamate multiple
            Loaded -= GameCanvas_Loaded;

            // Avvia il gioco dopo che GameCanvas è stato caricato correttamente
            await mainWindowVM.GameCanvas_Loaded(sender, e);
        }
    }
}
