using MVVM.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace MVVM.Views;

public partial class DBListPage : ContentPage
{
	public DBListPage()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        friendsList.ItemsSource = App.Database.GetItems();
        base.OnAppearing();
    }
    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Friend selectedFriend = e.SelectedItem as Friend;
        DBFriendPage friendPage = new DBFriendPage();
        friendPage.BindingContext= selectedFriend;
        await Navigation.PushAsync(friendPage);
    }

    private async void CreateFriend(object sender, EventArgs e)
    {
        Friend friend = new Friend();
        DBFriendPage friendPage = new DBFriendPage();
        friendPage.BindingContext= friend;
        await Navigation.PushAsync(friendPage);
    }
    [Obsolete]
    private void SortName(object sender, EventArgs e)
    {
        friendsList.ItemTemplate = new DataTemplate(() =>
        {
            Label labelList = new Label { FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) };
            labelList.SetBinding(Label.TextProperty, "Name");
            return new ViewCell { View = new HorizontalStackLayout { Children = { labelList } } };
        });
    }
    [Obsolete]
    private void SortEmail(object sender, EventArgs e)
    {
        friendsList.ItemTemplate = new DataTemplate(() =>
        {
            Label labelList = new Label { FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) };
            labelList.SetBinding(Label.TextProperty, "Email");
            return new ViewCell { View = new HorizontalStackLayout { Children = { labelList } } };
        });
    }
    [Obsolete]
    private void SortPhone(object sender, EventArgs e)
    {
        friendsList.ItemTemplate = new DataTemplate(() =>
        {
            Label labelList = new Label { FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) };
            labelList.SetBinding(Label.TextProperty, "Phone");
            return new ViewCell { View = new HorizontalStackLayout { Children = { labelList } } };
        });
    }
    [Obsolete]
    private void SortAge(object sender, EventArgs e)
    {
        friendsList.ItemTemplate = new DataTemplate(() =>
        {
            Label labelList = new Label { FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) };
            labelList.SetBinding(Label.TextProperty, "Age");
            return new ViewCell { View = new HorizontalStackLayout { Children = { labelList } } };
        });
    }
    [Obsolete]
    private void SortImage(object sender, EventArgs e)
    {
        friendsList.ItemTemplate = new DataTemplate(() =>
        {
            Friend friend = (Friend)BindingContext;
            Image image = new Image();
            image.Source = ImageSource.FromStream(()=>new MemoryStream(friend.Img));
            return new ViewCell { View = new HorizontalStackLayout { Children = { image } } };
        });
    }
}