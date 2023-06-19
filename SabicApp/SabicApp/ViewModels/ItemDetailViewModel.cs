using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using SabicApp.Models;
using Xamarin.Forms;

namespace SabicApp.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private int itemId;
        private string text;
        private string description;
        public int Id { get; set; }
        private bool _isSuccessAlertVisible;
        public bool IsSuccessAlertVisible
        {
            get { return _isSuccessAlertVisible; }
            set
            {
                _isSuccessAlertVisible = value;
                OnPropertyChanged(nameof(IsSuccessAlertVisible));
            }
        }

        public ICommand SaveCommand { get; private set; }

        public ItemDetailViewModel()
        {
            SaveCommand = new Command(ExecuteSaveCommand);
        }

        private void ExecuteSaveCommand()
        {
            // Save the note to the database
            App.Database.SaveItemAsync(new Item
            {
                Text = text,
                Description = description
            });

            IsSuccessAlertVisible = true;
            // Optional: You can also add a delay to hide the alert automatically after a certain duration.
            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                IsSuccessAlertVisible = false;
                return false;
            });
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }        

        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await App.Database.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}


