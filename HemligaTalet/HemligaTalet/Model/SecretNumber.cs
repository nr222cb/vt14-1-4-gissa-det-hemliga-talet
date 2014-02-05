using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HemligaTalet.Model
{
    public enum Outcome
    {
        Indefinite,
        Low,
        High,
        Correct,
        NoMoreGuesses,
        PreviousGuess
    }

    public class SecretNumber
    {
        // Fält
        private int _number;
        private List<int> _previousGuesses;
        public const int MaxNumberOfGuesses = 7;

        // Egenskaper
        public bool CanMakeGuess
        {
            get { return Count < MaxNumberOfGuesses; }
        }

        protected int Count { get; private set; }
        public int? Number { get { if ((CanMakeGuess) && (Outcome != Model.Outcome.Correct)) { return null; } else { return _number; } } }
        public Outcome Outcome { get; private set; }

        public IEnumerable<int> PreviousGuesses
        {
            get { return _previousGuesses.AsReadOnly(); }
        }

        // Konstruktor
        public SecretNumber()
        {
            _previousGuesses = new List<int>(MaxNumberOfGuesses);
            Initialize();
        }

        // Metoder
        public void Initialize()
        {
            // Slumpa fram ett tal
            Random _random = new Random();
            _number = _random.Next(1, 101);
            Count = 0;

            // Eventuella element i _previousGuesses tas bort genom anrop av metoden Clear.
            // Egenskapen Outcome tilldelas värdet Indefinite.
            _previousGuesses.Clear();
            Outcome = Model.Outcome.Indefinite;
        }

        public Outcome MakeGuess(int guess)
        {
            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException("Talet måste vara inom det slutna intervallet mellan 1 och 100");
            }

            if (PreviousGuesses.Contains(guess))
                {
                    return Outcome = Model.Outcome.PreviousGuess;
                }

            // Räkna upp antalet gissningar
            Count++;

            // Lägg till gissningen i sparade gissningar
            _previousGuesses.Add(guess);

            if (CanMakeGuess)
            {

                if (guess > _number)
                {
                    return Outcome = Model.Outcome.High;
                }
                
                else if (guess < _number)
                {
                    return Outcome = Model.Outcome.Low;
                }
                
                else
                {
                    return Outcome = Model.Outcome.Correct;
                }

            }

            else
            {
                return Outcome= Model.Outcome.NoMoreGuesses;
            }
        }

    }
}