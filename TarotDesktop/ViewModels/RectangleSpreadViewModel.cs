using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TarotFunctions;

namespace TarotDesktop
{
    public class RectangleSpreadViewModel : SpreadViewModel
    {
        public override string SpreadName => "Rectangular";
        private List<Card> cards;
        private int active;
        private readonly Deck deck;
        private TransformedBitmap back;
        private List<TransformedBitmap> CardImages => new() { Card1, Card2, Card3, Card4, Card5 };
        private TransformedBitmap card1;
        public TransformedBitmap Card1
        {
            get { return card1; }
            set { card1 = value; NotifyOfPropertyChange(); }
        }
        private TransformedBitmap card2;
        public TransformedBitmap Card2
        {
            get { return card2; }
            set { card2 = value; NotifyOfPropertyChange(); }
        }
        private TransformedBitmap card3;
        public TransformedBitmap Card3
        {
            get { return card3; }
            set { card3 = value; NotifyOfPropertyChange(); }
        }
        private TransformedBitmap card4;
        public TransformedBitmap Card4
        {
            get { return card4; }
            set { card4 = value; NotifyOfPropertyChange(); }
        }
        private TransformedBitmap card5;
        public TransformedBitmap Card5
        {
            get { return card5; }
            set { card5 = value; NotifyOfPropertyChange(); }
        }

        public RectangleSpreadViewModel(Deck deck)
        {
            cards = new List<Card>();
            active = 0;
            this.deck = deck;
            var backImage = new BitmapImage(new Uri(deck.Back.FileLoc));
            back = new TransformedBitmap(backImage, new RotateTransform(0));
            CardBacks();
        }

        public void ShowCard()
        {
            if (cards.IsNullOrEmpty())
            {
                cards = deck.Spread(CardImages.Count).ToList();
            }
            if (active == cards.Count) return;
            var bmImageSource = new BitmapImage(new Uri(cards[active].FileLoc));
            var transform = cards[active].Reversed ? new RotateTransform(180, bmImageSource.Width / 2, bmImageSource.Height / 2) : new RotateTransform(0);
            var tBitmap = new TransformedBitmap(bmImageSource, transform);
            switch (active)
            {
                case 0:
                    Card1 = tBitmap;
                    break;
                case 1:
                    Card2 = tBitmap;
                    break;
                case 2:
                    Card3 = tBitmap;
                    break;
                case 3:
                    Card4 = tBitmap;
                    break;
                case 4:
                    Card5 = tBitmap;
                    break;
            }
            active++;
        }

        public void ResetSpread()
        {
            
            cards = new List<Card>();
            active = 0;
            CardBacks();
        }

        private void CardBacks()
        {
            Card1 = back;
            Card2 = back;
            Card3 = back;
            Card4 = back;
            Card5 = back;
        }
    }
}
