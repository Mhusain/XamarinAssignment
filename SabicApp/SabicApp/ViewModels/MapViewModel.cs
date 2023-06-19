using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SabicApp.ViewModels
{
    public class MapViewModel : BaseViewModel
    {
        private ObservableCollection<Pin> _pins;
        public ObservableCollection<Pin> Pins
        {
            get { return _pins; }
            set
            {
                _pins = value;
                OnPropertyChanged(nameof(Pins));
            }
        }

        public MapViewModel()
        {
            Pins = new ObservableCollection<Pin>
            {
                new Pin
                {
                    Label = "Location 1",
                    Position = new Position(37.790978, -122.401236)
                },
                new Pin
                {
                    Label = "Location 2",
                    Position = new Position(37.785717, -122.411420)
                },
                new Pin
                {
                    Label = "Location 3",
                    Position = new Position(37.792875, -122.393345)
                }
            };

            //TODO - Bind above pins as per the locations given to the Page

        }

        
    }
}

