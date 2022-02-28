using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
//using Microsoft.Office.Interop.Word;

namespace ApplicationRepairPhoneEntityFramework
{
    public static class SendEmail
    {





        public static async Task<bool> SendEmailAsync(string mailTo, string subject, string body)
        {
            try
            {

                MailAddress from = new MailAddress("ServiceCenterEFWPF@yandex.ru", "Сервсиный центр");
                MailAddress to = new MailAddress(mailTo);
                MailMessage message = new MailMessage(from, to);
                message.Subject = subject;
                message.Body = body;
                SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587);
                smtp.Credentials = new NetworkCredential("ServiceCenterEFWPF", "Assassins2012");
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
                return true;
            }
            catch (Exception) 
            {
                return false;
                throw new Exception("При отправке электронного письма произошла ошибка!");
            
            }





        }


        public static async Task<bool> SendEmailAsync(string mailTo, string subject, string body, bool file, string path)
        {
            try
            {

                MailAddress from = new MailAddress("ServiceCenterEFWPF@yandex.ru", "Сервсиный центр");
                MailAddress to = new MailAddress(mailTo);
                MailMessage message = new MailMessage(from, to);
                if(file)
                message.Attachments.Add(new Attachment(path));
                message.Subject = subject;
                message.Body = body;
                SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587);
                smtp.Credentials = new NetworkCredential("ServiceCenterEFWPF", "Assassins2012");
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw new Exception("При отправке электронного письма произошла ошибка!");

            }





        }

        public static string AddEmployeeMail(string Fio, string PositionName, string ID_Employee, string Password_Employee, string SeriesNumber, string Address, string NumberPhone)
        {
            string message = $"{Fio}, вы успешно приняты на работу на позицию '{PositionName}'." +
                       $" \n Логин для входа в систему: {ID_Employee} \n Пароль: {Password_Employee} \n" +
                       $"Проверьте еще раз коррктность введенной информации: \n" +
                       $"Фамилия Имя Отчество: {Fio} \n" +
                       $"Должность: {PositionName} \n" +
                       $"Серия и номер паспорта: {SeriesNumber} \n" +
                       $"Адрес: {Address} \n" +
                       $"Номер телефона: {NumberPhone} \n" +
                       $"В случае несоотвествия обратитесь к директору \n" +
                       $"Надеемся на пладотворное сотрудничество. На это письмо отвечать не нужно.";

            return message;

        }

        public static string UpdateEmployeeMail(string Fio, string PositionName, string ID_Employee, string Password_Employee, string SeriesNumber, string Address, string NumberPhone)
        {
            string message = $"{Fio}, директор обновил ваши данные. ф" +
                       $"Проверьте коррктность введенной информации: \n" +
                       $"Фамилия Имя Отчество: {Fio} \n" +
                       $"Должность: {PositionName} \n" +
                       $"Серия и номер паспорта: {SeriesNumber} \n" +
                       $"Адрес: {Address} \n" +
                       $"Номер телефона: {NumberPhone} \n" +
                       $"В случае несоотвествия обратитесь к директору \n" +
                       $"На это письмо отвечать не нужно.";

            return message;

        }

        public static string ChangeStatusOrder(string fio, string id_order, string status) 
        {
            string message = $"{fio}, статус вашего заказа '{id_order}' изменен на '{status}'";
            return message;
        
        }
        
    }
}
