using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Tetris.Model;
using Grid = System.Windows.Controls.Grid;

namespace Tetris.ViewModel
{
    public class MainWindowViewModel
    {
        // Array di immagini delle tessere del tetris
        private readonly ImageSource[] tileImages = new ImageSource[]
        {
            // Inizializzazione delle immagini delle tessere, da vuoto a rosso
            // I percorsi delle immagini sono relativi alla cartella del progetto
            new BitmapImage(new Uri("../Images/TileEmpty.png", UriKind.Relative)),
            new BitmapImage(new Uri("../Images/TileCyan.png", UriKind.Relative)),
            new BitmapImage(new Uri("../Images/TileBlue.png", UriKind.Relative)),
            new BitmapImage(new Uri("../Images/TileOrange.png", UriKind.Relative)),
            new BitmapImage(new Uri("../Images/TileYellow.png", UriKind.Relative)),
            new BitmapImage(new Uri("../Images/TileGreen.png", UriKind.Relative)),
            new BitmapImage(new Uri("../Images/TilePurple.png", UriKind.Relative)),
            new BitmapImage(new Uri("../Images/TileRed.png", UriKind.Relative)),
        };

        // Array di immagini dei blocchi del tetris
        private readonly ImageSource[] blockImages = new ImageSource[]
        {
            // Inizializzazione delle immagini dei blocchi, da vuoto a Z
            // I percorsi delle immagini sono relativi alla cartella del progetto
            new BitmapImage(new Uri("../Images/Block-Empty.png", UriKind.Relative)),
            new BitmapImage(new Uri("../Images/Block-I.png", UriKind.Relative)),
            new BitmapImage(new Uri("../Images/Block-J.png", UriKind.Relative)),
            new BitmapImage(new Uri("../Images/Block-L.png", UriKind.Relative)),
            new BitmapImage(new Uri("../Images/Block-O.png", UriKind.Relative)),
            new BitmapImage(new Uri("../Images/Block-S.png", UriKind.Relative)),
            new BitmapImage(new Uri("../Images/Block-T.png", UriKind.Relative)),
            new BitmapImage(new Uri("../Images/Block-Z.png", UriKind.Relative)),
        };

        private readonly Image[,] imageControls; // Matrice di controlli delle immagini sul canvas del gioco
        private readonly int maxDelay = 1000; // Ritardo massimo di aggiornamento del gioco
        private readonly int minDelay = 75;   // Ritardo minimo di aggiornamento del gioco
        private readonly int delayDecrease = 25; // Decremento del ritardo in base allo score

        private InterfaceGameState gameState = new GameState(); // Stato corrente del gioco

        private readonly MediaPlayer mediaPlayer; // Riproduttore audio per la musica di sottofondo
        private readonly InterfaceLogin userCredentials; // Credenziali utente per il login

        // Proprietà dei controlli nella finestra WPF
        public Canvas GameCanvas { get; set; }
        public TextBox UsernameTextBox { get; set; }
        public PasswordBox PasswordTextBox { get; set; }
        public Grid LoginPage { get; set; }
        
        public Grid GameOverMenu { get; set; }
        public Button MuteButton { get; set; }
        public Image NextImage { get; set; }
        public Image HoldImage { get; set; }
        public TextBlock FinalScoreText { get; set; }
        public TextBlock ScoreText { get; set; }


        // Costruttore della classe
        public MainWindowViewModel(Canvas gameCanvas,
                                   TextBlock scoreText,
                                   Image nextImage,
                                   Image holdImage,
                                   Grid gameOverMenu,
                                   TextBlock finalScoreText,
                                   TextBox usernameTextBox,
                                   PasswordBox passwordTextBox,
                                   Grid loginPage,
                                   Button muteButton)
        {
           
            userCredentials = new Login();

            // Inizializzazione delle proprietà con i controlli nella finestra WPF
            GameCanvas = gameCanvas;
            ScoreText = scoreText;
            NextImage = nextImage;
            HoldImage = holdImage;
            GameOverMenu = gameOverMenu;
            FinalScoreText = finalScoreText;
            UsernameTextBox = usernameTextBox;
            PasswordTextBox = passwordTextBox;
            LoginPage = loginPage;
            MuteButton = muteButton;

            mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri("Sounds/BackgroundMusic.mp3", UriKind.Relative));
            mediaPlayer.Volume = 0.5; // Imposta il volume (da 0.0 a 1.0)
            mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
            mediaPlayer.Play(); // Avvia la riproduzione della musica di sottofondo all'avvio dell'applicazione.

            // Inizializza l'array di immagini dei controlli
            imageControls = SetUpGameCanvas(gameState.Grid);
        }



        // Metodo per il click del pulsante di login
        public async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;

