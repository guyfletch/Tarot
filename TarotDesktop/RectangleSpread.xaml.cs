using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TarotFunctions;

namespace TarotDesktop
{
    /// <summary>
    /// Interaction logic for RectangleSpread.xaml
    /// </summary>
    public partial class RectangleSpread : UserControl
    {
        private List<Card> cards;
        private int active;
        private readonly Deck deck;
        public string SpreadName => "Rectangle Spread";
        private List<Image> CardImages => new() { Card1, Card2, Card3, Card4, Card5 };

        public RectangleSpread(Deck deck)
        {
            InitializeComponent();
            cards = new List<Card>();
            active = 0;
            this.deck = deck;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            foreach (var image in CardImages)
            {
                image.Source = null;
            }
            cards = new List<Card>();
            active = 0;
        }

        private void ShowCard_Click(object sender, RoutedEventArgs e)
        {
            if (cards.IsNullOrEmpty())
            {
                cards = deck.Spread(CardImages.Count).ToList();
            }
            if (active == cards.Count) return;
            var activeCard = CardImages[active];
            var bmImage = new BitmapImage(new Uri(cards[active].FileLoc));
            var transform = cards[active].Reversed ? new RotateTransform(180, bmImage.Width / 2, bmImage.Height / 2) : new RotateTransform(0);
            var tBitmap = new TransformedBitmap(bmImage, transform);
            activeCard.Source = tBitmap;
            active++;
        }
    }
}
