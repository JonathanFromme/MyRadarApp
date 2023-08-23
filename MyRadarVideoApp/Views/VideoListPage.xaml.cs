using MyRadarQuizApp.Models;
using System;
using Acr.UserDialogs;

namespace MyRadarVideoApp.Views;

public partial class VideoListPage : ContentPage
{
    public List<Video> videos { get; set; } = new List<Video>();
    public VideoListPage()
	{
		InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        if (videos == null || videos.Count == 0)
        {
            GetData();
        }
    }

    private async void GetData()
    {
        try
        {
            //Gets the values for the videos
            videos = await App.VideoManager.GetTasksAsync();

            //Formats the time for the videos
            videos.ForEach(video => { video.FormatTime(); });
            videoListView.ItemsSource = videos;

            //If there is no data, presents option to refresh. Hides option if successful.
            if (videos == null || videos.Count == 0)
            {
                lblNoItemsError.IsVisible = true;
                btnRefresh.IsVisible = true;
            }
            else 
            { 
                lblNoItemsError.IsVisible = false;
                btnRefresh.IsVisible = false; 
            } 
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            lblNoItemsError.IsVisible = true;
            btnRefresh.IsVisible = true;    
        }
        //Quick delay to prevent rapid refreshing/make sure "reloading" remains on screen
        Thread.Sleep(1000);

        //Change text back to refresh to show users the loading has ended
        btnRefresh.Text = "Refresh";
    }

    async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        //Go to new page based on clicked video
        await Navigation.PushAsync(new VideoPage(videos)
        {
            BindingContext = e.SelectedItem as Video
        });
    }

    private void btnRefresh_Clicked(object sender, EventArgs e)
    {
        //Set text value of button to "loading" to show feedback to users while loading
        btnRefresh.Text = "Loading";

        //Try to refresh data
        GetData();
    }
}