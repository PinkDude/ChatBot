using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DALforChatBot.Repositories;
using ModelEntities.Models;

namespace ChatBot.Models
{
    public class ListJ
    {
        public List<Jsons> listJ { get; set; }

        public ListJ()
        {
            listJ = new List<Jsons>();
        }
    }

    public class Jsons
    {
        public string Number { get; set; }
        public string Request { get; set; }
        public string[][] Response { get; set; } = new string[3][] {new string[2], new string[2], new string[2] };
        public string Operator { get; set; }
        public string OperatorVar { get; set; }

        public bool GetProv()
        {
            try
            {
                if (Response[0][1] == string.Empty)
                {
                    //отправка оператору
                    return true;
                }
                else
                {
                    if (Convert.ToInt32(Response[0][1]) > 90)
                    {
                        //просто сохранение в БД
                        return false;
                    }
                    else
                    {
                        //отправка оператору
                        return true;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async void GoToBD(ChatBotUnitOfWork ChatBot)
        {          
            User user = ChatBot.CommonUsersRepository.FindByPhone(Number).Result;

            if(user == null)
            {
                user = new User(Number);
                await ChatBot.CommonUsersRepository.Create(user);
            }

            if(OperatorVar == null)
            {
                OperatorVar = Response[0][0];
            }

            Operator oper = new Operator("Kek", "Cheburek", "Login", "Password");

            MessageInfo MesInfo = new MessageInfo();
            MesInfo.User = user;
            MesInfo.Operator = oper;
            MesInfo.Message = Request;
            MesInfo.Date = DateTime.Now;
            MesInfo.OperatorsVar = OperatorVar;
            MesInfo.Agility = 0.5f;

            MesInfo.VarOne = Response[0][0] + " : " + Response[0][1];
            MesInfo.VarTwo = Response[1][0] + " : " + Response[1][1];
            MesInfo.VarThree = Response[2][0] + " : " + Response[2][1];

            await ChatBot.MessagesRepository.Create(MesInfo);

            await ChatBot.SaveAsync();
        }
    }
}
