
using System.Collections.Specialized;

namespace Suhorukov.Network.Socialcat.Interfaces
{
    /// <summary>
    /// Общий интерфейс для всех социальных сетей
    /// </summary>
    public interface ISocialSession
    {
        /// <summary>
        /// Логин, с которым мы подключены
        /// </summary>
        string Login { get;}

        /// <summary>
        /// Пароль, с которым мы подключены
        /// </summary>
        string Password { get; }

        string BaseUri { get; }

        /// <summary>
        /// Куки для запросов
        /// </summary>
        NameValueCollection Cookies { get; }

        /// <summary>
        /// аввторизация в социальной сети
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        void Authorize(string userName, string password);

        /// <summary>
        /// После авторизация осуществляет запрос к соцсети
        /// </summary>
        /// <param name="path">Путь относительно корня сайта</param>
        /// <param name="parameters">Параметры</param>
        /// <returns>Ответ на запрос</returns>
        string PerformRequest(string path,NameValueCollection parameters);

        /// <summary>
        /// Флаг того что мы подключены
        /// </summary>                        
        bool IsConnected { get; }
    }
}
