using System;
using System.Collections.Generic;
using System.IO;
using Windows.Storage;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
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
        private List<UserData> registeredUsers; 
        public SignUpPage()
        {
            InitializeComponent();
            Loaded += SignUpPage_Loaded;
            GenMale.Checked += Gender_Checked;
            GenFemale.Checked += Gender_Checked;
        }

        private async void SignUpPage_Loaded(Object sender, RoutedEventArgs e)
        {
            StorageFolder localAppFolder = ApplicationData.Current.LocalFolder;
            dynamic file;
            try
            {
                file = await localAppFolder.GetFileAsync("RegisteredUsers.txt");
                using (var reader = await file.OpenReadAsync())
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(List<UserData>));
                    registeredUsers = (List<UserData>) serializer.ReadObject(reader);
                }
            }
            catch (FileNotFoundException)
            {
                
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
            RadioButton btn = (RadioButton) sender;
            _usrGender = btn?.Content?.ToString();
        }
        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog md = new MessageDialog("");
            //UserName Validation
            if (!Regex.IsMatch(UserNameField.Text.Trim(), @"^[A-Za-z_][a-zA-Z0-9_\s]*$"))
            {
                md.Content = "Invalid UserName";
                await md.ShowAsync();
            }

            //Password length Validation
            else if (PasswordField.Password.Length < 6)
            {
                md.Content = "Password length should be minimum of 6 characters!";
                await md.ShowAsync();
            }
            //Gender Selection Empty Validation
            else if (_usrGender == "")
            {
                md.Content = "Please select gender!";
                await md.ShowAsync();
            }
            else if (FirstNameField.Text.Length == 0 || LastNameField.Text.Length == 0)
            {
                md.Content = "Please enter a valid name!";
                await md.ShowAsync();
            }
            else if (CollegeField.Text.Length == 0)
            {
                md.Content = "Please enter your college/university";
                await md.ShowAsync();
            }
            else if (DOBField.Date == DateTime.Now || (DateTime.Now.Year-DOBField.Date.Year) <= 16 )
            {
              md.Content = "Must be in college or of college age";
                await md.ShowAsync();
            }
            else
            {
                UserData nwUsr = new UserData();
                nwUsr.FirstName = FirstNameField.Text;
                nwUsr.LastName = LastNameField.Text;
                nwUsr.UserName = UserNameField.Text;
                nwUsr.Password = PasswordField.Password;
                nwUsr.DOB = DOBField.Date;
                nwUsr.College = CollegeField.Text;
                nwUsr.Gender = _usrGender;
                if (registeredUsers != null)
                {
                    foreach (var UserInfo in registeredUsers)
                    {
                        if (UserInfo.UserName == nwUsr.UserName)
                        {
                            md.Content = "User already exists";
                            await md.ShowAsync();
                            return;
                        }
                    }
                    registeredUsers.Add(nwUsr);
                }
                else
                {
                    registeredUsers = new List<UserData>();
                    registeredUsers.Add(nwUsr);
                }
                StorageFolder localAppFolder = ApplicationData.Current.LocalFolder;
                dynamic file;
                try
                {
                    file = await localAppFolder.GetFileAsync("RegisteredUsers.txt");
                    using (var reader = file.OpenReadAsync())
                    {
                        DataContractSerializer serializer = new DataContractSerializer(typeof (List<UserData>));
                        serializer.WriteObject(reader, registeredUsers);
                    }
                }
                catch (FileNotFoundException)
                {
                    file =
                        await
                            localAppFolder.CreateFileAsync("RegisteredUsers.txt",
                                CreationCollisionOption.ReplaceExisting);
                    using (var reader = await file.OpenReadAsync())
                    {
                        DataContractSerializer serializer = new DataContractSerializer(typeof (List<UserData>));
                        serializer.WriteObject(reader, registeredUsers);
                    }
                }
                finally
                {
                    md.Content = "Congrats, you are now registered";
                    await md.ShowAsync();
                    this.Frame.Navigate(typeof(MainPage), this);
                }
            }
        }
    }
}
