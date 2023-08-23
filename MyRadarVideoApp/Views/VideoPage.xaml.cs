using MyRadarQuizApp.Models;

namespace MyRadarVideoApp.Views;

public partial class VideoPage : ContentPage
{
    public List<Video> videos { get; set; } = new List<Video>();
    public VideoPage(List<Video> _videos)
	{
		InitializeComponent();
        videos = _videos;
	}

    //Go to the next video
    private async void NextVideo_Clicked(object sender, EventArgs e)
    {
        try
        {
            //If at last video, loop around to first video
            if (videos.Last().title == lblTitle.Text)
            {
                await Navigation.PushAsync(new VideoPage(videos)
                {
                    BindingContext = videos.First()
                });
            }
            //Find current place in list, load next video
            else
            {
                await Navigation.PushAsync(new VideoPage(videos)
                {
                    BindingContext = videos.ElementAt(videos.FindIndex(x => x.title == lblTitle.Text) + 1)
                });
            }
        }
        catch (Exception ex) 
        {
           await DisplayAlert("Alert", String.Format("Unable to load next item. Details for programmer: {0}", ex.ToString()), "OK");
        }
    }

    //Go to previous video
    private async void PreviousVideo_Clicked(object sender, EventArgs e)
    {
        try
        {
            //If at first video, loop around to last video
            if (videos.First().title == lblTitle.Text)
            {
                await Navigation.PushAsync(new VideoPage(videos)
                {
                    BindingContext = videos.Last()
                });
            }
            //Find current place in list, load video from before it
            else
            {
                await Navigation.PushAsync(new VideoPage(videos)
                {
                    BindingContext = videos.ElementAt(videos.FindIndex(x => x.title == lblTitle.Text) - 1)
                });
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Alert", String.Format("Unable to load next item. Details for programmer: {0}", ex.ToString()), "OK");
        }
    }

    //Return to home page
    private async void Home_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PopToRootAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Alert", String.Format("Unable to return to home page. Details for programmer: {0}", ex.ToString()), "OK");
        }
    }
}