using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using No_More_Ramen.Data;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace No_More_Ramen
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PersonalScreen
    {
        private List<UserData> _registeredUsers;
        public PersonalScreen()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;
            Loaded += PersonalScreen_Loaded;
        }

        private async void PersonalScreen_Loaded(object sender, RoutedEventArgs e)
        {
            var localAppFolder = ApplicationData.Current.LocalFolder;
            try
            {
                var file = await localAppFolder.GetFileAsync("RegisteredUsers.txt");
                LoadRegisteredUsers(file);
            }
            catch (FileNotFoundException)
            {
                await localAppFolder.CreateFileAsync("RegisteredUsers.txt",
                    CreationCollisionOption.ReplaceExisting);
            }
        }

        private async void LoadRegisteredUsers(IStorageFile file)
        {
            using (var reader = await file.OpenReadAsync())
            {
                if (reader.Size <= 0) return;
                var serializer = new DataContractSerializer(typeof(List<UserData>));
                _registeredUsers =
                    (List<UserData>)serializer.ReadObject(XmlReader.Create(reader.AsStreamForRead()));
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            /*var param = e.Parameter;
            var type = e?.Parameter?.GetType();
            var md = new MessageDialog(type?.FullName);
            //await md.ShowAsync();
            if (param is UserData)
            {
                UserDetails.DataContext = param;
                return;
            }
            var usr = _registeredUsers?.Select(user => user.UserName == (string) param).First();
            md.Content = usr?.GetType()?.FullName;
            await md.ShowAsync();
            UserDetails.DataContext = usr;*/
        }



        private void LeftButtonTapped_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //Slidein.GoToMenuState(ActiveState.Left);
        }

        private void RightButtonTapped_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //Slidein.GoToMenuState(ActiveState.Right);
        }

        private void SortByComboBox_SelectionChanged(object sender, Windows.UI.Xaml.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
