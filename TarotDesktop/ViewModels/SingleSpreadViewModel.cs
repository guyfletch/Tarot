﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TarotFunctions;

namespace TarotDesktop
{
    public class SingleSpreadViewModel : SpreadViewModel
    {
        public override string SpreadName => "Single";
        private List<Card> cards;
        private int active;
        private readonly Deck deck;
        private readonly TransformedBitmap back;
        private List<TransformedBitmap> CardImages => new() { Card1 };
        private TransformedBitmap card1;
        public TransformedBitmap Card1
        {
            get { return card1; }
            set { card1 = value; NotifyOfPropertyChange(); }
        }

        public SingleSpreadViewModel(Deck deck)
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
            Card1 = tBitmap;
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
        }
    }
}