            if (userCredentials.AuthenticateUser(username, password))
            {
                // Utente autenticato con successo, eseguire l'azione desiderata
                MessageBox.Show("Login avvenuto con successo!");
                LoginPage.Visibility = Visibility.Hidden;
                gameState = new GameState();
                await GameLoop();
            }
            else
            {
                MessageBox.Show("Credenziali non valide. Riprova.");
            }
        }

        // Metodo per il click del pulsante di registrazione
        public void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;

            if (userCredentials.RegisterUser(username, password))
            {
                MessageBox.Show("Registrazione avvenuta con successo!");
            }
            else
            {
                MessageBox.Show("Username già utilizzato. Scegli un altro username.");
            }
        }

        // Metodo per il click del pulsante di mute/unmute della musica
        public void MuteButton_Click(object sender, RoutedEventArgs e)
        {
            if (mediaPlayer.Volume == 0)
            {
                // Riprendi la riproduzione della musica impostando il volume a 0.5
                mediaPlayer.Volume = 0.5;
                MuteButton.Content = "Mute Music";
            }
            else
            {
                // Ferma la riproduzione della musica impostando il volume a 0
                mediaPlayer.Volume = 0;
                MuteButton.Content = "Unmute Music";
            }
        }

        // Metodo per gestire l'evento di fine riproduzione della musica di sottofondo
        private void MediaPlayer_MediaEnded(object? sender, EventArgs e)
        {
            // Riproduci nuovamente la musica quando si raggiunge la fine del file.
            mediaPlayer.Position = TimeSpan.Zero;
            mediaPlayer.Play();
        }


        // Metodo per configurare i controlli delle immagini sul canvas di gioco
        private Image[,] SetUpGameCanvas(InterfaceGrid grid)
        {
            if (GameCanvas == null)
            {
                throw new InvalidOperationException("GameCanvas has not been initialized.");
            }

            Image[,] imageControls = new Image[grid.Rows, grid.Columns];
            int cellSize = 25;

            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    Image imageControl = new()
                    {
                        Width = cellSize,
                        Height = cellSize
                    };

                    Canvas.SetTop(imageControl, (r - 2) * cellSize + 10);
                    Canvas.SetLeft(imageControl, c * cellSize);

                    if (GameCanvas != null)
                    {
                        GameCanvas.Children.Add(imageControl);
                    }

                    imageControls[r, c] = imageControl;
                }
            }

            return imageControls;
        }


        // Metodo per disegnare la griglia del gioco sul canvas
        private void DrawGrid(InterfaceGrid grid)
        {
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    int id = grid[r, c];
                    imageControls[r, c].Opacity = 1;
                    imageControls[r, c].Source = tileImages[id];
                }
            }
        }

        // Metodo per disegnare il blocco corrente sul canvas di gioco
        private void DrawBlock(InterfaceBlock block)
        {
            foreach (Position p in block.TilePosition())
            {
                imageControls[p.Row, p.Column].Opacity = 1;
                imageControls[p.Row, p.Column].Source = tileImages[block.Id];
            }
        }



        // Metodo per disegnare il blocco successivo nell'area di anteprima
        private void DrawNextBlock(InterfaceBlockQueue blockQueue)
        {
            InterfaceBlock next = blockQueue.NextBlock;
            NextImage.Source = blockImages[next.Id];
        }

        // Metodo per disegnare il blocco tenuto nell'area di anteprima
        private void DrawHeldBlock(InterfaceBlock heldBlock)
        {
            if (heldBlock == null)
            {
                // Se il blocco tenuto è nullo, visualizza l'immagine di un blocco vuoto (index 0)
                HoldImage.Source = blockImages[0];
            }
            else
            {
                // Altrimenti, visualizza l'immagine del blocco corrispondente all'ID del blocco tenuto
                HoldImage.Source = blockImages[heldBlock.Id];
            }
        }

        // Metodo per disegnare il fantasma del blocco (posizione di caduta) sul canvas di gioco
        private void DrawGhostBlock(InterfaceBlock block)
        {
            int dropDistance = gameState.BlockDropDstance();

            foreach (Position p in block.TilePosition())
            {
                imageControls[p.Row + dropDistance, p.Column].Opacity = 0.25;
                imageControls[p.Row + dropDistance, p.Column].Source = tileImages[block.Id];
            }
        }

        // Metodo per disegnare l'intero stato di gioco sul canvas
        private void Draw(InterfaceGameState gameState)
        {

            DrawGrid(gameState.Grid);
            DrawGhostBlock(gameState.CurrentBlock);
            DrawBlock(gameState.CurrentBlock);
            DrawNextBlock(gameState.Queue);
            DrawHeldBlock(gameState.HeldBlock);
            ScoreText.Text = $"Score: {gameState.Score}";
        }

        // Metodo per il loop di gioco asincrono
        private async Task GameLoop()
        {
            Draw(gameState);

            // Ciclo di gioco principale
            while (!gameState.GameOver)
            {
                int delay = Math.Max(minDelay, maxDelay - (gameState.Score * delayDecrease));

                // Attesa asincrona per il delay prima di aggiornare il gioco
                await Task.Delay(delay);
                gameState.MoveBlockDown();
                Draw(gameState);
            }

            // Il gioco è terminato, mostra il menu di Game Over e aggiorna il testo dello score finale
            GameOverMenu.Visibility = Visibility.Visible;
            FinalScoreText.Text = $"Score: {gameState.Score}";
        }

        // Metodo per gestire l'evento di pressione di un tasto sulla finestra
        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameState.GameOver)
            {
                return;
            }

            // Gestione dell'input per il movimento e le azioni del blocco
            switch (e.Key)
            {
                case Key.Left:
                    gameState.MoveBlockLeft();
                    break;
                case Key.Right:
                    gameState.MoveBlockRight();
                    break;
                case Key.Down:
                    gameState.MoveBlockDown();
                    break;
                case Key.Up:
                    gameState.RotateBlockCW();
                    break;
                case Key.C:
                    gameState.HoldBlock();
                    break;
                case Key.Z:
                    gameState.RotateBlockCCW();
                    break;
                case Key.D:
                    gameState.DropBlock();
                    break;
                default:
                    return;
            }

            Draw(gameState);
        }

        // Metodo per il caricamento del canvas di gioco
        public async Task GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            await GameLoop();
        }

        // Metodo per iniziare una nuova partita al click del pulsante Play Again
        public async Task PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            gameState = new GameState();
            GameOverMenu.Visibility = Visibility.Hidden;
            await GameLoop();
        }

       

        // Metodo per chiudere l'applicazione al click del pulsante Exit
        public void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}