using LocalDatabase.Models;
using LocalDatabase.Services;
using LocalDatabase.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace LocalDatabase.ViewModels
{
    public class AlbumesViewModel : BaseViewModel
    {
        #region Services        
        private readonly AlbumService dataServiceAlbumes;
        private readonly ArtistaService dataServiceArtistas;
        #endregion Services

        #region Attributes

        private ObservableCollection<Album> albumes;

        #endregion Attributes

        #region Properties


        public ObservableCollection<Album> Albumes
        {
            get { return this.albumes; }
            set { SetValue(ref this.albumes, value); }
        }




        #endregion Properties

        #region Command

        public ICommand NeWAlbumCommand
        {
            get
            {
                return new Command(NeWAlbum);
            }
        }

        public ICommand LoadbumesCommand
        {
            get
            {
                return new Command(LoadAlbumes);
            }
        }
        #endregion

        #region Constructor
        public AlbumesViewModel()
        {
            this.dataServiceArtistas = new ArtistaService();
            this.dataServiceAlbumes = new AlbumService();

            //this.CreateArtistas();


            this.LoadAlbumes();


        }
        #endregion Constructor



        #region Methods

        private void NeWAlbum()
        {
            Application.Current.MainPage.Navigation.PushAsync(new AlbumPage());



        }
        private void LoadAlbumes()
        {
            var albumesDB = this.dataServiceAlbumes.Get();
            this.Albumes = new ObservableCollection<Album>(albumesDB);
        }

        private void CreateArtistas()
        {
            var artistas = new List<Artista>()
            {
                new Artista { Nombre = "Ricardo Arjona" },
                new Artista { Nombre = "Kalimba" },
                new Artista { Nombre = "Luis Miguel" }
            };

            this.dataServiceArtistas.CreateList(artistas);
        }
        #endregion Methods
    }
}

