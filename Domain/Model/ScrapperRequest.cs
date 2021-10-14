namespace Domain.Model
{
    public class ScrapperRequest
    {
        public ScrapperRequest(string textToBeSearched, int noOfResultsToBeReturned)
        {
            this.TextToBeSearched = textToBeSearched.Replace(" ", "+");
            this.NoOfResultsToBeReturned = noOfResultsToBeReturned;
        }
        public string TextToBeSearched { get; protected set; }
        public int NoOfResultsToBeReturned { get; protected set; }
        public string QueryString { get { return string.Format("?q={0}&num={1}", this.TextToBeSearched , this.NoOfResultsToBeReturned); } }
      
    }
}
