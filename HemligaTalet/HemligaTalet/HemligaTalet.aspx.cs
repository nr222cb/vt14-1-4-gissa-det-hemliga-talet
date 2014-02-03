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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GuessButton_Click(object sender, EventArgs e)
        {
            var guess = new SecretNumber();
            guess.MakeGuess(3);
            guess.MakeGuess(66);
            guess.MakeGuess(55);

        }
    }
}