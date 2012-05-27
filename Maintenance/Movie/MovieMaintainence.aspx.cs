using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MovieBooking.BLL.Entities;


namespace MovieBooking.UI.Maintenance.Movie
{
    public partial class MovieMaintainence : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void ClearFields()
        {
            txtmovDesc.Text = string.Empty;
            TxtMovName.Text = string.Empty;
            txtDuration.Text = string.Empty;
            txtCast1.Text = string.Empty;
            txtCast2.Text = string.Empty;
            txtCast3.Text = string.Empty;

        }

        protected void BtnCreate_Click(object sender, EventArgs e)
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
                MovieName = this.TxtMovName.Text.ToString(),
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
            MovieItemRepository newMovieItem = new MovieItemRepository();
            newMovie.Insert(movie);
            int MovieID = newMovie.FindIdbyName(movie.MovieName);
            MovieBooking.BLL.Entities.Movie_Item movieItem;
            MovieBooking.BLL.Entities.Movie_Item movieItem1;
            MovieBooking.BLL.Entities.Movie_Item movieItem2;

            movieItem = new MovieBooking.BLL.Entities.Movie_Item()
            {
                MovieID = MovieID,
                CastID = 0.ToString(),
                CastName = this.CastCombo2.SelectedValue,
                Description = this.txtCast1.Text
            };
            newMovieItem.Insert(movieItem);


            movieItem1 = new MovieBooking.BLL.Entities.Movie_Item()
            {
                MovieID = MovieID,
                CastID = 1.ToString(),
                CastName = this.CastCombo1.SelectedValue,
                Description = this.txtCast2.Text


            };
            newMovieItem.Insert(movieItem1);


            movieItem2 = new MovieBooking.BLL.Entities.Movie_Item()
           {
               MovieID = MovieID,
               CastID = 2.ToString(),
               CastName = this.CastCombo3.SelectedValue,
               Description = this.txtCast3.Text


           };
            newMovieItem.Insert(movieItem2);




        }
    }
}