using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MovieBooking.BLL.Entities;


namespace MovieBooking.UI.Maintenance.Movie
{
    public partial class MovieUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRetrieve_Click(object sender, EventArgs e)
        {
            MovieRepository MovieRep = new MovieRepository();
            int MovieID = Convert.ToInt32(this.MovNameCombo.SelectedValue);
            var Movie  = MovieRep.FindbyId(MovieID);
            if (Movie.LanguageID.Equals("1"))
            {
                Movie.LanguageID = "English";
            }
            else if (Movie.LanguageID.Equals("2"))
            {
                Movie.LanguageID="Tamil";
            }
            else if (Movie.LanguageID.Equals("3"))
            {
                Movie.LanguageID="Chinese";
            }
            else
            {
                Movie.LanguageID="Malay";
            }
            LanguageCombo.SelectedValue = Movie.LanguageID;
            txtDuration.Text = Movie.RunningDuration.ToString();
            ActiveCombo.SelectedValue = Movie.Active.ToString();
            if (!String.IsNullOrWhiteSpace(Movie.genre))
            {
                GenreCombo.SelectedValue = Movie.genre.ToString();
            }
            String[] Rate = Movie.RatingID.Split('/');
            RatingCombo.SelectedValue = Rate[0];
            txtmovDesc.Text = Movie.Description;
            if (!String.IsNullOrWhiteSpace(Movie.CastDescription))
            {
                String[] ArrCast = Movie.CastDescription.Split(',');
                String[] CastsDirector = ArrCast[0].Split('-');
                String[] CastsStars = ArrCast[1].Split('-');
                String[] CastsScreenPlay = ArrCast[2].Split('-');
                CastCombo2.SelectedValue = CastsDirector[0];
                CastCombo1.SelectedValue = CastsStars[0];
                CastCombo3.SelectedValue = CastsScreenPlay[0];
                txtCast1.Text = CastsDirector[1];
                txtCast2.Text = CastsStars[1];
                txtCast3.Text = CastsScreenPlay[1];
            }

         
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            int LangID = 0;
            bool Act = Convert.ToBoolean(this.ActiveCombo.SelectedValue);
            if (this.LanguageCombo.SelectedValue.Equals("English"))
            {
                LangID = 1;
            }
            else if (this.LanguageCombo.SelectedValue.Equals("Tamil"))
            {
                LangID = 2;
            }
            if (this.LanguageCombo.SelectedValue.Equals("Chinese"))
            {
                LangID = 3;
            }
            else
            {
                LangID = 4;
            }

            MovieBooking.BLL.Entities.Movie movie = new MovieBooking.BLL.Entities.Movie()
            {
                ID=Convert.ToInt32(this.MovNameCombo.SelectedValue),
                MovieName = this.MovNameCombo.SelectedItem.ToString(),
                Description = this.txtmovDesc.Text.ToString(),
                RatingID = this.RatingCombo.SelectedValue.ToString(),
                LanguageID = LangID.ToString(),
                RunningDuration = Convert.ToInt16(this.txtDuration.Text),
                Active = Act,
                genre = this.GenreCombo.SelectedValue.ToString(),
                CastDescription = ((this.CastCombo2.SelectedValue + "-" + this.txtCast1.Text) + "," +
                (this.CastCombo1.SelectedValue + "-" + this.txtCast2.Text) + "," + (this.CastCombo3.SelectedValue + "-" + this.txtCast3.Text)).ToString()

            };
            MovieRepository newMovie = new MovieRepository();
            newMovie.Update(movie);
        }
        private void ClearFields()
        {
            txtmovDesc.Text = string.Empty;
            txtDuration.Text = string.Empty;
            txtCast1.Text = string.Empty;
            txtCast2.Text = string.Empty;
            txtCast3.Text = string.Empty;

        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int LangID = 0;
            bool Act = Convert.ToBoolean(this.ActiveCombo.SelectedValue);
            if (this.LanguageCombo.SelectedValue.Equals("English"))
            {
                LangID = 1;
            }
            else if (this.LanguageCombo.SelectedValue.Equals("Tamil"))
            {
                LangID = 2;
            }
            if (this.LanguageCombo.SelectedValue.Equals("Chinese"))
            {
                LangID = 3;
            }
            else
            {
                LangID = 4;
            }

            MovieBooking.BLL.Entities.Movie movie = new MovieBooking.BLL.Entities.Movie()
            {
                ID = Convert.ToInt32(this.MovNameCombo.SelectedValue),
                MovieName = this.MovNameCombo.SelectedItem.ToString(),
                Description = this.txtmovDesc.Text.ToString(),
                RatingID = this.RatingCombo.SelectedValue.ToString(),
                LanguageID = LangID.ToString(),
                RunningDuration = Convert.ToInt16(this.txtDuration.Text),
                Active = Act,
                genre = this.GenreCombo.SelectedValue.ToString(),
                CastDescription = ((this.CastCombo2.SelectedValue + "-" + this.txtCast1.Text) + "," +
                (this.CastCombo1.SelectedValue + "-" + this.txtCast2.Text) + "," + (this.CastCombo3.SelectedValue + "-" + this.txtCast3.Text)).ToString()

            };
            MovieRepository newMovie = new MovieRepository();
            bool ret=newMovie.Delete(movie);
            if (ret)
            {
                ClearFields();
            }
        }

      


    }
}