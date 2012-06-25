namespace MovieBooking.MovieListWAS
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MBMovieListSvcPInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.MBMovieListSvcInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // MBMovieListSvcPInstaller
            // 
            this.MBMovieListSvcPInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.MBMovieListSvcPInstaller.Password = null;
            this.MBMovieListSvcPInstaller.Username = null;
            // 
            // MBMovieListSvcInstaller
            // 
            this.MBMovieListSvcInstaller.ServiceName = "MBMovieListService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.MBMovieListSvcPInstaller,
            this.MBMovieListSvcInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller MBMovieListSvcPInstaller;
        private System.ServiceProcess.ServiceInstaller MBMovieListSvcInstaller;
    }
}