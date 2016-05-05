using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Storage;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Xml;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using No_More_Ramen.Data;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace No_More_Ramen
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignUpPage
    {
        private string _usrGender = "";
        private List<UserData> _registeredUsers; 
        public SignUpPage()
        {
            InitializeComponent();
            Loaded += SignUpPage_Loaded;
            GenMale.Checked += Gender_Checked;
            GenFemale.Checked += Gender_Checked;
        }

        private async void SignUpPage_Loaded(Object sender, RoutedEventArgs e)
        {
            var localAppFolder = ApplicationData.Current.LocalFolder;
            try
            {
                var file = await localAppFolder.GetFileAsync("RegisteredUsers.txt");
                LoadUsers(file);
            }
            catch (FileNotFoundException)
            {
               await localAppFolder.CreateFileAsync("RegisteredUsers.txt",
                   CreationCollisionOption.ReplaceExisting);
            }
        }

        private async void LoadUsers(IStorageFile file)
        {
            using (var reader = await file.OpenReadAsync())
            {
                if (reader.Size <= 0) return;
                var serializer = new DataContractSerializer(typeof(List<UserData>));
                _registeredUsers =
                    (List<UserData>)serializer.ReadObject(XmlReader.Create(reader.AsStreamForRead()));
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        public void Gender_Checked(object sender, RoutedEventArgs e)
        {
            var btn = (RadioButton) sender;
            _usrGender = btn?.Content?.ToString();
        }
        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            var md = new MessageDialog("");
            var validation = CheckForValidUserData();
            if (validation != "valid")
            {
                md.Content = validation;
                await md.ShowAsync();
                return;
            }
            var nwUsr = new UserData
            {
                FirstName = FirstNameField.Text,
                LastName = LastNameField.Text,
                UserName = UserNameField.Text,
                Password = PasswordField.Password,
                Dob = DOBField.Date,
                College = CollegeField.Text,
                Gender = _usrGender
            };
            if (_registeredUsers != null)
            {
                if (_registeredUsers.Any(userInfo => userInfo.UserName == nwUsr.UserName))
                {
                    md.Content = "User already exists";
                    await md.ShowAsync();
                    return;
                }
                _registeredUsers.Add(nwUsr);
            }
            else
            {
                _registeredUsers = new List<UserData> {nwUsr};
            }
            AddUserToDb(ApplicationData.Current.LocalFolder);
            md.Content = "Congrats, you are now registered";
            await md.ShowAsync();
            var settings = ApplicationData.Current.LocalSettings;
            settings.Values["CheckLogin"] = "Login sucess";
            Frame.Navigate(typeof(PersonalScreen), nwUsr);
        }

        private async void AddUserToDb(IStorageFolder localAppFolder)
        {
            var file =  await localAppFolder.CreateFileAsync("RegisteredUsers.txt",
                CreationCollisionOption.ReplaceExisting);
            using (var reader = await file.OpenStreamForWriteAsync())
            {
                var serializer = new DataContractSerializer(typeof(List<UserData>));
                serializer.WriteObject(reader, _registeredUsers);

            }
        }
        private string CheckForValidUserData()
        {
            if (!Regex.IsMatch(UserNameField.Text.Trim(), @"^[A-Za-z_][a-zA-Z0-9_\s]*$"))
                return "Improper username";
            if (PasswordField.Password.Length < 6)
                return "Password length should be minimum of 6 characters!";
            if (_usrGender == "")
                return "Please select gender!";
            if (FirstNameField.Text.Length == 0 || LastNameField.Text.Length == 0)
               return "Please enter a valid name!";
            if (CollegeField.Text.Length == 0)
                return "Please enter your college/university";
            if (DOBField.Date == DateTime.Now || (DateTime.Now.Year - DOBField.Date.Year) <= 16)
               return "Must be in college or of college age";
            return "valid";
        }
    }
}
