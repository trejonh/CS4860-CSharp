using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using No_More_Ramen.Data;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace No_More_Ramen
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        private List<UserData> _registeredUsers;
        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
            Loaded += MainPage_Loaded;
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
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
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void SignUp_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (SignUpPage), null);
        }

        private UserData FindUser()
        {
            return _registeredUsers.FirstOrDefault(usr => usr.UserName == UserName.Text);
        }

        private async void Login_OnClick(object sender, RoutedEventArgs e)
        {
            if (UserName.Text == "" || PassWord.Password == "") return;
            if (_registeredUsers == null ||
                !_registeredUsers.Any(user => user.UserName == UserName.Text && user.Password == PassWord.Password))
            {
                var md = new MessageDialog("Invalid username/password");
                await md.ShowAsync();
            }
            else
            {
                var curUser = FindUser();
                Frame.Navigate(typeof (PersonalScreen), new UserRecipe(curUser, null));
            }
        }
    }
}
