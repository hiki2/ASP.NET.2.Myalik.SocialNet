using ASP.NET._2.Myalik.SocialNet.Models.Interface;

namespace ASP.NET._2.Myalik.SocialNet.Models
{
    public class MessageViewModel : IViewModel
    {
        #region Properties

        public int id { get; set; }

        public string MessageBody { get; set; }

        #endregion
    }
}