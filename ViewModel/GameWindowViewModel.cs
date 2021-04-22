using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UnoGame2.Extensions;
using UnoGame2.Messages;
using UnoGame2.Model;

namespace UnoGame2.ViewModel
{
    class GameWindowViewModel: BaseModel
    {
        private DialogService dialogService;
        private ObservableCollection<Card> cards;
        private ObservableCollection<GameCard> deck;
        private Player realPlayer;
        private Player winner;
        private ObservableCollection<CombinedPlayerCard> playerHand;
        /*private ObservableCollection<Card> realPlayerHandCards;*/
        private CombinedPlayerCard currentCard;
        private Game game;
        private List<Player> players;
        private int playerAmount;
        private ICommand playCard;
        private ICommand drawCard;
        private ObservableCollection<GameCard> playedCards;
        private CombinedPlayerCard lastPlayedCard;
        private Player playerTurn;
        private String pickedColor;
        private String rotation;
        private bool cardAbilityUsed;
        private ObservableCollection<String> logs;
        private ObservableCollection<CombinedPlayerCard> bot1;
        private ObservableCollection<CombinedPlayerCard> bot2;
        private ObservableCollection<CombinedPlayerCard> bot3;
        private int totalCardsPlayed;
        private int totalTurns;

        
        //Constructor
        public GameWindowViewModel()
        {
            //Register on to mainmenu message that starts the game.
            Messenger.Default.Register<Tuple<int, Player>>(this, dataPlayerAndAmount);
            dialogService = new DialogService();

            //Get all Cards
            CardDataService ds = new CardDataService();
            Cards = ds.GetCards();

            //Bind our commands
            BindCommands();

        }

