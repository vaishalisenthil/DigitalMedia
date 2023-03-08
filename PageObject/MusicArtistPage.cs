using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMedia.PageObject
{
    public class MusicArtistPage
    {
        public string BaseUrl { get; set; } = "https://www.capitalfm.com/";
        public string ConsentAcceptpg = "//button[@title='ACCEPT']";
        public string NowPlayingArtistpg = "//div[@class='track__track-info']//div[2]";
        public string SeeMorepg = "//a[normalize-space()='See more »']"; //"//a[@class='see_more']";
        public string artistSearch1 = "//h3[contains(.,'";
        public string artistSearch2 = "')]/following-sibling::div/p[@class='publish_date visible']";
        public string artistSearch3 = "')]";
        public string Iframepg = "sp_message_iframe_734235";
        public string LastPlayedSongpg = "//body/section[@role='main']/div[@class='row row3']/div[@class='level3_wrapper']/div[1]";
        //public string LastPlayedTime = "//h3[contains(.,'Justin Bieber')]/following-sibling::div/p[@class='publish_date visible']";
    }
}
