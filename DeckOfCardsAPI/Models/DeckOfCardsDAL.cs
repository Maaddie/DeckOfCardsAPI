using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DeckOfCardsAPI.Models
{
    public class DeckOfCardsDAL
    {
        public DeckOfCards CreateDeck()
        {
            string url = "https://deckofcardsapi.com/api/deck/new/";

            //Next we need to create our request
            HttpWebRequest request = WebRequest.CreateHttp(url);

            //Next, if your API needs any kind of login or key, that may go here
            //SWAPI doesn't need anything so we're good.

            //Now we're ready to send off our request and grab the server's response
            //Inside our response, the resulting data lives.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Pull the result into a stream reader which will then give us a string
            StreamReader rd = new StreamReader(response.GetResponseStream());

            //Grab our response string - "ReadToEnd" starts at the top of our response file and returns each line until it hits the end.
            string JSON = rd.ReadToEnd();
            rd.Close();

            DeckOfCards deck = JsonConvert.DeserializeObject<DeckOfCards>(JSON);

            return deck;
        }

        public DrawnCards DrawCards(string deckId)
        {
            string url = $"https://deckofcardsapi.com/api/deck/{deckId}/draw/?count=5";

            //Next we need to create our request
            HttpWebRequest request = WebRequest.CreateHttp(url);

            //Next, if your API needs any kind of login or key, that may go here
            //SWAPI doesn't need anything so we're good.

            //Now we're ready to send off our request and grab the server's response
            //Inside our response, the resulting data lives.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Pull the result into a stream reader which will then give us a string
            StreamReader rd = new StreamReader(response.GetResponseStream());

            //Grab our response string - "ReadToEnd" starts at the top of our response file and returns each line until it hits the end.
            string JSON = rd.ReadToEnd();
            rd.Close();

            DrawnCards cards = JsonConvert.DeserializeObject<DrawnCards>(JSON);

            return cards;
        }
    }
}