        //All getters and setters...
        public ObservableCollection<Card> Cards
        {
            get
            {
                return cards;
            }
            set
            {
                cards = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<GameCard> Deck
        {
            get
            {
                if (deck == null)
                {
                    deck = new ObservableCollection<GameCard>();
                }
                return deck;
            }
            set
            {
                deck = value;
                NotifyPropertyChanged();
            }
        }

        public Player RealPlayer
        {
            get
            {
                return realPlayer;
            }
            set
            {
                realPlayer = value;
            }
        }

        public Player Winner
        {
            get
            {
                return winner;
            }
            set
            {
                winner = value;
            }
        }

        public ObservableCollection<CombinedPlayerCard> PlayerHand
        {
            get
            {
                if (playerHand == null)
                {
                    playerHand = new ObservableCollection<CombinedPlayerCard>();
                }
                return playerHand;
            }
            set
            {
                playerHand = value;
                NotifyPropertyChanged();
            }
        }

        public CombinedPlayerCard CurrentCard
        {
            get
            {
                /*   if (currentCard == null)
                   {
                       currentCard = new Card();
                   }*/

                return currentCard;
            }

            set
            {
                currentCard = value;
                NotifyPropertyChanged();
            }
        }

      

        
        public ObservableCollection<CombinedPlayerCard> Bot3
        {
            get
            {
                if (bot3 == null)
                {
                    bot3 = new ObservableCollection<CombinedPlayerCard>();
                }
                return bot3;
            }
            set
            {
                value = bot3;
                NotifyPropertyChanged();

            }
        }

        public ObservableCollection<CombinedPlayerCard> Bot2
        {
            get
            {
                if (bot2 == null)
                {
                    bot2 = new ObservableCollection<CombinedPlayerCard>();
                }
                return bot2;
            }
            set
            {
                value = bot2;
                NotifyPropertyChanged();

            }
        }

        public ObservableCollection<CombinedPlayerCard> Bot1
        {
            get
            {
                if (bot1 == null)
                {
                    bot1 = new ObservableCollection<CombinedPlayerCard>();
                }
                return bot1;
            }
            set
            {
                value = bot1;
                NotifyPropertyChanged();

            }
        }


        public ObservableCollection<String> Logs
        {
            get
            {
                if (logs == null)
                {
                    logs = new ObservableCollection<String>();
                }
                return logs;
            }
            set
            {
                value = logs;
                NotifyPropertyChanged();

            }
        }

        public bool CardAbilityUsed
        {
            get
            {
                return cardAbilityUsed;
            }
            set
            {
                cardAbilityUsed = value;
            }
        }
        public Game Game
        {
            get
            {
                if (game == null)
                {
                    game = new Game();
                }
                return game;
            }
            set
            {
                game = value;
            }
        }

        public String Rotation
        {
            get
            {
                return rotation;
            }
            set
            {
                rotation = value;
            }
        }

        public String PickedColor
        {
            get
            {
                return pickedColor;
            }
            set
            {
                pickedColor = value;
            }
        }


        public Player PlayerTurn
        {
            get
            {
                return playerTurn;
            }
            set
            {
                playerTurn = value;
            }
        }

        
        public int PlayerAmount
        {
            get
            {
                return playerAmount;
            }
            set
            {
                playerAmount = value;
            }
        }

        public List<Player> Players
        {
            get
            {
                if (players == null)
                {
                    players = new List<Player>();
                }
                return players;
            }
            set
            {
                players = value;
            }
        }

        public ObservableCollection<GameCard> PlayedCards
        {
            get
            {
                if (playedCards == null)
                {
                    playedCards = new ObservableCollection<GameCard>();
                }
                return playedCards;
            }
            set
            {
                playedCards = value;
                NotifyPropertyChanged();
            }
        }

        public CombinedPlayerCard LastPlayedCard {
            get
            {
               
                return lastPlayedCard;
            }
            set
            {
                lastPlayedCard = value;
                NotifyPropertyChanged();
            }
        }

        public int TotalCardsPlayed
        {
            get
            {
                return totalCardsPlayed;
            }
            set
            {
                totalCardsPlayed = value;
            }
        }

        public int TotalTurns
        {
            get
            {
                return totalTurns;
            }
            set
            {
                totalTurns = value;
            }
        }

        public ICommand PlayCard
        {
            get
            {
                return playCard;
            }

            set
            {
                playCard = value;
            }
        }

        public ICommand DrawCard
        {
            get
            {
                return drawCard;
            }

            set
            {
                drawCard = value;
            }
        }

        //Methods
        public void BindCommands()
        {
            PlayCard = new BaseCommand(Play);
            DrawCard = new BaseCommand(Draw);

        }

        public void dataPlayerAndAmount(Tuple<int, Player> data)
        {
            //Receive data from main menu. The Player and the amount of bots we will need
            PlayerAmount = data.Item1;
            RealPlayer = data.Item2;
            createGame();
        }

        public void createGame()
        {
            //set and create a game in our database.
            GameDataService ds = new GameDataService();
            Game.PlayerId = realPlayer.Id;
            Game.StartTime = DateTime.Now;
            Game.EndTime = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            int gameId = ds.InsertGame(Game);

            Game.Id = gameId;
            createPlayers();

        }

        public void createPlayers()
        {
            //Create bots and add everyone to database.
            PlayerDataService ds = new PlayerDataService();
            Players.Add(RealPlayer);
            for (int i = 0; i < PlayerAmount - 1; i++)
            {
                Player bot = new Player();
                bot.Nickname = $"bot {i + 1}";
                var playerid = ds.InsertPlayer(bot);
                bot.Id = playerid;
                Players.Add(bot);
            }

            generateDeck();

        }

        public void generateDeck()
        {
            //Gather all cards out of our database and create an UNO deck.
            foreach (Card card in Cards)
            {
                switch (card.Kind)
                {
                    case "wild":
                    case "plus4":
                        Deck.Add(new GameCard(card.Id, Game.Id, null));
                        Deck.Add(new GameCard(card.Id, Game.Id, null));
                        Deck.Add(new GameCard(card.Id, Game.Id, null));
                        Deck.Add(new GameCard(card.Id, Game.Id, null));
                        break;
                    case "0":
                        Deck.Add(new GameCard(card.Id, Game.Id, null));
                        break;
                    default:
                        Deck.Add(new GameCard(card.Id, Game.Id, null));
                        Deck.Add(new GameCard(card.Id, Game.Id, null));
                        break;
                }
            }
            //Shuffle the deck
            deck.Shuffle();
            assignPlayerCards();
        }

        public void assignPlayerCards()
        {
            //cardToBeAssigned is the total amount of cards we will assign to players
            int cardsToBeAssigned = Players.Count() * 7;

            //startingCard will be the first turned over card in our game.
            int startingCard = cardsToBeAssigned + 1;

            foreach (Player player in Players)
            {
                for (int i = 0; i < 7; i++)
                {
                    Deck[cardsToBeAssigned].PlayerId = player.Id;
                    cardsToBeAssigned = cardsToBeAssigned - 1;
                }
            }

            //We will loop through our deck until we find our appropriate starting card, can't be wild or plus4.
            while (true)
            {
                if (Cards[Deck[startingCard].CardId].Kind != "wild" && Cards[Deck[startingCard].CardId].Kind != "plus4")
                {
                    Deck[startingCard].IsPlayed = true;
                    LastPlayedCard = new CombinedPlayerCard(Deck[startingCard]);
                    break;
                } else
                {
                    startingCard = startingCard + 1;
                }
            }


            writeGameCards();

        }
        public void writeGameCards()
        {
            GameCardDataService ds = new GameCardDataService();

            //Write deck to our database
            foreach (GameCard gameCard in Deck)
            {
                ds.InsertGameCard(gameCard);

            }
            initializeGame();

        }
        public void initializeGame()
        {
            

            //We have to unregister to the previous message so we can initialize playerpickedcolor message
            Messenger.Default.Unregister(this);
            Messenger.Default.Register<PickedColorMessage>(this, PlayerPickedColor);

            //Fill Deck with only cards that aren't assigned to anyone yet.
            GameCardDataService ds = new GameCardDataService();
            Deck = ds.getDeck(Game.Id);

            //Set default player rotation, default totalCardsPlayed, default totalTurns
            Rotation = "clockwise";
            TotalCardsPlayed = 0;
            TotalTurns = 1;
           

            //Set default value of cardability used
            CardAbilityUsed = false;

            //Assign our first player
            PlayerTurn = Players[0];

            //Load all player cards in their respective collections
            foreach (Player player in Players)
            {
                LoadPlayerCards(player);

            }
            
        }

        public void Play()
        {
            //Make sure player can't play when it isn't his turn.
            if (PlayerTurn.Id == RealPlayer.Id)
            {
                //Check if there is a card selected.
                if (CurrentCard != null)
                {
                    //Check if the card we played is playable and play it. If it is wild or plus4 we don't want to directly initiate next turn, we need to pick a color.
                    if (CheckCardPlayed(CurrentCard.GameCard, RealPlayer) == true)
                    {
                        if (LastPlayedCard.Card.Kind == "wild" || LastPlayedCard.Card.Kind == "plus4")
                        {
                            return;
                        }
                        else
                        {
                            //If there isn't a winner, continue playing.
                            if (Winner == null)
                            {
                                nextPlayer();
                                Turn();
                            }

                        }
                    }
                }
            }
        }

        public void LoadPlayerCards(Player player)
        {
            GameCardDataService ds = new GameCardDataService();

            //Check if current player is the real player or not.
            if (player.Id == RealPlayer.Id)
            {
                //We clear our hand.
                PlayerHand.Clear();

                //We update our new hand we the new cards.
                foreach (GameCard gameCard in ds.GetPlayerHand(player.Id, Game.Id))
                {
                    PlayerHand.Add(new CombinedPlayerCard(gameCard));
                }
                PlayerHand.GroupBy(x => x.Card.Color);
                //If our new hand contains 0 cards, we won.
                if (PlayerHand.Count == 0)
                {
                    Logs.Add(PlayerTurn.Nickname + " won!");
                    Winner = PlayerTurn;

                    //Send a message to open our result window.
                    Messenger.Default.Send<WinnerMessage>(new WinnerMessage(PlayerTurn));

                    //Unregister from colorpicking
                    Messenger.Default.Unregister(this);

                    //Register so we can receive a message when player exited result window
                    Messenger.Default.Register<EndGameMessage>(this, GameEnded);

                    //Show result window
                    dialogService.ShowResultWindow();
                }
            }
            else {
                //Here we load all cards of the bots.
                switch (player.Nickname)
                    {

                    case "bot 1":
                        Bot1.Clear();
                        foreach (GameCard gameCard in ds.GetPlayerHand(player.Id, Game.Id))
                        {
                            Bot1.Add(new CombinedPlayerCard(gameCard));
                        }
                        if(Bot1.Count == 0){
                            Logs.Add(PlayerTurn.Nickname + " won!");
                            Winner = PlayerTurn;

                        }
                        break;
                    case "bot 2":
                        Bot2.Clear();
                        foreach (GameCard gameCard in ds.GetPlayerHand(player.Id, Game.Id))
                        {
                            Bot2.Add(new CombinedPlayerCard(gameCard));
                        }
                        if (Bot2.Count == 0 )
                        {
                            Logs.Add(PlayerTurn.Nickname + " won!");
                            Winner = PlayerTurn;

                        }
                        break;
                    case "bot 3":
                        Bot3.Clear();
                        foreach (GameCard gameCard in ds.GetPlayerHand(player.Id, Game.Id))
                        {
                            Bot3.Add(new CombinedPlayerCard(gameCard));
                        }
                        if (Bot3.Count == 0)
                        {
                            Logs.Add(PlayerTurn.Nickname + " won!");
                            Winner = PlayerTurn;

                        }
                        break;
                }
                
            }

        }

        public void Turn()
        {
            //TotalTurns + 1 since we are in a new turn.
            TotalTurns = TotalTurns + 1;
            //Check if the special card ability is already used. If false the ability will be used.
            if (CardAbilityUsed == false)
            {
                switch (lastPlayedCard.Card.Kind) { 
                    case "plus4":
                        //Call DrawNewCard and draw 4 cards
                        DrawNewCard(PlayerTurn, 4);
                        //We set CardAbilityUsed on true so next player doesnt have any effects of the abilitycard
                        CardAbilityUsed = true;
                        //Get the next player
                        nextPlayer();
                        //We run Turn again with the next player
                        Turn();
                        //We exit this function
                        return;
                    case "plus2":
                        //Call DrawNewCard and draw 2 cards
                        DrawNewCard(PlayerTurn, 2);
                        CardAbilityUsed = true;
                        nextPlayer();
                        Turn();
                        return;
                    case "switch":  
                        CardAbilityUsed = true;
                     
                        break;
                    case "skip":
                        //We do nothing, player can just not do anything this round
                        //Since we skipped over this player and we already + 1 to turn we do - 1 to negate it.
                        TotalTurns = TotalTurns - 1;
                        CardAbilityUsed = true;
                        nextPlayer();
                        Turn();
                        return;
                }
            }

            
            if (PlayerTurn.Id == RealPlayer.Id)
            {
                //If this turn is the realplayer we want to stop here. After this the bot plays.
                return;
            }

            //We use this boolean to check if the bot played a card or not, if not we draw a card.
            bool CardPlayed = false;

            GameCardDataService ds = new GameCardDataService();

            //Check if it is a real player playing, player will play manually.
            if (PlayerTurn.Id != RealPlayer.Id)
            {
                //Loop through all the cards of the bot
                foreach (GameCard gameCard in ds.GetPlayerHand(PlayerTurn.Id, Game.Id))
                {
                    //Call the checkcardplayed function, this will check if the card is playable. Returns True if a card was played.
                    if (CheckCardPlayed(gameCard, PlayerTurn) == true)
                    {
                        //A card is played so we set this to true.
                        CardPlayed = true;
                        //Break the loop
                        break;
                    }
                }
                
                //If no cards were played, we have to draw a card
                if (CardPlayed == false)
                {
                    //Draw a card
                    DrawNewCard(PlayerTurn);

                    //Check again if bot can play the drawn card
                    foreach (GameCard gameCard in ds.GetPlayerHand(PlayerTurn.Id, Game.Id))
                    {
                        //Call the checkcardplayed function, this will check if the card is playable. Returns True if a card was played.
                        if (CheckCardPlayed(gameCard, PlayerTurn) == true)
                        {
                            //Break the loop
                            break;
                        }
                    }

                }
                if(Winner == null)
                {
                    //Get next player
                    nextPlayer();
                    //Start new turn, only if it is not the real player. Real player will start the turn through playing a card manually. Otherwise we loop infinitly.
                    Turn();
                } else
                {
                    //There is a winner assigned, we send the winner to the resultwindow, unregister previous messages and register to EndGameMessage (So we can close result dialog)
                    Messenger.Default.Send<WinnerMessage>(new WinnerMessage(PlayerTurn));
                    Messenger.Default.Unregister(this);
                    Messenger.Default.Register<EndGameMessage>(this, GameEnded);
                    dialogService.ShowResultWindow();

                }

            }
        }

       

        public void Draw()
        {
            //Only able to draw card when it is your turn.
            if(PlayerTurn.Id == RealPlayer.Id)
            {
                DrawNewCard(RealPlayer);
            }
        }

        public void DrawNewCard(Player player, int amount = 1 )
        {
            GameCardDataService ds = new GameCardDataService();

            //Just an if for the log to make it look prettier.
            if (amount == 1)
            {
                Logs.Add(player.Nickname + " drew " + amount + " card!");
            }
            else
            {
                Logs.Add(player.Nickname + " has to draw " + amount + " cards!");

            }

            //Amount = Cards player has to draw
            for (int i = 0; i < amount; i++)
            {
                //If deck has 4 cards left we reset the deck to avoid index error.
                if(Deck.Count == 4)
                {
                    foreach(GameCard card in ds.getDiscardDeck(Game.Id))
                    {
                        card.IsPlayed = false;
                        ds.UpdatePlayedGameCard(card, Game.Id);

                    }
                    Deck = ds.getDeck(Game.Id);
                }

                //Update drawn card.
                Deck[i].PlayerId = player.Id;
                ds.UpdatePlayedGameCard(Deck[i], Game.Id);

                //When 1 card was drawn (Only happens when player draws himself) check if card will be playable or not, if not skip turn automatically.
                if (amount == 1 && player.Id == RealPlayer.Id)
                {
                    
                    if (Cards[Deck[i].CardId].Color != LastPlayedCard.Card.Color && Cards[Deck[i].CardId].Kind != LastPlayedCard.Card.Kind && Cards[Deck[i].CardId].Color != PickedColor && Cards[Deck[i].CardId].Kind != "plus4" && Cards[Deck[i].CardId].Kind != "wild")
                    {
                        //We want to load deck and PlayerCards here and stop function, otherwise we will load playercards and deck twice.
                        Deck = ds.getDeck(Game.Id);
                        LoadPlayerCards(player);
                        nextPlayer();
                        Turn();
                        return;
                        
                    } else
                    {
                        Deck = ds.getDeck(Game.Id);
                        LoadPlayerCards(player);
                        return;
                    }
                    
                }
               

            }

            //After all cards are drawn we update our deck.
            Deck = ds.getDeck(Game.Id);

            //Update current player cards
            LoadPlayerCards(player);
        

        }

        public bool CheckCardPlayed(GameCard card, Player player)
        {
            GameCardDataService ds = new GameCardDataService();

            if (Cards[card.CardId].Color == LastPlayedCard.Card.Color || Cards[card.CardId].Kind == LastPlayedCard.Card.Kind || Cards[card.CardId].Color == PickedColor || Cards[card.CardId].Kind == "plus4" || Cards[card.CardId].Kind == "wild")
            {
                //If we get here the ability card is used. So we set it on false. If there was no ability card we can still just put it on false.
                CardAbilityUsed = false;

                if (LastPlayedCard.Card.Kind == "wild" || LastPlayedCard.Card.Kind == "plus4")
                {
                    //Since a card was played on the wild card we have to put the pickedcolor back to null.
                    PickedColor = null;
                }
                if (Cards[card.CardId].Kind == "switch")
                {
                    if (Rotation == "clockwise")
                    {
                        Rotation = "counterclockwise";

                    }
                    else
                    {
                        Rotation = "clockwise";
                    }
                } 

                switch (Cards[card.CardId].Kind)
                {
                    case "wild":
                        Logs.Add(PlayerTurn.Nickname + " played a Wild card!");
                        pickColor();
                        break;
                    case "plus4":
                        Logs.Add(PlayerTurn.Nickname + " played a plus 4 card!");
                        pickColor();
                        break;
                    case "plus2":
                        Logs.Add(PlayerTurn.Nickname + " played a "+ Cards[card.CardId].Color + " plus 2 card!");
                        break;
                    case "skip":
                    case "switch":        
                        Logs.Add(PlayerTurn.Nickname + " played a " + Cards[card.CardId].Color + " " +Cards[card.CardId].Kind + " card!");
                        break;
                    default:
                        Logs.Add(PlayerTurn.Nickname + " played a " + Cards[card.CardId].Color + " " + Cards[card.CardId].Kind);
                        break;
                }

                card.IsPlayed = true;
                card.PlayerId = null;
                TotalCardsPlayed = TotalCardsPlayed + 1;
                ds.UpdatePlayedGameCard(card, Game.Id);
                LastPlayedCard = new CombinedPlayerCard(card);

                //A card was played so we want to update this players hand.
                LoadPlayerCards(player);

                return true;
            }

            return false;
        }

        public void nextPlayer()
        {
            //Here we get the next player, clockwise means we are rotating clockwise through players, if a switch card is played we will turn counterclockwise.
            try
            {
                if (Rotation == "clockwise")
                {
                    PlayerTurn = Players[Players.IndexOf(PlayerTurn) + 1];
                }
                else
                {
                    PlayerTurn = Players[Players.IndexOf(PlayerTurn) - 1];
                
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                if (Rotation == "clockwise")
                {
                    PlayerTurn = Players[0];
                }
                else
                {
                    PlayerTurn = Players[Players.Count - 1];
                }

            }
        }

        public void PlayerPickedColor(PickedColorMessage color)
        {
            //When real player picked a color we continue playing.
            PickedColor = color.Color;
            Logs.Add(PlayerTurn.Nickname + " picked color: " + PickedColor);
            dialogService.ClosePickColorWindow();

            //If there isn't a winner, we continue playing.
            if (Winner == null)
            {
                nextPlayer();
                Turn();
            }

        }

        public void pickColor()
        {
            //Pick a color for bots, we get the list of bot cards, group them by color, order them and get the first item. That color we pick.
            if(PlayerTurn.Id != RealPlayer.Id)
            {
                switch (PlayerTurn.Nickname)
                {
                    case "bot 1":
                        var bot1Color = Bot1.GroupBy(x => x.Card.Color).Select(group => new { Color = group.Key, Count = group.Count() }).OrderByDescending(x => x.Count).First();
                        PickedColor = (bot1Color.Color);
                        break;

                    case "bot 2":
                        var bot2Color = Bot2.GroupBy(x => x.Card.Color).Select(group => new { Color = group.Key, Count = group.Count() }).OrderByDescending(x => x.Count).First();
                        PickedColor = (bot2Color.Color);
                        break;

                    case "bot 3":
                        var bot3Color = Bot3.GroupBy(x => x.Card.Color).Select(group => new { Color = group.Key, Count = group.Count() }).OrderByDescending(x => x.Count).First();
                        PickedColor = (bot3Color.Color);
                        break;

                }
                //If wild or plus4 color was picked we will just take a random color.
                if (PickedColor == "wild" || PickedColor == "plus4")
                {
                    List<String> Colors = new List<String>
                {
                    "yellow", "red", "green", "blue"
                };
                    Random random = new Random();
                    PickedColor = Colors[random.Next(4)];
                }

                Logs.Add(PlayerTurn.Nickname + " picked color: " + PickedColor);
            } 
            else
            {
                //Show pickcolorwindow for the real player.
                dialogService.ShowPickColorWindow();
            }

        }

        //When player exited the resultwindow we end up here.
        public void GameEnded(EndGameMessage gameEnde)
        {
            GameCardDataService gameCardDataService = new GameCardDataService();

            //We delete all gamecards
            gameCardDataService.DeleteCard(LastPlayedCard.GameCard);

            PlayerDataService ds = new PlayerDataService();

            //We delete all bots
            foreach (Player player in Players)
            {
                if (player.Id != RealPlayer.Id)
                {
                    ds.DeletePlayer(player);
                }
            }
            //Set all of them back to 0 so they are all empty if player starts a new game.
            Bot1.Clear();
            Bot2.Clear();
            Bot3.Clear();
            PlayerHand.Clear();
            Logs.Clear();
            Players.Clear();
            Deck.Clear();

            //Update our game with the end results.
            Game.EndTime = DateTime.Now;
            Game.TotalCardsPlayed = TotalCardsPlayed;
            Game.TotalTurns = TotalTurns;
            if (Winner.Id == RealPlayer.Id)
            {
                Game.Result = "Win";
            }
            else
            {
                Game.Result = "Loss";
            }
            GameDataService dsGame = new GameDataService();
            dsGame.UpdateGame(Game);

            Winner = null;


            //Close the resultwindow and register back to the mainmenu message, so we can restart a game.
            Messenger.Default.Unregister(this);
            Messenger.Default.Register<Tuple<int, Player>>(this, dataPlayerAndAmount);
            dialogService.CloseResultWindow();
        }

    }
}
