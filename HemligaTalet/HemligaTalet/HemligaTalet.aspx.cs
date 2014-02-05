using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HemligaTalet.Model;

namespace HemligaTalet
{
    public partial class HemligaTalet : System.Web.UI.Page
    {
        private SecretNumber SN
        {
            get { return Session["SN"] as SecretNumber; }
            set { Session["SN"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SN == null)
            {
                SN = new SecretNumber();
            }
        }

        protected void GuessButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Results.Visible = true;

                if (SN.CanMakeGuess)
                {
                    SN.MakeGuess(int.Parse(GuessTextBox.Text));
                    PrevGuessesLabel.Text = String.Join(", ", SN.PreviousGuesses);

                    if (SN.Outcome == Outcome.Low)
                    {
                        GuessesStatusLabel.Text = String.Format("För lågt!");
                    }

                    else if (SN.Outcome == Outcome.High)
                    {
                        GuessesStatusLabel.Text = String.Format("För högt!");
                    }

                    else if (SN.Outcome == Outcome.PreviousGuess)
                    {
                        GuessesStatusLabel.Text = String.Format("Du har redan gissat på talet!");
                    }


                    else if (SN.Outcome == Outcome.Correct)
                    {
                        GuessesStatusLabel.Text = String.Format(" Grattis, du klarade det på {0} försök, {1} var det hemliga talet", SN.PreviousGuesses.Count().ToString(), SN.Number);
                        GuessButton.Enabled = false;
                        NewNumberButton.Visible = true;
                    }

                    else if (SN.Outcome == Outcome.NoMoreGuesses)
                    {
                        GuessesStatusLabel.Text = String.Format("Du har inga gissningar kvar, {0} var det hemliga talet", SN.Number);
                        GuessButton.Enabled = false;
                        NewNumberButton.Visible = true;
                    }

                    else
                    {
                        throw new ApplicationException();
                    }
                }

                else
                {
                    GuessesStatusLabel.Text = String.Format("Du har inga gissningar kvar, {0} var det hemliga talet", SN.Number);
                    GuessButton.Enabled = false;
                    NewNumberButton.Visible = true;
                }
            }


        }

        protected void NewNumberButton_Click(object sender, EventArgs e)
        {
            SN.Initialize();
            GuessButton.Enabled = true;
            NewNumberButton.Visible = false;
        }
    }
}