using BLL.Entities.Interface;

namespace BLL.Entities
{
    public class MessageEntity : IBllEntity
    {
        #region Properties

        public int id { get; set; }

        public string MessageBody { get; set; }

        #endregion
    }
}