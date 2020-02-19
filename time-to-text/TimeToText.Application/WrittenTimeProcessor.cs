namespace TimeToSpeech.Application
{
    public class WrittenTimeProcessor
    {
        /// <summary>
        /// Present time in a more "Human Friendly" way
        /// </summary>
        /// <param name="time">The format is [hh][mm] or [hh]:[mm].</param>
        /// <returns>Human friendly time</returns>
        public string Process(string time)
        {
            return new Time(time).ToString();
        }
    }
}
